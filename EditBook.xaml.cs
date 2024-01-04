using LibraryAdmin.Classes;
using LibraryAdmin.DAO;
using LibraryAdmin.LCollections;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logique d'interaction pour EditBook.xaml
    /// </summary>
    public partial class EditBook : Window
    {
        

        LibraryContext context = new LibraryContext();
        LesAuteurs lesAuteurs;
        public HashSet<Auteur> auteurs { get; set; }
        int idLivre;
        public Livre livre;
        private LesLivres lesLivres;
        public List<Genre> genres { get; set; } = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();




        public EditBook(int id)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            lesAuteurs = new LesAuteurs(context);
            auteurs = lesAuteurs.GetAuteurs();

            this.idLivre = id;
            lesLivres = new LesLivres(context);
            this.livre = lesLivres.GetUnLivre(idLivre);
            

            AfficherInfoLivre();
            DataContext = this;
        }

        public void AfficherInfoLivre()
        {
            titre.Text = livre.Titre.ToString();
            FilePathLabel.Content = livre.Image.ToString();
            auteurLivre.Text = $"{livre.Auteur.Prenom} {livre.Auteur.Nom}";
            genreLivre.Text = livre.Genre.ToString();
            dateParution.Text = livre.DateParution.ToString();
            nbrExmpl.Text = livre.NbrExempl.ToString();
            nbrEmpr.Text=livre.NbrEmpr.ToString();
            prix.Text=livre.Prix.ToString();
            description.Text = livre.Description.ToString();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddAuteurButton_Click(object sender, RoutedEventArgs e)
        {
            AddAuteur addAuteur = new AddAuteur();
            addAuteur.Show();
        }
    }
}
