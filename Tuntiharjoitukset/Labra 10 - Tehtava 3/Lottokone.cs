/* **************************************
Tuntitehtäviä, WPF harjoittelua.

Luotu 11.2.2017

Toiminta: Toteuta sovellus, jolla voidaan arpoa lottorivejä. Lottokoneen tulee osata arpoa: Lotto-, 
Viking Lotto- ja Eurojackpot-rivejä haluttu määrä.

Minttu Mäkäläinen K8517 @ JAMK 
************************************** */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labra_10___Tehtava_3
{
    class Numero
    {
        public int Arvo { get; set; }

        Random rand = new Random();

        public int ArvoLotto()
        {
            int silmaluku = rand.Next(1, 40);       // Arvotaan numero väliltä 1-39
            return silmaluku;
        }

        public int ArvoVikingLotto()
        {
            int silmaluku = rand.Next(1, 49);        // Arvotaan numero väliltä 1-48
            return silmaluku;
        }

        public int ArvoEuroJackpot()
        {
            int silmaluku = rand.Next(1, 51);        // Arvotaan numero väliltä 1-50
            return silmaluku;
        }

        public int ArvoEuroJackpotTahti()
        {
            int silmaluku = rand.Next(1, 11);        // Arvotaan numero väliltä 1-10
            return silmaluku;
        }
    }
}