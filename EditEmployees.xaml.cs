using LibraryAdmin.Classes;
using LibraryAdmin.DAO;
using LibraryAdmin.LCollections;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace LibraryAdmin
{
    /// <summary>
    /// Logique d'interaction pour EditEmployees.xaml
    /// </summary>
    public partial class EditEmployees : Window
    {

        LibraryContext context = new LibraryContext();
        int idEmployee;
        public Employee employee;
        private LesEmployees lesEmployees;
        public List<Status> statuses { get; set; } = Enum.GetValues(typeof(Status)).Cast<Status>().ToList();


        public EditEmployees(int id)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            this.idEmployee = id;
            lesEmployees = new LesEmployees(context);
            this.employee = lesEmployees.GetUnEmployee(idEmployee);

            AfficherInfoEmployee();
            DataContext = this;
        }

        private void AfficherInfoEmployee()
        {
            nom.Text = employee.Nom.ToString();
            prenom.Text = employee.Prenom.ToString();
            empStatus.Text = employee.Status.ToString();
            FilePathLabel.Content = employee.Image.ToString();
            dateNaissance.Text = employee.DateNaissance.ToString();
            email.Text = employee.Email.ToString();
            adresse.Text = employee.Adresse.ToString();
            phone.Text = employee.Phone.ToString();
            status.SelectedItem = employee.Status;
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

        private void EditEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            Exception ex = new Exception("Les insertions sont invalide ou champ vide !");
            try
            {
                if (nom.Text is null) throw ex;
                if (dateNaissance.SelectedDate is null) throw ex;

                if (prenom.Text is null) throw ex;

                if (FilePathLabel.Content.ToString() == "Sélectionner un fichier") throw ex;
                if (status.SelectedItem is null) throw ex;

                if (email.Text is null) throw ex;
                if (adresse.Text is null) throw ex;

                if (phone.Text is null) throw ex;

                lesEmployees = new LesEmployees(context);
                lesEmployees.Edit_Employee(idEmployee,nom.Text, prenom.Text, (Status)status.SelectedItem, adresse.Text, email.Text, phone.Text, FilePathLabel.Content.ToString(),(DateTime)dateNaissance.SelectedDate);
                    
                Employes employes = new Employes();
                employes.Show();
                this.Close();
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
