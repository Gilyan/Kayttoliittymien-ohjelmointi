/* **************************************
Tuntiharjoitus, tehty yhdessä opettajan kanssa.
Harjoitellaan piirtämistä.

Luotu 8.2.2017

Toiminta: 

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

namespace Labra_10___tuntiharjoitus_2
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

        private void btnDrawPolyline_Click(object sender, RoutedEventArgs e)
        {
            // Määritellään polyline
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Colors.CadetBlue;
            Polyline pl = new Polyline();   // Luodaan olio pl
            pl.Stroke = scb;                // Kiinnitetään harja polylineen
            pl.StrokeThickness = 3;         // Viivan leveys
            myGrid.Children.Add(pl);        // Lisätään polyline-olio gridin lapseksi

            Random rnd = new Random();
            PointCollection myPoints = new PointCollection();
            int x, y;
            for (int i = 0; i < 100; i++)
            {
                x = rnd.Next((int)this.Width);
                y = rnd.Next((int)this.Height);
                myPoints.Add(new Point(x, y));
            }
            pl.Points = myPoints;
        }
    }
}
