/* **************************************
Tuntitehtäviä, WPF harjoittelua.

Luotu 6.2.2017

Toiminta: Opiskelija on saanut itselleen unelma kesätyön vilkasliikenteisen kadun varrelta. 
Hänen tulee laskea ohi menevät henkilö- ja kuorma-autot. Laadi opiskelijalle sovellus, jolla 
hän voi laskea helposti ohi menneet autot. Painikkeita painettaessa ko. kulkuneuvon osoittama 
lukumäärä kasvaa yhdellä.

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

namespace Labra_9___Tehtava_1
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

        int i = 0, j = 0;
        string teksti;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            i++;
            teksti = i.ToString();
            textBlock.Text = teksti;
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            j++;
            teksti = j.ToString();
            textBlock_Copy.Text = teksti;
        }
        private void Grid_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }
    }
}
