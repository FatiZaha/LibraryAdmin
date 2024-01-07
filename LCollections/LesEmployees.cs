using LibraryAdmin.DAO;
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


        public bool Ajouter_Emp(string nom, string prenom, Status status, string adresse, string email, string phone, string image, DateTime dateNaissance)
        {
            var exist = context.Employees.Any(emp => emp.DateNaissance == dateNaissance && emp.Prenom == prenom && emp.Nom == nom);
            if (!exist)
            {
                Employee employee = new Employee(nom, prenom,status, adresse, email, phone, image, dateNaissance);
                context.Employees.Add(employee);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Edit_Employee(int id,string nom, string prenom, Status status, string adresse, string email, string phone, string image, DateTime dateNaissance)
        {
            context.Employees.Where(emp => emp.Id == id).First().Edit_Employee(nom, prenom, status, adresse, email, phone, image, dateNaissance);
            context.SaveChanges();
        }

        public void RemoveEmployee(int id)
        {
            Employee emp= context.Employees.Where(e=> e.Id == id).First();
            context.Employees.Remove(emp);
            context.SaveChanges();
        }

        public HashSet<Employee> RechercheEmployees(string search)
        {
            var employees = context.Employees.Where(emp => emp.Prenom.ToLower().Contains(search.ToLower()) ||
                                                           emp.Nom.ToLower().Contains(search.ToLower()) ||
                                                           emp.Status.ToString().ToLower().Contains(search.ToLower())).ToHashSet();

            return employees;
        }

        public HashSet<Employee> GetEmployees()
        {
            return context.Employees.ToHashSet();
        }

        public Employee GetUnEmployee(int id)
        {
            Employee employee= context.Employees.FirstOrDefault(emp => emp.Id == id);
            return employee;
        }
    }
}