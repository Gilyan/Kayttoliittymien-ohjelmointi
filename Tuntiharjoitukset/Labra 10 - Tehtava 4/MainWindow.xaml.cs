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
    }
}
