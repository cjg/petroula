using System;
using System.Collections.Generic;
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

        [WebMethod]
        public double[] Temperatures(double x1, double y1, double x2, double y2, double[] x_point, double[] y_point)
        {
            Grads g = Grads.GetInstance();
            double[] t = new double[x_point.Length];
            for(int i = 0; i < x_point.Length; i++)
            {
                g.Lat.Start = y_point[i] - 0.1;
                g.Lat.End = y_point[i] + 0.1;
                g.Lon.Start = x_point[i] - 0.1;
                g.Lon.End = x_point[i] + 0.1;
                t[i] = g.Amean("tc");
            }
            return t;
        }

        [WebMethod]
        public string[] Classes(double[] x_point, double[] y_point)
        {
            string[] result = new string[x_point.Length];
            Autoclass a = new Autoclass();
            for (int i = 0; i < x_point.Length; i++)
                result[i] = a.Classify(y_point[i], x_point[i]);
            return result;
        }

        [WebMethod]
        public double Temperature(double lat, double lon)
        {
            Grads g = Grads.GetInstance();
            g.Lat.Start = lat - 0.1;
            g.Lat.End = lat + 0.1;
            g.Lon.Start = lon - 0.1;
            g.Lon.End = lon + 0.1;
            return g.Amean("tc");
        }
    }
}
