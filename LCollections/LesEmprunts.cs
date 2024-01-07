using LibraryAdmin.Classes;
using LibraryAdmin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin.LCollections
{
    internal class LesEmprunts
    {
        private readonly LibraryContext context;
        public LesEmprunts(LibraryContext context)
        {
            this.context = context;
        }

        public void RetourLivre(int id)
        {
            // modifier l'etat de emprunt en true
            Emprunt emprunt = context.Emprunts.FirstOrDefault(e => e.Id == id);

            // Vérifier si l'emprunt a été trouvé
            if (emprunt != null)
            {
                // Modifier l'état de retour de l'emprunt
                emprunt.EtatRetour = true;
                emprunt.Livre.NbrEmpr--;

                // Enregistrer les modifications dans le contexte
                context.SaveChanges();
            }
        }

        

        public bool AddEmprunt(Livre livre, Adherent adherent, DateTime date_empr, DateTime date_retour)
        {
            if (livre.NbrEmpr < livre.NbrExempl)
            {
                livre.NbrEmpr++;
                Emprunt emprunt = new Emprunt(livre, adherent, date_empr, date_retour, 0, false);

                int joursEmprunt = (int)(emprunt.Date_retour - emprunt.Date_empr).TotalDays;
                emprunt.Montant = emprunt.Livre.Prix * joursEmprunt;

                context.Emprunts.Add(emprunt);
                context.SaveChanges();
                return true;
            }

            return false;

        }

        public HashSet<Emprunt> ListeEmprunt(int idAdherent)
        {
            var e = from emp in context.Emprunts
                    join adh in context.Adherents
                    on emp.AdherentId equals adh.Id
                    where emp.EtatRetour == false && adh.Id == idAdherent
                    select emp;
            return e.ToHashSet();
        }

        public HashSet<Emprunt> ListeRetour(int idAdherent)
        {
            var e = from emp in context.Emprunts
                    join adh in context.Adherents
                    on emp.AdherentId equals adh.Id
                    where emp.EtatRetour == true && adh.Id == idAdherent
                    select emp;
            return e.ToHashSet();
        }
    }
}
