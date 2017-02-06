/* **************************************
Tuntitehtäviä, WPF harjoittelua.

Luotu 6.2.2017

Toiminta: Ohjelma, jolla voidaan muuttaa euroja markoiksi ja päinvastoin. 
Pyöristä raha-arvot tulostuksessa siten, että käytössä on vain kahden desimaalin tarkkuus.

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

namespace Labra_9___Tehtava_2
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
        double euro = 5.94573;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            double muunnaMarkka = 0, markka = 0;
            string teksti;
            try
            {
                teksti = muunnaMarkoiksi.Text;
                muunnaMarkka = Convert.ToDouble(teksti);
                markka = muunnaMarkka * euro;

                teksti = markka.ToString("0.00");
                muunnettuMarkka.Text = teksti;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            double muunnaEuro = 0, eurot = 0;
            string teksti;
            try
            {
                teksti = muunnaEuroiksi.Text;
                muunnaEuro = Convert.ToDouble(teksti);
                eurot = muunnaEuro / euro;

                teksti = eurot.ToString("0.00");
                muunnettuEuro.Text = teksti;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
