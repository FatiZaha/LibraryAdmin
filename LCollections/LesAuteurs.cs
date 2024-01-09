using LibraryAdmin.DAO;
using LibraryAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryAdmin.LCollections
{
    internal class LesAuteurs
    {
        private readonly LibraryContext context;

        public LesAuteurs(LibraryContext context)
        {
            this.context = context;
        }

        public bool Ajouter_Auteur(string nom, string prenom, string image, string biographie, DateTime dateNaissance, DateTime dateDeces)
        {
            var exist = context.Auteurs.Any(a => a.Nom == nom && a.Prenom == prenom);
            if (!exist)
            {
                string nouveauChemin = "C:\\Users\\ZAHA Fatima Zahra\\Desktop\\LibraryClient\\wwwroot\\css\\pics\\auteur\\"+nom+"_"+prenom+".png";
                File.Copy(image, nouveauChemin);
                string imageWeb= "/css/pics/auteur/"+nom+"_"+prenom+".png";

                Auteur auteur = new Auteur(nom, prenom,imageWeb, image, dateNaissance, dateDeces, biographie);
                context.Auteurs.Add(auteur);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void EditerAuteur(int id, string nom, string prenom, string image, string biographie, DateTime dateNaissance, DateTime dateDeces)
        {
            string nouveauChemin = "C:\\Users\\ZAHA Fatima Zahra\\Desktop\\LibraryClient\\wwwroot\\css\\pics\\auteur\\" + nom + "_" + prenom + ".png";
            File.Copy(image, nouveauChemin);
            string imageWeb = "/css/pics/auteur/" + nom + "_" + prenom + ".png";

            context.Auteurs.Where(a => a.Id == id).First().Edit(nom, prenom, imageWeb, image, dateNaissance, dateDeces, biographie);
            context.SaveChanges();
        }

        public void deleteAuteur(int id)
        {
            Auteur auteur = context.Auteurs.FirstOrDefault(a => a.Id == id);
            context.Auteurs.Remove(auteur);
            context.SaveChanges();
        }

        public HashSet<Auteur> GetAuteurs()
        {
            return context.Auteurs.ToHashSet();
        }
        public Auteur GetUnAuteur(int id)
        {
            Auteur auteur = context.Auteurs.FirstOrDefault(a => a.Id == id);
            return auteur;
        }
    }
}