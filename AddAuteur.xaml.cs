﻿using LibraryAdmin.Classes;
using LibraryAdmin.DAO;
using LibraryAdmin.LCollections;
using Microsoft.Win32;
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
    /// Logique d'interaction pour AddAuteur.xaml
    /// </summary>
    public partial class AddAuteur : Window
    {
        LesAuteurs auteurs { get; set; }
        LibraryContext context = new LibraryContext();

        public AddAuteur()
        {
            InitializeComponent();
            //WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;

            auteurs = new LesAuteurs(context);
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|Tous les fichiers (*.*)|*.*"; // Filtre les types de fichiers affichés

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                // Traitez le fichier sélectionné ici, par exemple, affichez le chemin d'accès dans une étiquette ou chargez le contenu du fichier.
                FilePathLabel.Content = selectedFilePath;
            }
        }

        
        private void Ajouter_Auteur_1(object sender, RoutedEventArgs e)
        {
            Exception ex = new Exception("Les insertions sont invalide ou champ vide !");
            Exception ex2 = new Exception("L'auteur existe déjà !!");
            try
            {
                if (nom.Text is null) throw ex;
                if (dateNaissance.SelectedDate is null) throw ex;
                if (dateDeces.SelectedDate is null) throw ex;
                if (prenom.Text is null) throw ex;

                if (FilePathLabel.Content.ToString() == "Sélectionner un fichier") throw ex;


                if (biographie.Text is null) throw ex;
                try
                {
                    bool test = auteurs.Ajouter_Auteur(nom.Text, prenom.Text, FilePathLabel.Content.ToString(), biographie.Text, (DateTime)dateNaissance.SelectedDate, (DateTime)dateDeces.SelectedDate);
                    if (!test) throw ex2;
                    this.Close();
                }
                catch 
                {
                    MessageBox.Show(ex2.Message);
                }
            }



            catch (Exception)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
