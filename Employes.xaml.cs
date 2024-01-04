using LibraryAdmin.Classes;
using LibraryAdmin.DAO;
using LibraryAdmin.LCollections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryAdmin
{
    /// <summary>
    /// Logique d'interaction pour Employes.xaml
    /// </summary>
    public partial class Employes : Window
    {
        LibraryContext context = new LibraryContext();
        public ObservableCollection<Employee> IEmployees { get; set; }

        public Employes()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            IEmployees = new ObservableCollection<Employee>();

            AddEmployeesToStackPanel();
            DataContext = this;
        }

        private void AddEmployeesToStackPanel()
        {
            LesEmployees lesEmployees = new LesEmployees(context); // Remplacez "context" par votre instance de LibraryContext

            HashSet<Employee> employees = lesEmployees.GetEmployees();

            foreach (Employee employee in employees)
            {
                IEmployees.Add(employee);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var accueil = new Accueil(); //create your new form.

            accueil.Show(); //show the new form.
            this.Close();
        }

        private void AddEmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            var addEmp=new AddEmployees();
            addEmp.Show();
            this.Close();
        }

        private void EditEmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
            int id = (int)button.Tag;

            var editEmp=new EditEmployees(id);
            editEmp.Show();
            this.Close();
        }

        

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchEmployees_Clik(object sender, RoutedEventArgs e)
        {
            LesEmployees lesEmployees = new LesEmployees(context); // Remplacez "context" par votre instance de LibraryContext

            HashSet<Employee> employees = lesEmployees.RechercheEmployees(searchNav.Text);
            IEmployees.Clear();
            foreach (Employee employee in employees)
            {
                IEmployees.Add(employee);
            }
            searchNav.Text = string.Empty;
            DataContext = this;

        }
    }
}
