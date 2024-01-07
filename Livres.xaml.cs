using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using LibraryAdmin.DAO;
using LibraryAdmin.LCollections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Controls.TextBox;

namespace LibraryAdmin
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Livres : System.Windows.Window
    {

        LibraryContext context = new LibraryContext();
        public ObservableCollection<Livre> ILivres { get; set; }

        public Livres()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            ILivres = new ObservableCollection<Livre>();
            
            AddBooksToStackPanel();
            DataContext = this;
        }

        private void AddBooksToStackPanel()
        {
            LesLivres lesLivres = new LesLivres(context); // Remplacez "context" par votre instance de LibraryContext

            HashSet<Livre> livres = lesLivres.GetLivres();

            foreach (Livre livre in livres)
            {
                ILivres.Add(livre);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var accueil = new Accueil(); //create your new form.
            
            accueil.Show(); //show the new form.
            this.Close();
        }

        private void Add_Book(object sender, RoutedEventArgs e)
        {
            AddBook addBook = new AddBook();
            addBook.Show();
            this.Close();
        }

        private void Edit_Book(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
            int id = Convert.ToInt32(button.Tag);

            EditBook editBook = new EditBook(id);
            editBook.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LesLivres lesLivres = new LesLivres(context); // Remplacez "context" par votre instance de LibraryContext
            HashSet<Livre> livres;

            TextBox textBox = (TextBox)sender;

            if(textBox.Text != string.Empty) { 

                livres = lesLivres.RechercheLivre(textBox.Text);

                ILivres.Clear();
                foreach (Livre livre in livres)
                {
                    ILivres.Add(livre);
                }
            }

            else
            {
                livres = lesLivres.GetLivres();
                ILivres.Clear();
                foreach (Livre livre in livres)
                {
                    ILivres.Add(livre);
                }
            }

            DataContext = this;

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
            int id = Convert.ToInt32(button.Tag);

            LesLivres lesLivres = new LesLivres(context);
            Livre lv=lesLivres.GetUnLivre(id);
            lesLivres.Remove(id);
            ILivres.Remove(lv);
        }

        private void OpenPopup_Click(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = true;
        }

        private void Edit_Auteur(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
            string buttonText = button.Content.ToString();

            // Effectuez les actions souhaitées en fonction du bouton cliqué
            MessageBox.Show($"Vous avez cliqué sur le bouton '{buttonText}'.");
            myPopup.IsOpen = false;
        }
    }
}
