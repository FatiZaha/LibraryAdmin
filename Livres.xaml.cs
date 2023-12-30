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
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Livres : Window
    {
        public Livres()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var accueil = new Accueil(); //create your new form.
            
            accueil.Show(); //show the new form.
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddBook addBook = new AddBook();
            addBook.Show();
            this.Close();
        }

        private void Add_Book(object sender, RoutedEventArgs e)
        {
            EditBook editBook = new EditBook();
            editBook.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
