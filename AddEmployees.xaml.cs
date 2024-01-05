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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employes employes = new Employes();
            employes.Show();
            this.Close();
        }

        private void AddEmpButton_Click(object sender, RoutedEventArgs e)
        {
            Employes employes = new Employes();
            employes.Show();
            this.Close();
        }
    }
}
