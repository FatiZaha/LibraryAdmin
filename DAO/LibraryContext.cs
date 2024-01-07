using LibraryAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryAdmin.DAO
{
    internal class LibraryContext:DbContext
    {
        public DbSet<Auteur> Auteurs { get; set; }        
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Adherent> Adherents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Panier> Panier { get; set; }
        public DbSet<Emprunt> Emprunts { get; set;}


        public LibraryContext() : base("librarydbo")
        {
        }
    }
}
