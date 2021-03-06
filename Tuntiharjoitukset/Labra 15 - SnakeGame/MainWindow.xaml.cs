﻿/* **************************************
Tuntidemo, yhdessä tehty matopeli.

* Canvas
* DrawSnake
  - liikkuminen
* Game Over
* DrawBonus
  - omenoita
* Pistelaskuri
* Törmäystarkastelu
  - reunoihin
  - itseensä
  - omenoihin

Luotu 22.3.2017

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

namespace Labra_15___SnakeGame
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Game gameWindow = new Game();
            gameWindow.Show();
        }
    }
}
