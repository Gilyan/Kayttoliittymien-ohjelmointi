/* **************************************
Tuntitehtäviä, WPF harjoittelua.

Luotu 11.2.2017

Toiminta: Kiukaan toiminta. Kiukaan lämpötilaa sekä sen kosteuden arvoja pitää voida muuttaa. 
Lämpötilan arvot on rajattava välille 0-120.00 ja kosteuden arvot välille 0-100.0. 
Toteuta Kiuas-luokka ja erillinen käyttöliittymä.

Vaatimuksia:

- Numero- ja pilkkupainikkeita painettaessa ko. arvo lisätään arvokenttään viimeiseksi (aloitustilanteessa nolla poistuu)
- Peruuta-painike poistaa arvokentästä viimeisen merkin, vihje: Substring(alku,pituus)
- Ok-painike muuttaa kiukaan Temperature- tai Humidity-arvoja, jos arvo on sallittu
- Yllä olevassa arvo muuttuu siihen kumpi säädöistä on valittu RadioButton-objekteissa (vihje: isChecked)
- Uusi muuttunut arvo näytetään keypadin vasemmalla puolella
- Virheellisistä säätöarvoista ilmoitetaan säätimien alla esim. TextBlock-objektin kautta
- Tyylittele objekteja Properties-ikkunan kautta (kokeile eri värejä, fontteja, yms...)

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

namespace Labra_10___Tehtava_4
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

        string teksti = "";

        Heater kiuas = new Heater();

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            teksti += "1";
            txbValue.Text = teksti;
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            teksti += "2";
            txbValue.Text = teksti;
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            teksti += "3";
            txbValue.Text = teksti;
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            teksti += "4";
            txbValue.Text = teksti;
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            teksti += "5";
            txbValue.Text = teksti;
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            teksti += "6";
            txbValue.Text = teksti;
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            teksti += "7";
            txbValue.Text = teksti;
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            teksti += "8";
            txbValue.Text = teksti;
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            teksti += "9";
            txbValue.Text = teksti;
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            teksti += "0";
            txbValue.Text = teksti;
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            teksti += ".";
            txbValue.Text = teksti;
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (teksti.Length > 0)
            { teksti = teksti.Substring(0, teksti.Length - 1); }
            txbValue.Text = teksti;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rdbTemperature.IsChecked == true)       // Lämpötila
                {
                    txbValue.Text = "";
                    kiuas.Temperature = Convert.ToDouble(teksti);
                    txbTemperature.Text = "Temperature:   " + kiuas.Temperature;
                    txbInfo.Text = kiuas.Info;
                    teksti = "";
                }


                else if (rdbHumidity.IsChecked == true)     // Kosteus
                {
                    txbValue.Text = "";
                    kiuas.Humidity = Convert.ToDouble(teksti);
                    txbHumidity.Text = "Humidity:   " + kiuas.Humidity;
                    txbInfo.Text = kiuas.Info;
                    teksti = "";
                }
            }

            catch (Exception ex)
            {
                txbInfo.Text = "Tarkista syöte! Arvoa ei muutettu.";
                teksti = "";
            }
        }
    }
}
