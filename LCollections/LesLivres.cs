using LibraryAdmin.DAO;
using LibraryAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin.LCollections
{
    internal class LesLivres
    {
        private readonly LibraryContext context;

        public LesLivres(LibraryContext context)
        {
            this.context = context;
        }

        public bool Ajouter_lv(string titre, Auteur auteur, Genre genre, string description, string image, DateTime dateParution, int nbrExempl, int nbrEmpr, float prix)
        {
            var exist = context.Livres.Any(l => l.Titre == titre && l.Auteur == auteur);
            if (!exist)
            {
                Livre livre = new Livre(titre, auteur, genre, dateParution, description, nbrExempl, nbrEmpr, image, prix);
                context.Livres.Add(livre);
                return true;
            }
            return false;
        }

        public HashSet<Livre> RechercheLivre_Genre(Genre genre)
        {
            var livres = context.Livres.Where(l => l.Genre == genre).ToHashSet();
            return livres;
        }

        public HashSet<Livre> RechercheLivre_Auteur(Auteur auteur)
        {
            var livres = context.Livres.Where(l => l.Auteur == auteur).ToHashSet();
            return livres;
        }

        public HashSet<Livre> RechercheLivre_Titre(string titre)
        {
            var livres = context.Livres.Where(l => l.Titre == titre).ToHashSet();
            return livres;
        }
    }
}
