using LibraryAdmin.DAO;
using LibraryAdmin.LCollections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryAdmin
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LibraryContext context;

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            context = new LibraryContext();
            
        }
        


        private void Connecting(object sender, RoutedEventArgs e)
        {
            //ConnectAdmin admin = new ConnectAdmin(context);

            //bool testcnx = admin.Connexion(login.Text, password.Password) ;
            //if (testcnx) { 
            //var accueil = new Accueil(); //create your new form.
            //accueil.Show(); //show the new form.
            //this.Close();}
            //else
            //{
            //    string errorMessage = "Erreur de connexion : Champ de longin ou password incorrect ou vide !!";

            //    // Afficher une fenêtre de dialogue modale avec le message d'erreur
            //    MessageBox.Show(errorMessage, "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);

            //}

            var accueil = new Accueil(); //create your new form.
            accueil.Show(); //show the new form.
            this.Close();
        }
    }

        
    
}
