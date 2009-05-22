using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GradsLibrary;

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
            for (int i = 1; i < args.Length - 1; i++)
            {
            }
        }
    }
}
