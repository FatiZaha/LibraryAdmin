using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAdmin.Classes
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
<<<<<<< HEAD

        [Display(Name = "Status")]
        public Status Status { get; set; }

=======
>>>>>>> parent of 5fd6eba (edit)
        public string Adresse { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public DateTime DateNaissance { get; set; }

        public Employee()
        {
        }

<<<<<<< HEAD
        public Employee(string nom, string prenom, Status status, string adresse, string email, string phone, string image, DateTime dateNaissance)
=======
        public Employee(string nom, string prenom, string adresse, string email, string phone, string image, DateTime dateNaissance)
>>>>>>> parent of 5fd6eba (edit)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Email = email;
            Phone = phone;
            Image = image;
            DateNaissance = dateNaissance;
        }
    }
}