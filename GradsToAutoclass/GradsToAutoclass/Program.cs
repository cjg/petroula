using System;
using System.Collections.Generic;
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
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: GradsToAutoclass filename.db2 var1 var2 ... varN path/to/ctl/file");
                return;
            }
            Grads g = Grads.GetInstance();
            string filename = args[0];
            string ctlpath = args[args.Length - 1];
            DirectoryInfo root = new DirectoryInfo(ctlpath);
            Console.WriteLine(ctlpath);
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
                    g.T.Value = t;
                    for (int i = 1; i < args.Length - 1; i++)
                    {
                        Console.Write(g.Amean(args[i]) + ",");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
