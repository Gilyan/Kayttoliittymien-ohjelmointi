
/* **************************************
Tuntitehtäviä, WPF harjoittelua.

Luotu 12.2.2017

Toiminta: Kiukaan toiminta. Kiukaan lämpötilaa sekä sen kosteuden arvoja pitää voida muuttaa. 
Lämpötilan arvot on rajattava välille 0-120.00 ja kosteuden arvot välille 0-100.0. 
Toteuta Kiuas-luokka ja erillinen käyttöliittymä.

Minttu Mäkäläinen K8517 @ JAMK 
************************************** */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labra_10___Tehtava_4
{
    class Heater
    {
        double lampotila, kosteus;

        double maxTemp = 120.00, maxHum = 100.00;

        public string Info { get; set; }

        public double Temperature           // Lämpötila voi olla välillä 0-120.00
        {  
            get { return lampotila; }
            set
            {
                lampotila = value;
                if (lampotila > maxTemp)
                {
                    lampotila = maxTemp;
                    Info = "Liian suuri arvo, asetettu maksimiarvo (120)";
                }
                else { Info = "Arvo asetettu"; }
            }
        }

        public double Humidity              // Kosteus voi olla välillä 0-100.0
        {
            get { return kosteus; }
            set
            {
                kosteus = value;
                if (kosteus > maxHum)
                {
                    kosteus = maxHum;
                    Info = "Liian suuri arvo, asetettu maksimiarvo (100)";
                }
                else { Info = "Arvo asetettu"; }
            }
        }
    }
}
