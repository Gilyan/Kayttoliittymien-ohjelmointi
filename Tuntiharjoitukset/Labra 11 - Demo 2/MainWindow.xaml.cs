/* **************************************
Tuntidemo, Data Binding -harjoittelua.

Luotu 13.2.2017

Minttu Mäkäläinen K8517 @ JAMK 
************************************** */

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using JAMK.ICT;

namespace Labra_11___Demo_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Koska useampi metodi (= tapahtuman käsittelijä) tulee käyttämään näitä muuttujia -->
        // määritellään luokan tasolle
        JAMK.ICT.HockeyLeague liiga;
        ObservableCollection<JAMK.ICT.HockeyTeam> joukkueet;
        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            // Tänne kootusti omien kontrollien asetukset
            List<string> movies = new List<string>();
            movies.Add("Hobbit");
            movies.Add("Lord of the Rings");
            movies.Add("Star Wars");
            cmbElokuvat.ItemsSource = movies;

            // Haetaan SMLiiga-joukkueet
            liiga = new JAMK.ICT.HockeyLeague();
            joukkueet = liiga.GetTeams();
            cmbJoukkue.ItemsSource = joukkueet;
        }

        private void btnBind_Click(object sender, RoutedEventArgs e)
        {
            // Määritellään Stackpanelin DataContext
            // Demo1: Datacontext = olio
            //HockeyTeam tiimi = new HockeyTeam("KeuPa", "Keuruu");
            //spRight.DataContext = tiimi;

            // Demo2 : Kytketään oliokokoelman 1. olioon
            spRight.DataContext = joukkueet[counter];
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (counter > 0)
            { counter--; }
            spRight.DataContext = joukkueet[counter];
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (counter < joukkueet.Count -1)
            { counter++; } 
            spRight.DataContext = joukkueet[counter];
        }

        private void btnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Visibility = System.Windows.Visibility.Visible;
            txtUusiJoukkue.Visibility = System.Windows.Visibility.Visible;
            txtUusiKaupunki.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            joukkueet.Add(new HockeyTeam(txtUusiJoukkue.Text, txtUusiKaupunki.Text));
            spRight.DataContext = joukkueet[counter];
            btnSave.Visibility = System.Windows.Visibility.Hidden;
            txtUusiJoukkue.Visibility = System.Windows.Visibility.Hidden;
            txtUusiKaupunki.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
