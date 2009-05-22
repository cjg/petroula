<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GradsViewer._Default" %>

<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
      <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=ABQIAAAAAx4pfnvDdvKDoXJCeVihGhT2yXp_ZAY8_ufC3CFXhHIE1NvwkxTkqH0Reu4sOZLGfYZq22SEelRbmQ&sensor=true_or_false" type="text/javascript"></script> 
    <script type="text/javascript"> 
    function initialize() {
     if (GBrowserIsCompatible()){
      var map = new GMap2(document.getElementById("map_canvas")); 
      map.setCenter(new GLatLng(40.85, 14.22), 17);
      map.setUIToDefault(); 
      }
    } 
     </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <cc1:GMap ID="GMap1" runat="server" 
            
                Key="ABQIAAAAAx4pfnvDdvKDoXJCeVihGhT2yXp_ZAY8_ufC3CFXhHIE1NvwkxTkqH0Reu4sOZLGfYZq22SEelRbmQ" 
                enableServerEvents="True" onclick="GMap1_Click" OnZoomEnd="GMap1_ZoomEnd" 
                OnDragEnd="GMap1_DragEnd" OnMoveEnd="GMap1_MoveEnd" />

    </div>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
