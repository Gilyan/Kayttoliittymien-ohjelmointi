/* **************************************
Tuntitehtäviä, WPF harjoittelua.

Luotu 8.2.2017

Toiminta: Toteuta sovellus, jolla voidaan arpoa lottorivejä. Lottokoneen tulee osata arpoa: Lotto-, 
Viking Lotto- ja Eurojackpot-rivejä haluttu määrä. Pidetään sovittuna seuraavia määritteitä eri lotoille:

Lotto: suurin numero 39 ja arvotaan 7 numeroa riviin
Viking Lotto: suurin numero 48 ja arvotaan 6 numeroa riviin 
Eurojackpot: suurin numero 50 ja arvotaan 5 numeroa ja 2 tähtinumeroa riviin (tähtinumero välillä 1-10)

Vaatimukset:
- Toteuta valittava lottomuoto käyttämällä ComboBox-kontrollia
- Kysy arvottavien rivien määrä käyttämällä TextBox-kontrollia
- Näytä arvotut rivit TextBlock-kontrollissa (mahdollista sisällön skrollaus)
- Arvonta suoritetaan Draw-painikkeella ja arvottujen rivien poistaminen on mahdollista

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

namespace Labra_10___Tehtava_3
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

        int maara = 0, numero = 0, r = 1, i = 0, h = 0;
        string rivi, tulosta;

        Numero number = new Numero();
        List<int> numerot = new List<int>();            // Lista numeroille
        List<string> rivit = new List<string>();        // Lista lottoriveille

        private void btnNollaa_Click(object sender, RoutedEventArgs e)          // Nollaa kaikki arvot
        {
            txtRivit.Text = "";
            txbArvotutRivit.Text = "";
            numerot = new List<int>();
            rivit = new List<string>();
            rivi = "";
            tulosta = "";
        }

        private void btnArvoNumerot_Click(object sender, RoutedEventArgs e)     // Arpoo valittujen valintojen mukaan numeroita
        {
            maara = Int32.Parse(txtRivit.Text);             // Kuinka monta riviä lottoa halutaan

            if (cmbValikko.Text == "Lotto")                 // Lotto: suurin numero 39 ja arvotaan 7 numeroa riviin
            {
                while (r <= maara)                          // Tehdään niin monta riviä, kuin on haluttu
                {
                    while (i < 7)                           // Arvotaan 7 numeroa
                    {
                        numero = number.ArvoLotto();

                        if (!numerot.Contains(numero))      // Jos arvottu numero ei vielä löydy taulukosta
                        {
                            numerot.Add(numero);            // Lisätään numero listaan
                            i++;
                        }

                        rivi = "Rivi " + r + " : ";
                        foreach (int nro in numerot)
                        {
                            rivi += nro + "  ";
                        }
                        rivi = rivi + "\n";
                    }
                    numerot = new List<int>();              // Alustetaan numerolista
                    i = 0;                                  // Nollataan numerolaskuri
                    rivit.Add(rivi);                        // Lisätään rivi listaan
                    r++;
                }

                foreach (string line in rivit)
                {
                    tulosta += line;
                }
                txbArvotutRivit.Text = tulosta;
                r = 1;
            }

            else if (cmbValikko.Text == "Euro Jackpot")     // Eurojackpot: suurin numero 50 ja arvotaan 5 numeroa ja 2 tähtinumeroa (1-10) riviin
            {
                while (r <= maara)                          // Tehdään niin monta riviä, kuin on haluttu
                {
                    while (i < 5)                           // Arvotaan 5 numeroa
                    {
                        numero = number.ArvoEuroJackpot();

                        if (!numerot.Contains(numero))      // Jos arvottu numero ei vielä löydy taulukosta
                        {
                            numerot.Add(numero);            // Lisätään numero listaan
                            i++;
                        }

                        rivi = "Rivi " + r + " : ";
                        foreach (int nro in numerot)
                        {
                            rivi += nro + "  ";
                        }
                        rivi = rivi + "\n";
                    }

                    while (h < 2)                           // Arvotaan 2 tähtinumeroa
                    {
                        numero = number.ArvoEuroJackpotTahti();

                        if (!numerot.Contains(numero))      // Jos arvottu numero ei vielä löydy taulukosta
                        {
                            numerot.Add(numero);            // Lisätään numero listaan
                            h++;
                        }

                        rivi = "Rivi " + r + " : ";
                        foreach (int nro in numerot)
                        {
                            rivi += nro + "  ";
                        }
                        rivi = rivi + "\n";
                    }

                    numerot = new List<int>();              // Alustetaan numerolista
                    i = 0;
                    h = 0;                                  // Nollataan numerolaskurit
                    rivit.Add(rivi);                        // Lisätään rivi listaan
                    r++;
                }

                foreach (string line in rivit)
                {
                    tulosta += line;
                }
                txbArvotutRivit.Text = tulosta;
                r = 1;
            }

            else if (cmbValikko.Text == "Viking Lotto")     // Viking Lotto: suurin numero 48 ja arvotaan 6 numeroa riviin
            {
                while (r <= maara)                          // Tehdään niin monta riviä, kuin on haluttu
                {
                    while (i < 6)                           // Arvotaan 6 numeroa
                    {
                        numero = number.ArvoVikingLotto();

                        if (!numerot.Contains(numero))      // Jos arvottu numero ei vielä löydy taulukosta
                        {
                            numerot.Add(numero);            // Lisätään numero listaan
                            i++;
                        }

                        rivi = "Rivi " + r + " : ";
                        foreach (int nro in numerot)
                        {
                            rivi += nro + "  ";
                        }
                        rivi = rivi + "\n";
                    }
                    numerot = new List<int>();              // Alustetaan numerolista
                    i = 0;                                  // Nollataan numerolaskuri
                    rivit.Add(rivi);                        // Lisätään rivi listaan
                    r++;
                }

                foreach (string line in rivit)
                {
                    tulosta += line;
                }
                txbArvotutRivit.Text = tulosta;
                r = 1;
            }
        }
    }
}