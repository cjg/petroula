<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MeteoControl.ascx.cs" Inherits="MeteoControl" %>
<%@ Register assembly="Microsoft.Live.ServerControls.VE" namespace="Microsoft.Live.ServerControls.VE" tagprefix="ve" %>
<ve:Map ID="MainMap" runat="server" Dashboard="False" FixedMap="True" 
    Height="400px" Locale="it_it" MapStyle="Aerial" MouseWheelZoomToCenter="False" 
    ScaleBarDistanceUnit="Kilometers" Width="400px" ZoomLevel="4" />
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
