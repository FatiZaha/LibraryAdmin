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
    /// Logique d'interaction pour Adherents.xaml
    /// </summary>
    public partial class Adherents : Window
    {
        LibraryContext context = new LibraryContext();
        
        public ObservableCollection<Adherent> IAdherents { get; set; }
        private List<int> checkedIds = new List<int>();

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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var adherent = (Adherent)checkBox.DataContext;

            if (checkBox.IsChecked == true)
            {
                // Ajouter l'ID de l'adhérent à la liste
                checkedIds.Add(adherent.Id);
            }
            else
            {
                // Retirer l'ID de l'adhérent de la liste s'il est déjà présent
                checkedIds.Remove(adherent.Id);
            }
        }


        private void SelectAllCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            int adherent;
            if (checkBox.IsChecked == false)
            {
                foreach (var item in dataTemplate.Items)
                {
                    if (item is FrameworkElement frameworkElement)
                    {
                        var adherentCheckBox = frameworkElement.FindName("adherentCheck") as CheckBox;
                        if (adherentCheckBox != null)
                        {
                            adherent = Convert.ToInt32(adherentCheckBox.Tag);

                            adherentCheckBox.IsChecked = true;
                            checkedIds.Add(adherent);
                        }
                    }
                }
            }
            else
            {
                foreach (var item in dataTemplate.Items)
                {
                    if (item is FrameworkElement frameworkElement)
                    {
                        var adherentCheckBox = frameworkElement.FindName("adherentCheck") as CheckBox;
                        if (adherentCheckBox != null)
                        {
                            adherent = Convert.ToInt32(adherentCheckBox.Tag);

                            adherentCheckBox.IsChecked = false;
                            checkedIds.Remove(adherent);
                        }
                    }
                }
            }
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
    }
}
