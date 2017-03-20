/* **************************************
Tuntidemo, Thread-harjoitus.

Luotu 20.3.2017

Minttu Mäkäläinen K8517 @ JAMK 
************************************** */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;             // Säikeitä varten
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

namespace Labra_14___Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            InitializeMyStuff();
        }

        #region METHODS

        void InitializeMyStuff()
        {
            btnFire.IsEnabled = false;
        }

        void DoWork()
        {
            // Käynnistetään pitkäkestoinen tapahtuma
            Thread.Sleep(5000);
            UpdateMessageAsync("The work is done and the answer comes now!");
        }
        void UpdateMessage(string msg)
        {
            txtMessage.Text = msg;
        }

        void UpdateMessageAsync(string msg)
        {
            Action action = () =>
            {
                txtMessage.Text = msg;
                //btnFire.IsEnabled = false;
            };
            Dispatcher.BeginInvoke(action);
        }

        #endregion

        #region EVENTHANDLERS
        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            count++;
            UpdateMessage("Fire #" + count.ToString());
        }

        private void btnWork_Click(object sender, RoutedEventArgs e)
        {
            btnFire.IsEnabled = true;

            // V1: Normaalisti tämä toimisi, mutta metodin pitkän keston takia ei kerkeä päivittymään
            //UpdateMessage("A looong work started");
            //DoWork();

            // V2: Säikeeseen tehty
            UpdateMessageAsync("A looong work started");
            new Thread(DoWork).Start();
        }
        #endregion
    }
}
