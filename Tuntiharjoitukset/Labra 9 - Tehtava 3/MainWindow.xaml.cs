/* **************************************
Tuntitehtäviä, WPF harjoittelua.

Luotu 6.2.2017

Toiminta: Keski-suomalainen pieni ikkunoita valmistava yritys Oy K-S Windows Ab tarvitsee 
yksinkertaista sovellusta, jolla tehtaan työntekijät voivat laskea asiakkaan tilaamista 
ikkunoista ikkunalasin ja karmipuiden menekin. Käyttäjä syöttää ikkunan leveyden ja korkeuden 
millimetreinä sekä karmipuun leveyden (oletusarvo 45 mm). Tämän jälkeen hän kliksauttaa 
laske-painiketta ja sovellus laskee ikkunalasin pinta-alan sekä tarvittavan karmipuiden piirin.

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

namespace Labra_9___Tehtava_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int ikkunanLeveys = 0, ikkunanKorkeus = 0, karminLeveys = 0;
            double ikkunanAla = 0, lasinAla = 0, karminPiiri = 0;

            string teksti, teksti2, teksti3, teksti4, teksti5, teksti6;

            try
            {
                teksti = textBox.Text;                  // Luetaan syöte ikkunan leveys
                ikkunanLeveys = Int32.Parse(teksti);    // Muunnetaan numeroksi

                teksti2 = textBox_Copy.Text;            // Luetaan syöte ikkunan korkeus
                ikkunanKorkeus = Int32.Parse(teksti2);

                teksti3 = textBox_Copy1.Text;           // Luetaan syöte karmipuun leveys
                karminLeveys = Int32.Parse(teksti3);

                ikkunanAla = ((double)ikkunanLeveys * (double)ikkunanKorkeus) / 10;     // Lasketaan ikkunan pinta-ala
                teksti4 = ikkunanAla.ToString();        // Muunnetaan tekstiksi 
                textBlock_Copy5.Text = teksti4 + " cm^2";   // Tulostetaan ikkunan pinta-ala

                lasinAla = (ikkunanKorkeus - (2 * karminLeveys)) * (ikkunanLeveys - (2 * karminLeveys)) / 10;    // Lasketaan lasin pinta-ala
                teksti5 = lasinAla.ToString();
                textBlock_Copy6.Text = teksti5 + " cm^2";   // Tulostetaan lasin pinta-ala

                karminPiiri = (2 * ikkunanLeveys + 2 * ikkunanKorkeus) / 10;            // Lasketaan karmin piiri
                teksti6 = karminPiiri.ToString();
                textBlock_Copy7.Text = teksti6 + " cm";     // Tulostetaan karmin piiri
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
