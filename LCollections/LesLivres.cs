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
    internal class LesLivres
    {
        private readonly LibraryContext context;

        public LesLivres(LibraryContext context)
        {
            this.context = context;
        }

        public bool Ajouter_lv(string titre, Auteur auteur, Genre genre, DateTime dateParution, string description, int nbrExempl,string image, float prix)
        {
            var exist = context.Livres.Any(l => l.Titre == titre && l.AuteurId == auteur.Id);
            if (!exist)
            {
                string nouveauChemin = "C:\\Users\\ZAHA Fatima Zahra\\Desktop\\LibraryClient\\wwwroot\\css\\pics\\livre\\" + titre + ".png";
                File.Copy(image, nouveauChemin);
                string imageWeb = "/css/pics/livre/" + titre + ".png";

                Livre livre = new Livre(titre, auteur, genre, dateParution, description, nbrExempl,0,image,imageWeb, prix);
                context.Livres.Add(livre);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Editer_lv(int id,string titre, Auteur auteur, Genre genre, DateTime dateParution, string description, int nbrExempl, int nbrEmpr, string image, float prix)
        {
            string nouveauChemin = "C:\\Users\\ZAHA Fatima Zahra\\Desktop\\LibraryClient\\wwwroot\\css\\pics\\livre\\" + titre + ".png";
            File.Copy(image, nouveauChemin);
            string imageWeb = "/css/pics/livre/" + titre + ".png";

            context.Livres.Where(l=> l.Id == id ).First().Editer_livre(titre,auteur, genre, dateParution, description,nbrExempl,nbrEmpr,image,imageWeb, prix);
            context.SaveChanges();

        }

        public void Remove(int id)
        {
            
            var empr= from e in context.Emprunts
                      where e.LivreId == id
                      select e;
            if(empr.Count() > 0 )
            foreach( var e in empr.ToList() )
            {
                context.Emprunts.Remove((Emprunt)e);
            }
            var panier = from p in context.Panier
                       where p.LivreId == id
                       select p;
            if(panier.Count() > 0)
            foreach( var p in panier.ToList() )
            {
                context.Panier.Remove((Panier)p);
            }
            
            Livre livre=context.Livres.Where(l=>l.Id==id).First();
            context.Livres.Remove(livre);
            context.SaveChanges();
        }

        public HashSet<Livre> RechercheLivre(string search)
        {
            var livres = context.Livres.Where(l => l.Titre.ToLower().Contains(search.ToLower()) ||
                                                   l.Auteur.Nom.ToLower().Contains(search.ToLower()) ||
                                                   l.Auteur.Prenom.ToLower().Contains(search.ToLower()) ||
                                                   l.Genre.ToString().ToLower().Contains(search.ToLower())).ToHashSet();
            return livres;
        }

        public HashSet<Livre> GetLivres()
        {
            
            return context.Livres.ToHashSet();
        }
        public Livre GetUnLivre(int id)
        {
            Livre livre = context.Livres.FirstOrDefault(l => l.Id == id);
            return livre;
        }
    }
}

