using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using GradsSharp;

namespace MeteoService
{
    public class Autoclass
    {
        private List<string> classes;
        private NameValueCollection appsettings;

        public Autoclass()
        {
            appsettings = System.Web.Configuration.WebConfigurationManager.AppSettings;
            
        }

        private string RandFilename(String prefix, String suffix)
        {
            string result;
            result = appsettings.Get("TempDirectory") + "\\";
            Random random = new Random();
            string randName = random.Next(1000000).ToString();
            result = result + prefix + "000000".Substring(6 - randName.Length) + randName + suffix;
            return result;
        }

        public string Classify(double lat, double lon, DateTime starttime, DateTime endtime)
        {
            Grads g = new Grads();
            g.Open(appsettings["CtlDirectory"], appsettings["CtlPrefix"], starttime);
            g.Lat.Start = lat - 0.1;
            g.Lat.End = lat + 0.1;
            g.Lon.Start = lon - 0.1;
            g.Lon.End = lon + 0.1;
            System.TimeSpan diff 
            DateTime midtime = starttime.A
            g.Time = starttime;
            int nvars = int.Parse(appsettings.Get("NVars"));
            string row = "";
            for (int i = 0; i < nvars; i++)
            {
                row += g.Amean(appsettings.Get("Var" + i)) + " ";
            }
            string filename = RandFilename("predict", ".db2");
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(row);
            sw.Close();
            Process p = new Process();
            p.StartInfo.FileName = appsettings.Get("AutoclassExe");
            p.StartInfo.Arguments = "-predict " +  filename + " "
                + appsettings.Get("RParamsFilename").Replace(".r-params", ".results-bin") + " "
                + appsettings.Get("RParamsFilename").Replace(".r-params", ".search") + " "
                + appsettings.Get("RParamsFilename");
            p.Start();
            p.WaitForExit();
            string outputfile = filename.Replace(".db2", ".class-data-1");
            StreamReader sr = new StreamReader(outputfile);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (!line.StartsWith("DATA_CLASS"))
                    continue;
                string class_name = line.Substring(line.IndexOf(' ') + 1);
                sr.Close();
                return class_name;
            }
            throw new Exception("Cannot classify lat: " + lat + " lon: " + lon);
        }
    }
}