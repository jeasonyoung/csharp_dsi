<%@ Control Language="C#" AutoEventWireup="true" Inherits="Yaesoft.DSI.Web.LeftMenu" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.OutlookView" tagprefix="JWC" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.TreeView" tagprefix="JWC" %>

<JWC:OutlookView ID="tvMenuOutlook" Width="100%" runat="server" ShowScrollBar="true" Visible="false" />
<JWC:TreeView ID="tvMenuTree" Width="100%" runat="server" ShowScrollBar="true" Visible="true" />