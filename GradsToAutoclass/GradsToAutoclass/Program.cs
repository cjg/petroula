using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using GradsSharp;

namespace GradsToAutoclass
{
    class Program
    {
        static void Main(string[] args)
        {
            int nvar = int.Parse(ConfigurationSettings.AppSettings["NVars"]);
            Grads g = Grads.GetInstance();
            DirectoryInfo root = new DirectoryInfo(ConfigurationSettings.AppSettings["CtlDirectory"]);
            StreamWriter sw = new StreamWriter(ConfigurationSettings.AppSettings["DB2Filename"]);
            foreach (System.IO.FileInfo f in root.GetFiles())
            {
                if (!f.Extension.Equals(".ctl"))
                    continue;
                try
                {
                    g.Open(f.FullName, Grads.FileType.CTL);
                }
                catch (Exception e)
                {
                    continue;
                }
                g.Lon.Start = 13.75;
                g.Lon.End = 14.7;
                g.Lat.Start = 40.5;
                g.Lat.End = 41;
                for (int t = 1; t < 25; t++)
                {
                    Console.WriteLine("T: " + t);
                    g.T.Value = t;
                    for (int i = 0; i < nvar; i++)
                    {
                        sw.Write(g.Amean(ConfigurationSettings.AppSettings["Var" + i]) + " ");
                    }
                    sw.WriteLine();
                }
            }
            sw.Close();
            Process p = new Process();
            p.StartInfo.FileName = ConfigurationSettings.AppSettings["AutoclassExe"];
            p.StartInfo.Arguments = "-search " + ConfigurationSettings.AppSettings["DB2Filename"] + " "
                + ConfigurationSettings.AppSettings["HD2Filename"] + " "
                + ConfigurationSettings.AppSettings["ModelFilename"] + " "
                + ConfigurationSettings.AppSettings["SParamsFilename"];
            p.Start();
            p.WaitForExit();
            Console.WriteLine(p.ExitCode);
            p.Start();
            p.WaitForExit();
            Console.WriteLine(p.ExitCode);
            p.Start();
            p.WaitForExit();
            Console.WriteLine(p.ExitCode);
            p = new Process();
            p.StartInfo.FileName = ConfigurationSettings.AppSettings["AutoclassExe"];
            p.StartInfo.Arguments = "-reports " + ConfigurationSettings.AppSettings["HD2Filename"].Replace(".hd2", ".results-bin") + " "
                + ConfigurationSettings.AppSettings["HD2Filename"].Replace(".hd2", ".search") + " "
                + ConfigurationSettings.AppSettings["RParamsFilename"];
            p.Start();
            p.WaitForExit();
            Console.WriteLine(p.ExitCode);
        }
    }
}
