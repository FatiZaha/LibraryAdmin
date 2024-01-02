﻿using LibraryAdmin.DAO;
using LibraryAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin.LCollections
{
    internal class LesEmployees
    {
        private readonly LibraryContext context;

        public LesEmployees(LibraryContext context)
        {
            this.context = context;
        }

        public bool Ajouter_Emp(string nom, string prenom, string adresse, string email, string phone, string image, DateTime dateNaissance)
        {
            var exist = context.Employees.Any(emp => emp.DateNaissance == dateNaissance && emp.Prenom == prenom && emp.Nom == nom);
            if (!exist)
            {
                Employee employee = new Employee(nom, prenom, adresse, email, phone, image, dateNaissance);
                context.Employees.Add(employee);
                return true;
            }
            return false;
        }

        public HashSet<Employee> RechercheEmployees(string name)
        {
            var employees = context.Employees.Where(emp => emp.Prenom == name || emp.Nom == name).ToHashSet();
            return employees;
        }
    }
}