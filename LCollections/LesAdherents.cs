using LibraryAdmin.DAO;
using LibraryAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin.LCollections
{
    internal class LesAdherents
    {
        private readonly LibraryContext context;

        public LesAdherents(LibraryContext context)
        {
            this.context = context;
        }

        public bool Inscription(string nom, string prenom, string adresse, string email, string phone, string image, DateTime dateNaissance, string login, string password)
        {
            var exist = context.Adherents.Any(a => a.Login == login || a.Email == email);
            if (!exist)
            {
                Adherent adherent = new Adherent(nom, prenom, adresse, email, phone, image, dateNaissance, login, password);
                context.Adherents.Add(adherent);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Connexion(string login, string password)
        {
            return context.Adherents.Any(a => a.Connexion(login, password));
        }

        public HashSet<Adherent> RechercheAdherents(string search)
        {
            var adherents = context.Adherents.Where(a => a.Prenom.ToLower().Contains(search.ToLower()) || a.Nom.ToLower().Contains(search.ToLower())).ToHashSet();
            return adherents;
        }

        public HashSet<Adherent> GetAdherents()
        {
            return context.Adherents.ToHashSet();
        }

        public Adherent GetUnAdherent(int id)
        {
            Adherent adherent = context.Adherents.FirstOrDefault(adh => adh.Id == id);
            return adherent;
        }
    }
}
