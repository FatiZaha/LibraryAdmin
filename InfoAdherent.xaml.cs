using LibraryAdmin.Classes;
using LibraryAdmin.DAO;
using LibraryAdmin.LCollections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour InfoAdherent.xaml
    /// </summary>
    public partial class InfoAdherent : Window
    {
        LibraryContext context = new LibraryContext();
        public HashSet<Emprunt> emprunts { get; set; }= new HashSet<Emprunt>();
        public HashSet<Emprunt> retours { get; set; }= new HashSet<Emprunt>();
        LesLivres LesLivres;
        HashSet<Livre> livres;
        LesEmprunts lesEmprunts;

        int idAdherent;
        Adherent adherent;

        public InfoAdherent(int id)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            LesLivres = new LesLivres(context);
            livres= LesLivres.GetLivres();

            LesAdherents lesAdherents = new LesAdherents(context);
            lesEmprunts = new LesEmprunts(context);
            idAdherent = id;
            adherent = lesAdherents.GetUnAdherent(id);
            Info();
            LEmprunts();
            LRetours();

            DataContext = this;
        }

        public void Info()
        {
            nomComplet.Content = adherent.Prenom + " " + adherent.Nom;
            email.Content = adherent.Email;
            adresse.Content = adherent.Adresse;
            phone.Content = adherent.Phone;
            
            
        }

        public void LEmprunts()
        {
            emprunts.Clear();
            emprunts= lesEmprunts.ListeEmprunt(idAdherent);
            
        }

        public void LRetours()
        {
            retours.Clear();
            retours = lesEmprunts.ListeRetour(idAdherent);
            
        }

        public void Retour_Livre(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Tag);

            lesEmprunts.RetourLivre(id);
            
            InfoAdherent infoAdherent=new InfoAdherent(idAdherent);
            infoAdherent.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var adherents = new Adherents();
            adherents.Show();
            this.Close();
        }
    }
}
