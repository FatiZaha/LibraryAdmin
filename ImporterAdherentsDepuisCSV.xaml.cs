using LibraryAdmin.Classes;
using LibraryAdmin.DAO;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace LibraryAdmin
{
    /// <summary>
    /// Logique d'interaction pour ImporterAdherentsDepuisCSV.xaml
    /// </summary>
    public partial class ImporterAdherentsDepuisCSV : Window
    {
        LibraryContext context = new LibraryContext();

        string f;
        public ImporterAdherentsDepuisCSV(string filePath)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            f = filePath;
            // Lire le contenu du fichier CSV et l'afficher dans le contrôle ListBox
            string[] lines = File.ReadAllLines(f);
            listBox.ItemsSource = lines;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Adherents adherents = new Adherents();
            adherents.Show();
            this.Close();
        }

        private void ImporterDataAdherents(object sender, RoutedEventArgs e)
        {
            try
            {
                // Lire les lignes du fichier CSV
                string[] lines = File.ReadAllLines(f);

                // Parcourir chaque ligne à partir de la deuxième ligne (la première ligne contient l'en-tête)
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] values = line.Split(',');

                    // Créer un nouvel objet Adherent et assigner les valeurs
                    Adherent adherent = new Adherent
                    {
                        
                        Nom = values[1],
                        Prenom = values[2],
                        Email = values[3],
                        Adresse = values[4],
                        DateNaissance = DateTime.Parse(values[5]),
                        Phone = values[6],
                        Login = values[7],
                        Password = values[8]
                    };

                    // Ajouter l'adhérent à la base de données
                    context.Adherents.Add(adherent);
                }

                // Sauvegarder les modifications dans la base de données
                context.SaveChanges();

                MessageBox.Show("Importation réussie", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                Adherents adherents = new Adherents();
                adherents.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de l'importation : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }
    }
}
