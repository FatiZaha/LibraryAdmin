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
using OfficeOpenXml;
using Microsoft.Win32;
using System.IO;
using System.Data;

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
            openFileDialog.Filter = "Fichiers Excel (*.xlsx, *.xls)|*.xlsx;*.xls";
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
            LesAdherents lesAdherents = new LesAdherents(context);
            // Appeler votre méthode existante pour récupérer les données à exporter
            IQueryable<Adherent> adherents = lesAdherents.ExportData();

            // Convertir les données en une liste
            List<Adherent> adherentsList = adherents.ToList();

            // Créer un DataTable et définir les colonnes
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nom");
            dataTable.Columns.Add("Prenom");
            dataTable.Columns.Add("DateNaissance");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Adresse");
            dataTable.Columns.Add("Phone");
            dataTable.Columns.Add("Login");
            dataTable.Columns.Add("Password");
            // Ajouter d'autres colonnes selon vos besoins

            // Remplir le DataTable avec les données des adhérents
            foreach (Adherent adherent in adherentsList)
            {
                // Créer une nouvelle ligne dans le DataTable
                DataRow row = dataTable.NewRow();

                // Remplir les valeurs des colonnes pour chaque adhérent
                row["Nom"] = adherent.Nom;
                row["Prenom"] = adherent.Prenom;
                row["DateNaissance"] = adherent.DateNaissance;
                row["Email"] = adherent.Email;
                row["Adresse"] = adherent.Adresse;
                row["Phone"] = adherent.Phone;
                row["Login"] = adherent.Login;
                row["Password"] = adherent.Password;
                
                // Affecter les autres valeurs de colonnes selon votre modèle Adherent

                // Ajouter la ligne au DataTable
                dataTable.Rows.Add(row);
            }

            // Créer un nouveau fichier Excel avec EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new ExcelPackage();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

            // Écrire les en-têtes de colonnes dans le fichier Excel
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
            }

            // Écrire les données dans le fichier Excel
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][j];
                }
            }

            // Enregistrer le fichier Excel dans le chemin spécifié
            FileInfo excelFile = new FileInfo(filePath);
            excelPackage.SaveAs(excelFile);

            MessageBox.Show("Exportation réussie", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
        }

       
        

        private void Exporter_CSV(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Fichiers Excel (*.xlsx, *.xls)|*.xlsx;*.xls";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                // Appel à la méthode pour exporter les données des adhérents vers le fichier CSV en utilisant le chemin du fichier sélectionné
                ExporterAdherentsEnCSV(filePath);
            }
        }
    }
}
