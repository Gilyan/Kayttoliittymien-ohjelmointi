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

        string[] ostokset = { "" };
        int i = 0;

        private void btnOsta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)chkSuklaa.IsChecked)
                {
                    ostokset[i] = "suklaa";
                    i++;
                }

                if ((bool)chkPitsa.IsChecked)
                {
                    ostokset[i] = "pitsa";
                    i++;
                }

                if ((bool)chkSidu.IsChecked)
                {
                    ostokset[i] = "siideri";
                    i++;
                }

                if ((bool)chkKana.IsChecked)
                {
                    ostokset[i] = "kana";
                    i++;
                }

                if ((bool)chkLimppa.IsChecked)
                {
                    ostokset[i] = "limppari";
                    i++;
                }

                for (int j = 0; j <= ostokset.Length; j++)
                {
                    Console.Write(ostokset[j] + ", ");
                }
            }

            catch (Exception ex)
            {
                txbFooter.Text = (ex.Message);
            }
        }
    }
}
