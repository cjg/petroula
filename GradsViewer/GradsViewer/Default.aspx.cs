using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controls;
using Subgurim.Helpers;
using Subgurim.Controles;
using Subgurim.Web;

namespace GradsViewer
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GMap1.Language = "it";
            GMap1.addControl(new GControl(GControl.preBuilt.GOverviewMapControl));

            GMap1.addControl(new GControl(GControl.preBuilt.LargeMapControl));

        }

        protected string GMap1_Click(object s, GAjaxServerEventArgs e)
        {
            return default(string);
        }

        protected string GMap1_MoveEnd(object s, GAjaxServerEventArgs e)
        {
            Label1.Text = GMap1.
            return "";
        }

        protected string GMap1_DragEnd(object s, GAjaxServerEventArgs e)
        {
            GMarker marker = new GMarker(e.point);
            GInfoWindow window = new GInfoWindow(marker, "DragEnd - " + DateTime.Now.ToString(), false);
            return window.ToString(e.map);
        }

        protected string GMap1_ZoomEnd(object s, GAjaxServerEventZoomArgs e)
        {
            return string.Format("alert('oldLevel/newLevel: {0}/{1} - {2}')", e.oldLevel, e.newLevel, DateTime.Now);
        }
    }
}
