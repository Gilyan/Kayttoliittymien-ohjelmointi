/* **************************************
Tuntidemo, MVVM -harjoittelua. 
22.2. lisätty myös MySQL-tietokannan käyttöönottoharjoitus.

Luotu 20.2.2017

Minttu Mäkäläinen K8517 @ JAMK 
************************************** */

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labra_12___Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Labra_12___Demo.ViewModel.StudentViewModel svmo = new ViewModel.StudentViewModel();
        public MainWindow()
        {
            InitializeComponent();
            svmo.LoadStudents();

            try
            {
                svmo.LoadStudentsFromMysql();       // Oppilaat tietokannasta
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StudentViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            StudentViewControl.DataContext = svmo;
        }

        private void dgStudents_Loaded(object sender, RoutedEventArgs e)
        {
            dgStudents.DataContext = svmo.Students;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Luodaan observablecollectioniin uusi Student-olio
            Labra_12___Demo.Model.Student uusi = new Model.Student();
            uusi.FirstName = txtFirstName.Text;
            uusi.LastName = txtLastName.Text;
            svmo.Students.Add(uusi);

            // Tyhjätään textboxit
            txtFirstName.Text = "";
            txtLastName.Text = "";
        }
    }
}
