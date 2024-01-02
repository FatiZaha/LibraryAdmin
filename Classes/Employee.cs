﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAdmin.Classes
{
    internal class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public DateTime DateNaissance { get; set; }

        public Employee()
        {
        }

        public Employee(string nom, string prenom, string adresse, string email, string phone, string image, DateTime dateNaissance)
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