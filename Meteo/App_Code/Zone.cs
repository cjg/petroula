using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Microsoft.Live.ServerControls.VE;

/// <summary>
/// Descrizione di riepilogo per Zone
/// </summary>
public class Zone
{
    private string name;
    private LatLong center;
    private int zoomlevel;
    private List<LatLong> points;
    private static Hashtable zonelist;
    
    public Zone(string name, LatLong center, int zoomlevel, List<LatLong> points)
	{
        this.name = name;
        this.center = center;
        this.zoomlevel = zoomlevel;
        this.points = points;
    }

    public string Name
    {
        get { return name; }
    }

    public LatLong Center
    {
        get { return center; }
    }

    public int ZoomLevel
    {
        get { return zoomlevel; }
    }

    public List<LatLong> Points
    {
        get { return points; }
    }

    public static Hashtable ZoneList
    {
        get
        {
            if (zonelist == null)
                InitZoneList();
            return zonelist;
        }
    }

    private static void InitZoneList()
    {
        zonelist = new Hashtable();
        NameValueCollection appsettings = System.Web.Configuration.WebConfigurationManager.AppSettings;
        int nzones = int.Parse(appsettings.Get("NZones"));
        for (int i = 0; i < nzones; i++)
        {
            string name = appsettings.Get("Zone" + i + "Name");
            double lat = double.Parse(appsettings.Get("Zone" + i + "Lat"));
            double lon = double.Parse(appsettings.Get("Zone" + i + "Lon"));
            int zoomlevel = int.Parse(appsettings.Get("Zone" + i + "Zoomlevel"));
            int npoints = int.Parse(appsettings.Get("Zone" + i + "NPoints"));
            List<LatLong> points = new List<LatLong>();
            for (int j = 0; j < npoints; j++)
            {
                double plat = double.Parse(appsettings.Get("Zone" + i + "Point" + j + "Lat"));
                double plon = double.Parse(appsettings.Get("Zone" + i + "Point" + j + "Lon"));
                points.Add(new LatLong(plat, plon));
            }
            zonelist.Add(name, new Zone(name, new LatLong(lat, lon), zoomlevel, points));
        }
    }
}
