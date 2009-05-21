using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;

public class Grads
{
    private Process process;
    private object mutex;
    private string info;
    private Dimension x;
    private Dimension y;
    private Dimension z;
    private Dimension t;
    private Dimension lon;
    private Dimension lat;
    private Dimension lev;
    private StreamWriter log;

    private static Grads instance = null;

    private Grads()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        mutex = new object();
        process = new Process();
        log = new StreamWriter("C:\\Grads.txt", true);
        process.StartInfo.FileName = "C:\\grads-2.0.a2\\bin\\grads.exe";
        process.StartInfo.Arguments = "-lbu";
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.Start();
        CommandOutput co = new CommandOutput(process.StandardOutput);
        foreach (string s in co.OutputArray)
            log.WriteLine(s);
        info = co.Output;
        IssueCommand("set gxout print");
    }
    
    public string Info
    {
        get
        {
            return info;
        }
    }

    public Dimension X
    {
        get { return x; }
    }

    public Dimension Y
    {
        get { return y; }
    }

    public Dimension Z
    {
        get { return z; }
    }

    public Dimension T
    {
        get { return t; }
    }

    public Dimension Lon
    {
        get { return lon; }
    }
    
    public Dimension Lat
    {
        get { return lat; }
    }

    public Dimension Lev
    {
        get { return lev; }
    }

    public static Grads GetInstance()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        if (instance == null)
        {
            instance = new Grads();
            instance.Open("c:\\file\\file.ctl");
        }
        return instance;
    }

    public CommandOutput IssueCommand(string command)
    {
        lock(mutex) 
        {
            process.StandardInput.WriteLine(command);
            CommandOutput co = new CommandOutput(process.StandardOutput);
            log.WriteLine(">>> " + command);
            foreach (string s in co.OutputArray)
                log.WriteLine(s);
            log.Flush();
            return co;
        }
    }

    public void Open(string filename)
    {
        CommandOutput co = IssueCommand("open " + filename);
        if (co.ResultCode != 0)
            throw new Exception("Open Error");

        x = new Dimension("X", this);
        lon = new Dimension("Lon", this);
        x.DimensionChanged += lon.OnDimensionChanged;
        lon.DimensionChanged += x.OnDimensionChanged;

        y = new Dimension("Y", this);
        lat = new Dimension("Lat", this);
        y.DimensionChanged += lat.OnDimensionChanged;
        lat.DimensionChanged += y.OnDimensionChanged;

        z = new Dimension("Z", this);
        lev = new Dimension("Lev", this);
        z.DimensionChanged += lev.OnDimensionChanged;
        lev.DimensionChanged += z.OnDimensionChanged;

        t = new Dimension("T", this);
    }

    public double Amean(string var)
    {
        CommandOutput co1 = IssueCommand("set gxout c:\\output.txt");
        CommandOutput co = IssueCommand("display aave(" + var 
            + ", x=" + x.Start 
            + ", x=" + x.End
            + ", y=" + y.Start 
            + ", y=" + y.End + ")");
        if (co.ResultCode != 0)
            throw new Exception("Cannot compute the amean!");
        return 0;
    }
}