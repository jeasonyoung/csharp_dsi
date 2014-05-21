<%@ Control Language="C#" AutoEventWireup="true" Inherits="Yaesoft.DSI.Web.TopBanner" %>
<%@ Import Namespace="iPower.Platform.Engine.Persistence"%>
<div>
    <ul>
     <%
        TopBannerMenuCollection collection = this.TopBannerMenus;
        for (int i = 0; i < collection.Count; i++)
        {
            TopBannerMenu menu = collection[i];
            if (menu != null)
            {%>
             <li>
                 <%if(i > 0) {%>
                    <span>|</span>
                 <%} %>
                 <a href="<%=menu.Url%>" target="<%=menu.Target %>" title="<%=menu.Name%>"><%=menu.Name%></a>
             </li>
             <%}
        } 
        %>
       </ul>
</div>