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
            var infoAdherent = new InfoAdherent();
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
            if (selectAllCheckBox.IsChecked == true)
            {
                // Accéder au contenu du ScrollViewer
                var itemsControl = scrollViewer.Content as ItemsControl;

                // Vérifier si le contenu est bien un ItemsControl
                if (itemsControl != null)
                {
                    // Parcourir tous les éléments du ItemsControl
                    foreach (var item in itemsControl.Items)
                    {
                        // Vérifier si l'élément est une ListBoxItem
                        if (item is ListBoxItem listBoxItem)
                        {
                            // Accéder au CheckBox à l'intérieur du ListBoxItem
                            var checkBox = FindVisualChild<CheckBox>(listBoxItem);

                            // Cocher la case à cocher
                            if (checkBox != null)
                            {
                                checkBox.IsChecked = true;

                                var adherent = (Adherent)checkBox.DataContext;
                                // Ajouter l'ID de l'adhérent à la liste
                                checkedIds.Add(adherent.Id);
                            }
                        }
                    }
                }
            }
            else
            {
                // Désélectionner toutes les cases à cocher et vider la liste des ID
                checkedIds.Clear();

                // Accéder au contenu du ScrollViewer
                var itemsControl = scrollViewer.Content as ItemsControl;

                // Vérifier si le contenu est bien un ItemsControl
                if (itemsControl != null)
                {
                    // Parcourir tous les éléments du ItemsControl
                    foreach (var item in itemsControl.Items)
                    {
                        // Vérifier si l'élément est une ListBoxItem
                        if (item is ListBoxItem listBoxItem)
                        {
                            // Accéder au CheckBox à l'intérieur du ListBoxItem
                            var checkBox = FindVisualChild<CheckBox>(listBoxItem);

                            // Désélectionner la case à cocher
                            if (checkBox != null)
                            {
                                checkBox.IsChecked = false;
                            }
                        }
                    }
                }
            }
        }


        // Méthode auxiliaire pour trouver un élément visuel enfant de type T
        private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is T result)
                {
                    return result;
                }
                else
                {
                    var descendant = FindVisualChild<T>(child);

                    if (descendant != null)
                    {
                        return descendant;
                    }
                }
            }

            return null;
        }
    }
}
