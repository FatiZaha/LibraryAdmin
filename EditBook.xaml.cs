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
    /// Logique d'interaction pour EditBook.xaml
    /// </summary>
    public partial class EditBook : Window
    {
        LibraryContext context = new LibraryContext();
        LesLivres lesLivres; // Remplacez "context" par votre instance de LibraryContext
        public Livre livre;
        int idLivre;
        LesAuteurs lesAuteurs;
        public HashSet<Auteur> auteurs { get; set; }
        public List<Genre> genres {  get; set; }= Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();


        public EditBook(int id)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            lesAuteurs = new LesAuteurs(context);
            auteurs= lesAuteurs.GetAuteurs();

            lesLivres = new LesLivres(context);
            idLivre = id;
            livre = lesLivres.GetUnLivre(idLivre);
            InfoLivreEdit();
            DataContext = this;

        }

        private void InfoLivreEdit()
        {
            titre.Text=livre.Titre.ToString();
            auteurLivre.Text=livre.Auteur.Prenom.ToString()+" "+livre.Auteur.Nom.ToString();
            genreLivre.Text=livre.Genre.ToString();
            FilePathLabel.Content= livre.Image.ToString();
            nbrEmpr.Text = livre.NbrEmpr.ToString();
            nbrExmpl.Text = livre.NbrExempl.ToString();
            description.Text = livre.Description.ToString();
            prix.Text = livre.Prix.ToString();
            datePicker.Text=livre.DateParution.ToString();
            genre.SelectedItem = livre.Genre;
            auteur.SelectedItem = livre.Auteur;
        }



        private void Editer_Livre(object sender, RoutedEventArgs e)
        {
            Exception ex = new Exception("sections vide ou invalide !");
            try
            {
                if(titre is null) throw ex;
                if(Convert.ToInt32(nbrExmpl.Text )<=0 ) throw ex;
                if (Convert.ToInt32(nbrExmpl.Text) < Convert.ToInt32(nbrEmpr.Text)) throw ex;
                if (Convert.ToInt32(nbrEmpr.Text) < 0) throw ex;
                if(description.Text == null) throw ex;
                if (Convert.ToInt32(prix.Text) <= 0) throw ex;
                if(datePicker == null) throw ex;
                if(FilePathLabel.Content == null) throw ex;
                

                float p = Convert.ToInt32(prix.Text);
                lesLivres = new LesLivres(context);
                lesLivres.Editer_lv(idLivre, titre.Text, (Auteur)auteur.SelectedItem, (Genre)genre.SelectedItem,(DateTime)datePicker.SelectedDate, description.Text, Convert.ToInt32(nbrExmpl.Text), Convert.ToInt32(nbrEmpr.Text), FilePathLabel.Content.ToString(), p);

                Livres livres = new Livres();
                livres.Show();
                this.Close();
            }
            catch { 
                MessageBox.Show(ex.Message);
            }

            
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
