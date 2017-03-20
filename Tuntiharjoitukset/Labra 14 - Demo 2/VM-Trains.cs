/* **************************************
Tuntidemo, tiedon hakua internetistä, VR-junien aikatauluja.

Käytössä Newtonsoft.Json
Tiedot: https://rata.digitraffic.fi/api/v1/live-trains?station=JY

Luotu 20.3.2017

Minttu Mäkäläinen K8517 @ JAMK 
************************************** */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public class TrainsVM
    {
        public static List<Train> GetTrainsAt(string station)
        {
            try
            {
                List<Train> trains = new List<Train>();
                if (station == "testi" || station == "")
                {
                    // Vaihe 1: Placebo palauttaa oikean muotoista dataa
                    // Keksitään juna
                    Train tr = new Train();
                    tr.TrainNumber = "9 3/4";
                    tr.DepartureDate = new DateTime(2017, 3, 21);
                    tr.TargetStation = "Hogwarts";
                    trains.Add(tr);
                }

                else
                {
                    // Vaihe 2: Muutetaan haettu json olio-kokoelmaksi
                    string tmp = JAMK.IT.API.GetJsonFromLiikenneVirasto(station);
                    trains = JsonConvert.DeserializeObject<List<Train>>(tmp);       // Muuttaa listaksi
                }

                // Palautus
                return trains;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
