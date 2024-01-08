using LibraryAdmin.Classes;
using LibraryAdmin.DAO;
using LibraryAdmin.LCollections;
using OfficeOpenXml;
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
            FileInfo file = new FileInfo(f);
            ExcelPackage package = new ExcelPackage(file);

            // Licence 
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Récupérer la première feuille du fichier Excel
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            // Lire les données de la feuille Excel et les stocker dans une liste de dictionnaires
            List<object> excelData = new List<object>();

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                object rowData = new
                {
                    Column1 = worksheet.Cells[row, 1].Value?.ToString() ?? string.Empty,
                    Column2 = worksheet.Cells[row, 2].Value?.ToString() ?? string.Empty,
                    Column3 = worksheet.Cells[row, 3].Value?.ToString() ?? string.Empty,
                    Column4 = worksheet.Cells[row, 4].Value?.ToString() ?? string.Empty,
                    Column5 = worksheet.Cells[row, 5].Value?.ToString() ?? string.Empty,
                    Column6 = worksheet.Cells[row, 6].Value?.ToString() ?? string.Empty,
                    Column7 = worksheet.Cells[row, 7].Value?.ToString() ?? string.Empty,
                    Column8 = worksheet.Cells[row, 8].Value?.ToString() ?? string.Empty
                };

                excelData.Add(rowData);
            }

            dataGrid.ItemsSource = excelData;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Adherents adherents = new Adherents();
            adherents.Show();
            this.Close();
        }

        private void ImportDataFromExcel(object sender, RoutedEventArgs e)
        {
            List<Adherent> adherents = new List<Adherent>();

            // Charger le fichier Excel à l'aide de EPPlus
            FileInfo file = new FileInfo(f);
            ExcelPackage package = new ExcelPackage(file);
            // Licence 
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Récupérer la première feuille du fichier Excel
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            // Lire les données de la feuille Excel et les stocker dans la liste d'objets Adherent
            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                Adherent adherent = new Adherent();

                adherent.Nom = worksheet.Cells[row, 1].Value?.ToString();
                adherent.Prenom = worksheet.Cells[row, 2].Value?.ToString();
                DateTime dateNaissance;
                // Affecter d'autres propriétés selon votre modèle Adherent
                if (DateTime.TryParse(worksheet.Cells[row, 3].Value?.ToString(), out dateNaissance))
                {
                    adherent.DateNaissance = dateNaissance;
                }
                else
                {
                    // Gérer le cas où la conversion échoue, par exemple en attribuant une valeur par défaut à adherent.DateNaissance
                    adherent.DateNaissance = DateTime.MinValue;
                }

                adherent.Email = worksheet.Cells[row, 4].Value?.ToString();
                adherent.Adresse = worksheet.Cells[row, 5].Value?.ToString();
                adherent.Phone = worksheet.Cells[row, 6].Value?.ToString();
                adherent.Login = worksheet.Cells[row, 7].Value?.ToString();
                adherent.Password = worksheet.Cells[row, 8].Value?.ToString();

                adherents.Add(adherent);
            }
            LesAdherents lesAdherents = new LesAdherents(context);
            lesAdherents.ImporterData(adherents);
            MessageBox.Show("Exportation réussie", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            Adherents adh = new Adherents();
            adh.Show();
            this.Close();
        }

    }
}
