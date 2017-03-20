/* **************************************
Tuntidemo, tiedon hakua internetistä, VR-junien aikatauluja.

Käytössä Newtonsoft.Json
Tiedot: https://rata.digitraffic.fi/api/v1/live-trains?station=JY

Luotu 20.3.2017

Minttu Mäkäläinen K8517 @ JAMK 
************************************** */

using Newtonsoft.Json;
using System;

namespace JAMK.IT
{
    public class Train
    {
        public string TrainNumber { get; set; }
        [JsonProperty("cancelled")]
        public bool IsCancelled { get; set; }
        [JsonProperty("departureDate")]
        public DateTime DepartureDate { get; set; }
        public string TargetStation { get; set; }
    }

    public class Station
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public Station(string koodi, string ap)
        {
            this.Code = koodi;      // Asemapaikan tunniste JY = Jyväskylä
            this.Name = ap;         // Asemapaikan nimi
        }
    }
}
