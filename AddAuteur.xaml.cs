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
    /// Logique d'interaction pour AddAuteur.xaml
    /// </summary>
    public partial class AddAuteur : Window
    {
        public AddAuteur()
        {
            InitializeComponent();
            //WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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

        
        private void Ajouter_Auteur_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
