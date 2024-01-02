using LibraryAdmin.DAO;
using LibraryAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin.LCollections
{
    internal class LesAuteurs
    {
        private readonly LibraryContext context;

        public LesAuteurs(LibraryContext context)
        {
            this.context = context;
        }

        public bool Ajouter_Auteur(string nom, string prenom, string image, DateTime dateNaissance, DateTime dateDeces, string biographie)
        {
            var exist = context.Auteurs.Any(a => a.Nom == nom && a.Prenom == prenom);
            if (!exist)
            {
                Auteur auteur = new Auteur(nom, prenom, image, dateNaissance, dateDeces, biographie);
                context.Auteurs.Add(auteur);
                return true;
            }
            return false;
        }
    }
}