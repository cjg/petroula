using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Live.ServerControls.VE;
using localhost;

public partial class _Default : System.Web.UI.Page
{
    private static double[] x = { 
                                        0,
                                        -0.297607002371418,
                                        -1.703288153764671,
                                        -3.175013515031178,
                                        -2.866871545548562,
                                        0.053217838271977,
                                        3.634558581136567,
                                        3.730624842299918
                                    };
    private static double[] y = {
                                        0,
                                        1.093912280250265,
                                        1.536712651335402,
                                        0.310040657707528,
                                        -2.161503606848974,
                                        -3.560418707125007,
                                        -1.348685241445069,
                                        4.122493475847812
                                    };
    private static double xsize = 6.9056;
    private static double ysize = 6.2839;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Map1.Center = new LatLong(40.75, 14.2);
        //Map1.ZoomLevel = 8;
        //DrawPoints();
    }

    protected void ButtonZoomIn_Click(object sender, EventArgs e)
    {
        Map1.ZoomLevel = Map1.ZoomLevel + 1;
        DrawPoints();
    }
    protected void ButtonZoomOut_Click(object sender, EventArgs e)
    {
        Map1.ZoomLevel = Map1.ZoomLevel - 1;
        DrawPoints();
    }
    protected void ButtonUp_Click(object sender, EventArgs e)
    {
        Map1.Center = new LatLong(Map1.Center.Latitude + Math.Abs(Map1.MapView.TopLeftLatLong.Latitude - Map1.MapView.BottomRightLatLong.Latitude) / 2, Map1.Center.Longitude);
        DrawPoints();
    }
    protected void ButtonRight_Click(object sender, EventArgs e)
    {
        Map1.Center = new LatLong(Map1.Center.Latitude, Map1.Center.Longitude + Math.Abs(Map1.MapView.TopLeftLatLong.Longitude - Map1.MapView.BottomRightLatLong.Longitude) / 2);
        DrawPoints();
    }
    protected void ButtonLeft_Click(object sender, EventArgs e)
    {
        Map1.Center = new LatLong(Map1.Center.Latitude, Map1.Center.Longitude - Math.Abs(Map1.MapView.TopLeftLatLong.Longitude - Map1.MapView.BottomRightLatLong.Longitude) / 2);
        DrawPoints();
    }
    protected void ButtonDown_Click(object sender, EventArgs e)
    {
        Map1.Center = new LatLong(Map1.Center.Latitude - Math.Abs(Map1.MapView.TopLeftLatLong.Latitude - Map1.MapView.BottomRightLatLong.Latitude) / 2, Map1.Center.Longitude);
        DrawPoints();
    }
    private void DrawPoints()
    {
        Map1.DeleteAllShapes();
        double xscale = Math.Abs(Map1.MapView.TopLeftLatLong.Longitude - Map1.MapView.BottomRightLatLong.Longitude) / xsize;
        double yscale = Math.Abs(Map1.MapView.TopLeftLatLong.Latitude - Map1.MapView.BottomRightLatLong.Latitude) / ysize;
        double[] x_points = new double[x.Length];
        double[] y_points = new double[x.Length];
        for (int i = 0; i < x.Length; i++)
        {
            x_points[i] = Map1.Center.Longitude + x[i] * xscale;
            y_points[i] = Map1.Center.Latitude + y[i] * yscale;
        }
        Meteo m = new Meteo();
        string[] c = m.Classes(x_points, y_points);
        for (int i = 0; i < c.Length; i++)
        {
            Shape s = new Shape(ShapeType.Pushpin, new LatLongWithAltitude(y_points[i], x_points[i]));
            s.Description = c[i];
            Map1.AddShape(s);
        }
        /*
        double[] t = m.Temperatures(Map1.MapView.TopLeftLatLong.Longitude, Map1.MapView.TopLeftLatLong.Latitude,
            Map1.MapView.BottomRightLatLong.Longitude, Map1.MapView.BottomRightLatLong.Latitude, x_points, y_points);
        for (int i = 0; i < t.Length; i++)
        {
            Shape s = new Shape(ShapeType.Pushpin, new LatLongWithAltitude(y_points[i], x_points[i]));
            s.Description = t[i].ToString();
            Map1.AddShape(s);
        }
         */
    }

}
