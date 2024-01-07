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

using Microsoft.Win32;
using System.IO;

namespace LibraryAdmin
{
    /// <summary>
    /// Logique d'interaction pour Adherents.xaml
    /// </summary>
    public partial class Adherents : Window
    {
        LibraryContext context = new LibraryContext();
        
        public ObservableCollection<Adherent> IAdherents { get; set; }

        public Adherents()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            IAdherents = new ObservableCollection<Adherent>();

            AddAdherentsToStachPanel();
            DataContext = this;

        }

        private void AddAdherentsToStachPanel()
        {
            LesAdherents lesAdherents = new LesAdherents(context);
            HashSet<Adherent> adherents = lesAdherents.GetAdherents();

            foreach (Adherent adherent in adherents)
            {
                IAdherents.Add(adherent);
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var accueil=new Accueil();
            accueil.Show();
            this.Close();
        }

        private void InfoAdherent_Clik(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Tag);

            var infoAdherent = new InfoAdherent(id);
            infoAdherent.Show();
            this.Close();

        }

        


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LesAdherents lesAdherents = new LesAdherents(context);
            HashSet<Adherent> adherents;

            TextBox textBox = (TextBox)sender;

            if (textBox.Text != string.Empty)
            {

                adherents = lesAdherents.RechercheAdherents(textBox.Text);

                IAdherents.Clear();
                foreach (Adherent adherent in adherents)
                {
                    IAdherents.Add(adherent);
                }

            }

            else
            {
                adherents = lesAdherents.GetAdherents();
                IAdherents.Clear();
                foreach (Adherent adherent in adherents)
                {
                    IAdherents.Add(adherent);
                }
            }

            DataContext = this;

        }

        private void Importer_CSV(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichier CSV (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                // Appel à la méthode pour importer les données des adhérents depuis le fichier CSV
                ImporterAdherentsDepuisCSV i = new ImporterAdherentsDepuisCSV(filePath);
                i.Show();
                this.Close();
            }
        }

        private void ExporterAdherentsEnCSV(string filePath)
        {
            // Récupérer les adhérents sélectionnés en fonction des IDs dans la liste checkedIds
            List<Adherent> adherentsExport = IAdherents.ToList();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Écrire l'en-tête du fichier CSV
                

                writer.WriteLine("\"Id\",\"Nom\",\"Prenom\",\"Email\",\"Adresse\",\"DateNaissance\",\"Phone\",\"Login\",\"Password\""); // Ajoutez les autres colonnes nécessaires

                // Écrire les données des adhérents
                foreach (Adherent adherent in adherentsExport)
                {
                    writer.Write($"\"{adherent.Id}\"");
                    writer.Write(",");
                    writer.Write($"\"{adherent.Nom}\"");
                    writer.Write(",");
                    writer.Write($"\"{adherent.Prenom}\"");
                    writer.Write(",");
                    writer.Write($"\"{adherent.Email}\"");
                    writer.Write(",");
                    writer.Write($"\"{adherent.Adresse}\"");
                    writer.Write(",");
                    writer.Write($"\"{adherent.DateNaissance}\"");
                    writer.Write(",");
                    writer.Write($"\"{adherent.Phone}\"");
                    writer.Write(",");
                    writer.Write($"\"{adherent.Login}\"");
                    writer.Write(",");
                    writer.Write($"\"{adherent.Password}\"");
                    writer.WriteLine(); // Nouvelle ligne pour chaque adhérent
                }
            }

            MessageBox.Show("Exportation réussie", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exporter_CSV(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Fichier CSV (*.csv)|*.csv|*.xls";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                // Appel à la méthode pour exporter les données des adhérents vers le fichier CSV en utilisant le chemin du fichier sélectionné
                ExporterAdherentsEnCSV(filePath);
            }
        }
    }
}
