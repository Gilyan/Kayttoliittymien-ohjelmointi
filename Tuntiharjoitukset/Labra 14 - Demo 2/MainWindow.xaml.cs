/* **************************************
Tuntidemo, tiedon hakua internetistä, VR-junien aikatauluja.

Käytössä Newtonsoft.Json
Tiedot: https://rata.digitraffic.fi/api/v1/live-trains?station=JY

Luotu 20.3.2017

Minttu Mäkäläinen K8517 @ JAMK 
************************************** */

using JAMK.IT;
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

namespace Labra_14___Demo_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Train> trains = new List<Train>();
        public MainWindow()
        {
            InitializeComponent();
            InitializeMyStuff();
        }

        #region METHODS
        void InitializeMyStuff()
        {
            // Omat asetukset kootaan tänne
            // Täytetään ComboBox asemilla
            GetStations();
        }

        private void GetStations()
        {
            List<Station> stations = new List<Station>();
            stations.Add(new Station("JY", "Jyväskylä"));
            stations.Add(new Station("HKI", "Helsinki"));
            stations.Add(new Station("TPE", "Tampere"));        // TODO: hae asemapaikat API:n json:sta

            // Kiinnitetään stations-kokoelma ComboCoxiin
            cbStations.DisplayMemberPath = "Name";
            cbStations.SelectedValuePath = "Code";
            cbStations.DataContext = stations;
        }

        private void GetTrainsAt()
        {
            // Haetaan asemalta lähtevät junat
            string st = cbStations.SelectedValue.ToString();
            trains = JAMK.IT.TrainsVM.GetTrainsAt(st);
            dgTrains.DataContext = trains;
            tbMessage.Text = string.Format("Löytyi {0} junaa", trains.Count);

        }
        #endregion

        private void btnGetTrains_Click(object sender, RoutedEventArgs e)
        {
            if (cbStations.SelectedValue != null)
            {
                // V1: Alkuperäinen
                tbMessage.Text = "Haetaan junat...";
                GetTrainsAt();
            }
        }
    }
}
