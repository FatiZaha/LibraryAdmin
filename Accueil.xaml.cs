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
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        public Accueil()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var connexion = new MainWindow(); //create your new form.

            connexion.Show(); //show the new form.
            this.Close();
        }

        private void pageEmployesBtn_Click(object sender, RoutedEventArgs e)
        {
            var employes = new Employes();
            employes.Show();
            this.Close();
        }

        private void pageLivresBtn_Click(object sender, RoutedEventArgs e)
        {
            var livres = new Livres();
            livres.Show();
            this.Close();
        }

        private void pageAdherentsBtn_Click(object sender, RoutedEventArgs e)
        {
            var adherents = new Adherents();
            adherents.Show();
            this.Close();
        }
    }
}
