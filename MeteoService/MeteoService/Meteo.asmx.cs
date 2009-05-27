using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Services;
using GradsSharp;

namespace MeteoService
{
    /// <summary>
    /// Descrizione di riepilogo per Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
    // [System.Web.Script.Services.ScriptService]
    public class Meteo : System.Web.Services.WebService
    {
        /*
        [WebMethod]
        public string ForecastClass(double lat, double lon, DateTime starttime, DateTime endtime)
        {
            Autoclass a = new Autoclass();
            result[i] = a.Classify(y_point[i], x_point[i]);
            return result;
        }
        */

        [WebMethod]
        public double Temperature(double lat, double lon, DateTime starttime, DateTime endtime)
        {
            Grads g = new Grads();
            NameValueCollection appsettings = System.Web.Configuration.WebConfigurationManager.AppSettings;
            g.Open(appsettings["CtlDirectory"], appsettings["CtlPrefix"], starttime);
            g.Lat.Start = lat - 0.1;
            g.Lat.End = lat + 0.1;
            g.Lon.Start = lon - 0.1;
            g.Lon.End = lon + 0.1;
            g.Time = starttime;
            double mean = 0;
            int t = endtime.Subtract(starttime).Hours;
            for (int i = 0; i < t; i++)
            {
                mean += g.Amean("tc");
                g.T.Value += 1;
            }
            return mean;
        }
    }
}
