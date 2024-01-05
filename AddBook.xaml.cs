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
using static System.Net.Mime.MediaTypeNames;

namespace LibraryAdmin
{
    /// <summary>
    /// Logique d'interaction pour AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        LibraryContext context = new LibraryContext();
        private LesLivres lesLivres;
        LesAuteurs lesAuteurs;
        public HashSet<Auteur> auteurs { get; set; }
        public List<Genre> genres { get; set; } = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();

        public AddBook()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            lesAuteurs = new LesAuteurs(context);
            auteurs = lesAuteurs.GetAuteurs();

            DataContext = this;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumeric(e.Text);
        }

        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
        }


        private void AjouterLivre(object sender, RoutedEventArgs e)
        {
            string titreText = titre.Text;
            string selectedFilePath = FilePathLabel.Content.ToString();
            Genre selectedGenre = (Genre)comboBoxGenre.SelectedItem;
            Auteur selectedAuteur = (Auteur)comboBoxAuteur.SelectedItem;
            DateTime selectedDate = dateParution.SelectedDate ?? DateTime.MinValue;
            float selectesPrix = float.Parse(prix.Text);
            int selectednbrExmplr = int.Parse(nbrExmpl.Text);


            if (titre.Text!=string.Empty) { }

            Livres livres = new Livres();
            livres.Show();
            this.Close();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Livres livres = new Livres();
            livres.Show();
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
