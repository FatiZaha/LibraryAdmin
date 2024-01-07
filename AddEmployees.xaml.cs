using LibraryAdmin.Classes;
using LibraryAdmin.DAO;
using LibraryAdmin.LCollections;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LibraryAdmin.Classes;

namespace LibraryAdmin
{
    /// <summary>
    /// Logique d'interaction pour AddEmployees.xaml
    /// </summary>
    public partial class AddEmployees : Window
    {
        LibraryContext context = new LibraryContext();
        private LesEmployees lesEmployees;
        public List<Status> statuses { get; set; } = Enum.GetValues(typeof(Status)).Cast<Status>().ToList();


        public AddEmployees()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            DataContext = this;
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|Tous les fichiers (*.*)|*.*"; // Filtre les types de fichiers affichés

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                // Traitez le fichier sélectionné ici, par exemple, affichez le chemin d'accès dans une étiquette ou chargez le contenu du fichier.
                FilePathLabel.Content = selectedFilePath;
            }
        }

        private void AddEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            Employes employes = new Employes();
            employes.Show();
            this.Close();
        }


        private void AjouterLivre(object sender, RoutedEventArgs e)
        {
            





        }


        private void AddEmpButton_Click(object sender, RoutedEventArgs e)
        {
            Exception ex = new Exception("Les insertions sont invalide ou champ vide !");
            Exception ex2 = new Exception("L'employée existe déjà !!");
            try
            {
                if( nom.Text is null) throw ex;
                if(dateNaissance.SelectedDate is null) throw ex;

                if( prenom.Text is null) throw ex;

                if (FilePathLabel.Content.ToString() == "Sélectionner un fichier") throw ex;
                if(role.SelectedItem is null) throw ex;

                if(email.Text is null) throw ex;
                if (adresse.Text is null) throw ex;

                if(phone.Text is null)throw ex;

                try
                {
                    lesEmployees = new LesEmployees(context);
                    bool test = lesEmployees.Ajouter_Emp(nom.Text, prenom.Text, (Status)role.SelectedItem, adresse.Text, email.Text, phone.Text, FilePathLabel.Content.ToString(), (DateTime)dateNaissance.SelectedDate) ;
                    if (!test) throw ex2;
                    Employes employes = new Employes();
                    employes.Show();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(ex2.Message);
                }

            }
            catch (Exception)
            {
                MessageBox.Show(ex.Message);
            }


            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employes employes = new Employes();
            employes.Show();
            this.Close();
        }
    }
}
