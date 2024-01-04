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
            int id = (int)button.Tag;
            EditBook editBook = new EditBook(id);
            editBook.Show();
            this.Close();
        }

        

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void SearchLivre_Click(object sender, RoutedEventArgs e)
        {
            LesLivres lesLivres = new LesLivres(context);
            HashSet<Livre> livres = lesLivres.RechercheLivre(searchNav.Text);
            ILivres.Clear();
            foreach (Livre livre in livres)
            {
                ILivres.Add(livre);
            }
            searchNav.Text = string.Empty;
            DataContext = this;
        }
    }
}
