using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Live.ServerControls.VE;

public partial class Meteo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.Session.Add("day", "Oggi");
            Page.Session.Add("hour", "0-6");
            Page.Session.Add("type", "Previsioni");
            foreach (string s in Zone.ZoneList.Keys)
            {
                ZoneDropDownList.Items.Add(s);
            }
            UpdateLabel();
        }
    }

    private void UpdateLabel()
    {
        Label1.Text = Page.Session["day"] + " " + Page.Session["hour"] + " " + Page.Session["type"];
    }
    protected void TomorrowLinkButton_Click(object sender, EventArgs e)
    {
        Page.Session["day"] = "Domani";
        MeteoControl1.Day = MeteoControl.DayEnum.Today;
        UpdateLabel();
    }
    protected void TodayLinkButton_Click(object sender, EventArgs e)
    {
        Page.Session["day"] = "Oggi";
        MeteoControl1.Day = MeteoControl.DayEnum.Tomorrow;
        UpdateLabel();
    }
    protected void Hour1LinkButton_Click(object sender, EventArgs e)
    {
        Page.Session["hour"] = "0-6";
        MeteoControl1.TimeSlot = MeteoControl.TimeSlotEnum.ZeroSix;
        UpdateLabel();
    }
    protected void Hour2LinkButton_Click(object sender, EventArgs e)
    {
        Page.Session["hour"] = "6-12";
        MeteoControl1.TimeSlot = MeteoControl.TimeSlotEnum.SixTwelve;
        UpdateLabel();
    }
    protected void Hour3LinkButton_Click(object sender, EventArgs e)
    {
        Page.Session["hour"] = "12-18";
        MeteoControl1.TimeSlot = MeteoControl.TimeSlotEnum.TwelveEighteen;
        UpdateLabel();
    }
    protected void Hour4LinkButton_Click(object sender, EventArgs e)
    {
        Page.Session["hour"] = "18-24";
        MeteoControl1.TimeSlot = MeteoControl.TimeSlotEnum.EighteenZero;
        UpdateLabel();
    }
    protected void ForecastLinkButton_Click(object sender, EventArgs e)
    {
        Page.Session["type"] = "Previsioni";
        MeteoControl1.MeteoType = MeteoControl.MeteoTypeEnum.Forecast;
        UpdateLabel();
    }
    protected void TemperatureLinkButton_Click(object sender, EventArgs e)
    {
        Page.Session["type"] = "Temperature";
        MeteoControl1.MeteoType = MeteoControl.MeteoTypeEnum.Temperature;
        UpdateLabel();
    }
    protected void ZoneDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        MeteoControl1.CurrentZone = ZoneDropDownList.SelectedItem.Text;
    }
}
