/* **************************************
Tuntidemo, MySQL-tietokannan käyttöönottoharjoitus.

Luotu 22.2.2017

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
using System.Windows.Shapes;

namespace Labra_12___Demo
{
    /// <summary>
    /// Interaction logic for TestMysql.xaml
    /// </summary>
    public partial class TestMysql : Window
    {
        public TestMysql()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Labra_12___Demo.ViewModel.StudentViewModel svmo = new ViewModel.StudentViewModel();
                svmo.LoadStudentsFromMysql();
                dgStudents.DataContext = svmo.Students;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
