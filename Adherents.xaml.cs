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
    /// Logique d'interaction pour Adherents.xaml
    /// </summary>
    public partial class Adherents : Window
    {
        public Adherents()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var accueil=new Accueil();
            accueil.Show();
            this.Close();
        }

        
    }
}
