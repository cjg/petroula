using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Live.ServerControls.VE;

public partial class MeteoControl : System.Web.UI.UserControl
{
    public enum DayEnum { Today, Tomorrow };
    public enum TimeSlotEnum { ZeroSix, SixTwelve, TwelveEighteen, EighteenZero };
    public enum MeteoTypeEnum { Forecast, Temperature };
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["Day"] = DayEnum.Today;
            Session["TimeSlot"] = TimeSlotEnum.ZeroSix;
            Session["MeteoType"] = MeteoTypeEnum.Forecast;
            Session["Zone"] = "Campania";
            MainMap.Width = new Unit(600, UnitType.Pixel);
            MainMap.Height = new Unit(700, UnitType.Pixel);
            Update();
        }
    }

    public Unit Width 
    {
        get { return MainMap.Width; }
        set { MainMap.Width = value; }
    }

    public Unit Height
    {
        get { return MainMap.Height; }
        set { MainMap.Height = value; }
    }

    public int ZoomLevel
    {
        get { return MainMap.ZoomLevel; }
        set { MainMap.ZoomLevel = value; }
    }

    public LatLong BottomLeftLatLong
    {
        get { return MainMap.MapView.BottomLeftLatLong; }
        set { try { MainMap.MapView.BottomLeftLatLong = value; } catch (System.Exception e) { } }
    }

    public DayEnum Day
    {
        get { return (DayEnum) Session["Day"]; }
        set { Session["Day"] = value; }
    }

    public TimeSlotEnum TimeSlot
    {
        get { return (TimeSlotEnum) Session["TimeSlot"]; }
        set { Session["TimeSlot"] = value; }
    }

    public MeteoTypeEnum MeteoType
    {
        get { return (MeteoTypeEnum)Session["MeteoType"]; }
        set 
        { 
            Session["MeteoType"] = value;
            Update();
        }
    }

    public string CurrentZone
    {
        get { return (string) Session["Zone"]; }
        set 
        { 
            Session["Zone"] = value;
            Update();
        }
    }

    private void Update()
    {
        localhost.Meteo m = new localhost.Meteo();
        Zone z = (Zone) Zone.ZoneList[Session["Zone"]];
        MainMap.Center = z.Center;
        MainMap.ZoomLevel = z.ZoomLevel;
        foreach (LatLong p in z.Points)
        {
            Shape s = new Shape(ShapeType.Pushpin, new LatLongWithAltitude(p.Latitude, p.Longitude));
            if ((MeteoTypeEnum) Session["MeteoType"] == MeteoTypeEnum.Temperature)
                s.Description = m.Temperature(p.Latitude, p.Longitude).ToString();
            MainMap.AddShape(s);
        }
    }
}
