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
        private int? _numericValue;
        public int? NumericValue
        {
            get { return _numericValue; }
            set
            {
                _numericValue = value;
                // Ajoutez ici le code de notification de modification de la propriété
            }
        }

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
            Exception ex = new Exception("Les insertions sont invalide ou champ vide !");
            Exception ex2 = new Exception("Le livre existe déjà !!");
            try
            {
                string titreText = titre.Text ?? throw ex;
                DateTime selectedDate = dateParution.SelectedDate ?? throw ex;
               string descript = desciprion.Text ?? throw ex;

                string selectedFilePath = FilePathLabel.Content.ToString();
                if(selectedFilePath == "Sélectionner un fichier")  throw ex ;
                if (comboBoxGenre.SelectedItem is null) throw ex;
                Genre selectedGenre = (Genre)comboBoxGenre.SelectedItem;
                if (comboBoxAuteur.SelectedItem is null) throw ex;
                Auteur selectedAuteur = (Auteur)comboBoxAuteur.SelectedItem;
                
                float selectesPrix = Convert.ToInt32(prix.Text);
                if(selectesPrix == 0) throw ex ;

                int selectednbrExmplr = Convert.ToInt32(nbrExmpl.Text);
                if (selectednbrExmplr == 0) throw ex;

                try 
                {
                    lesLivres = new LesLivres(context);
                bool test=lesLivres.Ajouter_lv(titreText, selectedAuteur, selectedGenre, selectedDate, descript, selectednbrExmplr, selectedFilePath, selectesPrix);
                if(!test) throw ex2 ;
                Livres livres = new Livres();
                livres.Show();
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
