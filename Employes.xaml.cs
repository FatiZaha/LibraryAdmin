using LibraryAdmin.Classes;
using LibraryAdmin.DAO;
using LibraryAdmin.LCollections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using TextBox = System.Windows.Controls.TextBox;

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

            AddEmployeesToStachPanel();
            DataContext = this;
        }

        public void AddEmployeesToStachPanel()
        {
            LesEmployees lesEmployees = new LesEmployees(context);
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
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Tag);
            
            var editEmp=new EditEmployees(id);
            editEmp.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LesEmployees lesEmployees = new LesEmployees(context);
            HashSet<Employee> employees;
            
            TextBox textBox = (TextBox)sender;

            if (textBox.Text != string.Empty)
            {

                employees = lesEmployees.RechercheEmployees(textBox.Text);

                IEmployees.Clear();
                foreach (Employee employee in employees)
                {
                    IEmployees.Add(employee);
                }

            }

            else
            {
                employees = lesEmployees.GetEmployees();
                IEmployees.Clear();
                foreach (Employee employee in employees)
                {
                    IEmployees.Add(employee);
                }
            }

            DataContext = this;

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
