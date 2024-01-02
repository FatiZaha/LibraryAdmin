using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LibraryAdmin.Classes
{
    internal class Admin : Employee
    {

        public string Login { get; set; }
        public string Password { get; set; }

        public Admin()
        {
            Login = "admin";
            Password = "123456";
        }

        public Admin(string nom, string prenom, string adresse, string email, string phone, string image, DateTime dateNaissance, string login, string password)
            : base(nom, prenom, adresse, email, phone, image, dateNaissance)
        {
            Login = login;
            Password = password;
        }

        public bool Connexion(string login, string password)
        {
            return Login.Equals(login) && Password.Equals(password);
        }
    }
}
