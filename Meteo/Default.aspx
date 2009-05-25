<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="Microsoft.Live.ServerControls.VE" namespace="Microsoft.Live.ServerControls.VE" tagprefix="ve" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table>
        <tr>
        <td>
            <ve:Map ID="Map1" runat="server" Height="400px" Width="400px" ZoomLevel="4" 
                Center-Latitude="40.7" Center-Longitude="14.2" />
            </td>
            <td>
            <table>
            <tr><td></td><td>
                <asp:Button ID="ButtonUp" runat="server" Text="Su" onclick="ButtonUp_Click" />
                </td><td></td></tr>
            <tr><td>
                <asp:Button ID="ButtonLeft" runat="server" Text="Button" 
                    onclick="ButtonLeft_Click" />
                </td><td>
                <table>
                <tr><td>
                    <asp:Button ID="ButtonZoomIn" runat="server" onclick="ButtonZoomIn_Click" 
                        Text="Button" />
                    </td></tr>
                <tr><td>
                    <asp:Button ID="ButtonZoomOut" runat="server" onclick="ButtonZoomOut_Click" 
                        Text="Button" />
                    </td></tr>
                </table>
                </td><td>
                <asp:Button ID="ButtonRight" runat="server" Text="Button" 
                        onclick="ButtonRight_Click" />
                </td></tr>
            <tr><td></td><td>
                <asp:Button ID="ButtonDown" runat="server" Text="Button" 
                    onclick="ButtonDown_Click" />
                </td><td></td></tr>
            </table>
            </td>
</tr>
</table>    
    
    </div>
    </form>
</body>
</html>
