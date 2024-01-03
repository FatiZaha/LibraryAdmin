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

        public bool Ajouter_lv(string titre, Auteur auteur, Genre genre, DateTime dateParution, string description, int nbrExempl, int nbrEmpr, string image, float prix)
        {
            var exist = context.Livres.Any(l => l.Titre == titre && l.AuteurId == auteur.Id);
            if (!exist)
            {
                Livre livre = new Livre(titre, auteur, genre, dateParution, description, nbrExempl, nbrEmpr, image, prix);
                context.Livres.Add(livre);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Remove(int id)
        {
            var livre = from l in context.Livres
                         where l.Id == id
                         select l;
            var empr= from e in context.Emprunts
                      where e.LivreId == id
                      select e;
            foreach( var e in empr.ToList() )
            {
                context.Emprunts.Remove((Emprunt)e);
            }
            var panier = from p in context.Panier
                       where p.LivreId == id
                       select p;
            foreach( var p in panier.ToList() )
            {
                context.Panier.Remove((Panier)p);
            }
            
            context.Livres.Remove((Livre)livre);
            context.SaveChanges();
        }

        public HashSet<Livre> RechercheLivre_Genre(Genre genre)
        {
            var livres = context.Livres.Where(l => l.Genre == genre).ToHashSet();
            return livres;
        }

        public HashSet<Livre> RechercheLivre_Auteur(Auteur auteur)
        {
            var livres = context.Livres.Where(l => l.AuteurId == auteur.Id).ToHashSet();
            return livres;
        }

        public HashSet<Livre> RechercheLivre_Titre(string titre)
        {
            var livres = context.Livres.Where(l => l.Titre == titre).ToHashSet();
            return livres;
        }
    }
}

