using System;
using System.Collections.Generic;
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

namespace LibraryAdmin
{
    /// <summary>
    /// Logique d'interaction pour Employes.xaml
    /// </summary>
    public partial class Employes : Window
    {
        public Employes()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
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
            var editEmp=new EditEmployees();
            editEmp.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
