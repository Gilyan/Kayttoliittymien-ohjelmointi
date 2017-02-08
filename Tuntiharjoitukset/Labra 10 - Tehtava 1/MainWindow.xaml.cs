/* **************************************
Tuntitehtäviä, WPF harjoittelua.

Luotu 8.2.2017

Toiminta: Tee sovellus, jossa voidaan valita useita eri lajikkeita CheckBox-kontrollien kautta. 
Lopuksi valitut lajikkeet tulostetaan TextBox-kontrolliin, kun Buy Button-kontrollia painetaan.

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

namespace Labra_10___Tehtava_1
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

        private void btnOsta_Click(object sender, RoutedEventArgs e)
        {
            List<string> ostokset = new List<string>();     // Lista ostoksille

            try
            {
                if ((bool)chkSuklaa.IsChecked)          // Tarkistetaan, mitä kaikkea on valittu
                {
                    ostokset.Add("suklaa");
                }

                if ((bool)chkPitsa.IsChecked)
                {
                    ostokset.Add("pitsa");
                }

                if ((bool)chkSidu.IsChecked)
                {
                    ostokset.Add("siideri");
                }

                if ((bool)chkKana.IsChecked)
                {
                    ostokset.Add("kanafilee");
                }

                if ((bool)chkLimppa.IsChecked)
                {
                    ostokset.Add("limppari");
                }

                foreach (string k in ostokset)
                {
                    txbKooste.Text = string.Join(", ", ostokset);   // Tulostetaan valitut tuotteet textboxiin
                }

                if (ostokset.Count != 0)
                {
                    txbFooter.Text = "Valitut tuotteet lisätty";    // Muutetaan footerin teksti
                }
            }

            catch (Exception ex)
            {
                txbFooter.Text = (ex.Message);
            }
        }
    }
}
