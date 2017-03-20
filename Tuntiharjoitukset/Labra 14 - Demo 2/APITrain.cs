/* **************************************
Tuntidemo, tiedon hakua internetistä, VR-junien aikatauluja.

Käytössä Newtonsoft.Json
Tiedot: https://rata.digitraffic.fi/api/v1/live-trains?station=JY

Luotu 20.3.2017

Minttu Mäkäläinen K8517 @ JAMK 
************************************** */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;           // Selain
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public class API
    {
        public static string GetJsonFromLiikenneVirasto(string filter)
        {
            try
            {
                string url = "";
                url = @"https://rata.digitraffic.fi/api/v1/live-trains?station=" + filter;
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString(url);
                    return json;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
