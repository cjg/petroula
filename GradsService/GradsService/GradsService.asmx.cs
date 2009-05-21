using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace GradsService
{
    /// <summary>
    /// Descrizione di riepilogo per GradsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
    // [System.Web.Script.Services.ScriptService]
    public class GradsService : System.Web.Services.WebService
    {

        [WebMethod]
        public string Info()
        {
            return Grads.GetInstance().Info;
        }

        [WebMethod]
        public void Open(string filename)
        {
            Grads.GetInstance().Open(filename);
        }

        [WebMethod]
        public string X()
        {
            return Grads.GetInstance().X.ToString();
        }

        [WebMethod]
        public string Lon()
        {
            return Grads.GetInstance().Lon.ToString();
        }

        [WebMethod]
        public void SetLon(double start, double end)
        {
            Grads g = Grads.GetInstance();
            g.Lon.Start = start;
            g.Lon.End = end;
        }

        [WebMethod]
        public string Amean()
        {
            Grads g = Grads.GetInstance();
            g.Lon.Start = 13.75;
            g.Lon.End = 14.7;
            g.Lat.Start = 40.5;
            g.Lat.End = 41;
            return "Amean: " + g.Amean("clflo");
        }
    }
}
