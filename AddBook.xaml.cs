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
    /// Logique d'interaction pour AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public AddBook()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Home home = new Home();
            home.Show();
            this.Close();
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

        private void AddAuteurButton_Click(object sender, RoutedEventArgs e)
        {
            AddAuteur addAuteur = new AddAuteur();
            addAuteur.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
