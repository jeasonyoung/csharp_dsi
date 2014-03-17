﻿<%@ Control Language="C#" AutoEventWireup="true" Inherits="Yaesoft.DSI.Web.TopBanner" %>
<%@ Import Namespace="iPower.Platform.Engine.Persistence"%>

<div style="float:left; width:100%;">
    <div class="TopBannerMenu">
        <%
            TopBannerMenuCollection collection = this.TopBannerMenus;
            for (int i = 0; i < collection.Count; i++)
            {
                TopBannerMenu menu = collection[i];
                if (menu != null)
                {
                    if (i == 0)
                    {                  
                        %>
                        <div class="TopBannerMenuLeft">
                            <span><a href="<%=menu.Url%>" target="<%=menu.Target %>" title="<%=menu.Name%>"><%=menu.Name%></a></span>
                        </div>
                        <%
                    }
                    else
                    {
                         %>
                        <div class="TopBannerMenuMain">
                            <span><a href="<%=menu.Url%>" target="<%=menu.Target %>" title="<%=menu.Name%>"><%=menu.Name%></a></span>
                        </div>
                        <%
                    }
                }
            } 
         %>
    </div>
</div>
<div style="float:left; margin-left:15px; width:435px; height:40px; border:solid 0px red; background-image:url('<%#Request.ApplicationPath %>/Include/DSIBanner.png')">
</div>
<div class="UserInfo">
    <div class="UserInfoIcon"><br /></div>
    <div class="UserInfoMain">
        <%if(this.CurrentUserID.IsValid){%>
        <span>欢迎您：<%=this.CurrentUserName %>！</span>
        <%} %>
    </div>
    <div class="UserInfoDate">
        <span style="float:left;"><%=DateTime.Now.ToString("yyyy年MM月dd日") %></span>
        <span style="float:right;"><%=System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek)%></span>
    </div>
</div>