<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Meteo.aspx.cs" Inherits="Meteo" %>

<%@ Register src="MeteoControl.ascx" tagname="MeteoControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr><td>
        <!-- giorni -->
        <table>
        <tr><td>
            <asp:LinkButton ID="TodayLinkButton" runat="server" 
                onclick="TodayLinkButton_Click">Oggi</asp:LinkButton>
            </td><td>
                <asp:LinkButton ID="TomorrowLinkButton" runat="server" 
                    onclick="TomorrowLinkButton_Click">Domani</asp:LinkButton>
            </td></tr>
        </table>
    </td></tr>
    <tr><td>
        <!-- fasce orarie -->
        <table>
        <tr><td>
            <asp:LinkButton ID="Hour1LinkButton" runat="server" 
                onclick="Hour1LinkButton_Click">0-6</asp:LinkButton>
            </td><td>
                <asp:LinkButton ID="Hour2LinkButton" runat="server" 
                    onclick="Hour2LinkButton_Click">6-12</asp:LinkButton>
            </td><td>
                <asp:LinkButton ID="Hour3LinkButton" runat="server" 
                    onclick="Hour3LinkButton_Click">12-18</asp:LinkButton>
            </td><td>
                <asp:LinkButton ID="Hour4LinkButton" runat="server" 
                    onclick="Hour4LinkButton_Click">18-24</asp:LinkButton>
            </td></tr>
        </table>
    </td></tr>
    <tr><td>
        <!-- meteo -->
        <table>
        <tr><td>
            <!-- menu mappa -->
            <table>
            <tr><td>
                <asp:LinkButton ID="ForecastLinkButton" runat="server" 
                    onclick="ForecastLinkButton_Click">Previsioni</asp:LinkButton>
                </td></tr>
            <tr><td>
                <asp:LinkButton ID="TemperatureLinkButton" runat="server" 
                    onclick="TemperatureLinkButton_Click">Temperature</asp:LinkButton>
                </td></tr>
            </table>
        </td>
        <td>
            <!-- mappa -->
            <table>
            <tr><td>Zona:
                <asp:DropDownList ID="ZoneDropDownList" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ZoneDropDownList_SelectedIndexChanged">
                </asp:DropDownList>
                </td></tr>
            <tr><td>
            <uc1:MeteoControl ID="MeteoControl1" runat="server" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td></tr>
            </table>
        </td>
        <td>
            <!-- varie -->
        </td>
        </tr>
        </table>
    </td></tr>
    </table>
    </div>
    </form>
</body>
</html>

