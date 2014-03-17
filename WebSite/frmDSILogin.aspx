<%--
//================================================================================
//  FileName: frmDSILogin.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/6
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
//--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDSILogin.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSILogin" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head id="Head1" runat="server">
        <title><%=this.CurrentSystemName %> 系统登录 </title>
        <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
        <link rel="stylesheet" href="~/jquery-easyui/themes/icon.css" type="text/css"/>
	    <link rel="stylesheet" href="~/jquery-easyui/themes/default/easyui.css" type="text/css"/>
	    <link rel="stylesheet" href="~/jquery-slides/font-awesome.min.css" type="text/css"/>
	    
	    <link rel="stylesheet" href="~/jquery-slides/slides.css" type="text/css"/>
	    
	    <script type="text/javascript" charset="utf-8" src="<%#Request.ApplicationPath %>/jquery-easyui/jquery-1.9.1.min.js"></script>
    	
	    <script type="text/javascript" charset="utf-8" src="<%#Request.ApplicationPath %>/jquery-easyui/jquery.easyui.min.js"></script>
	    <script type="text/javascript" charset="utf-8" src="<%#Request.ApplicationPath %>/jquery-easyui/locale/easyui-lang-zh_CN.js"></script>
	    
	    <script type="text/javascript" charset="utf-8" src="<%#Request.ApplicationPath %>/jquery-slides/js/jquery.slides.min.js"></script>
        
        <base target="_self" />
        <style type="text/css">
            span a{ color:#fff; }
        </style>
        
        <script type="text/javascript">
        <!--
            $(function() {
                $.ajax({
                    url: "<%#Request.ApplicationPath %>/projectHandler.ashx",
                    data: { "isview": true },
                    dataType: "json",
                    success: function(data) {
                        $("#slides").empty();
                        if (data && $.isArray(data)) {
                            $.each(data, function(i, item) {
                                var html = "<div>";
                                html += "<h1>" + item.ProjectName + "</h1>";
                                html += "<h5>申报起止日期：" + item.StartTime.substring(0, 10) + " 至 " + item.EndTime.substring(0, 10) + "</h5>";
                                html += "<p>" + item.Content + "</p>";
                                if (item.Attachments && $.isArray(item.Attachments) && item.Attachments.length > 0) {
                                    html += "<ul style='margin-top:10px;'>";
                                    html += "<span>附件下载：</span>";
                                    $.each(item.Attachments, function(j, attach) {
                                        html += "<li style='margin:2px;'><a target='_blank' href='<%#Request.ApplicationPath %>/AccessoriesDownload.ashx?FileID=" + attach.ID + "'>";
                                        html += "<span>" + attach.Name + "</span>";
                                        html += "</a></li>";
                                    });
                                    html += "</ul>";
                                }
                                if (item.IsActive) {
                                    html += "<p style='margin:10px;font-size:10pt;font-weight:bold;'>";
                                    html += "<a target='_self' href='<%#Request.ApplicationPath %>/frmDSIPersonalStaffAppFormReqList.aspx?ProjectID=" + item.ProjectID + "'><span style='color:red;'>[我要申报]</span></a>";
                                    html += "</p>";
                                }
                                html += "</div>";
                                $("#slides").append(html);
                            });
                            //
                            $("#slides").slidesjs({
                                navigation: false
                            });
                        }
                    }
                });
            });
        //-->
        </script>
    </head>
    <body class="easyui-layout">
        <div data-options="region:'center',border:false">
             <div class="easyui-window" title=" " data-options="modal:true,collapsible:false,minimizable:false,maximizable:false,closable:false,draggable:false,resizable:false,border:false" style="width:1020px;height:570px;">
               <div style="float:left;width:1003px;height:532px;background:url(Include/login.jpg);">
                    <div style="float:left; width:350px; border:solid 0px red;"> 
                        <!---公示信息-->
                        <fieldset style="float:left;margin-top:50px; margin-left:45px;font-weight:bold;border:solid 1px #aaa;">
                           <legend>政策文件</legend>
                           <div style="float:left; width:268px; height:250px;">
                              <ul style="margin-top:10px; font-size:10.5pt;">
                                <li style="margin:1px;"><a target="_blank" href="<%#Request.ApplicationPath %>/downloads/困难教职工慰问帮扶工作实施方案.doc"><span>困难教职工慰问帮扶工作实施方案</span> </a></li>
                              </ul>
                           </div>
                        </fieldset> 
                        <!--用户登录框-->
                        <form id="form1" runat="server">
                        <JWC:ValidationSummaryEx id="vsfrmLogin" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
                        <fieldset style="float:left; margin-left:45px; margin-top:20px; width:268px; border:solid 1px #aaa;">
                            <legend style="font-weight:bold;">用户登录</legend>
                            <div style="float:left; margin-top:5px; width:100%;">
                                <asp:Label ID="lbLoginSin" runat="server" meta:resourcekey="DSI_LoginSin">城域网账号：</asp:Label>
                                <JWC:TextBoxEx ID="txtLoginSign" runat="server" Width="168px"　IsRequired="true"  RequiredErrorMessage="用户账号不能为空！"/>
                            </div>
                            
                            <div style="float:left;margin-top:5px; width:100%;">
                                <asp:Label ID="lbLoginPassword" runat="server" meta:resourcekey="DSI_LoginPassword">城域网密码：</asp:Label>
                                <JWC:TextBoxEx ID="txtLoginPassword" runat="server" TextMode="Password" Width="168px"　IsRequired="true"  RequiredErrorMessage="用户密码不能为空！"/>
                            </div>
                            
                            <div style="float:left;margin-top:5px;width:100%;">
                                <div style="float:right; margin-right:20px; margin-bottom:5px;">
                                    <JWC:ButtonEx ID="btnLogin" runat="server" CausesValidation="true" ButtonType="Login" OnClick="btnLogin_OnClick" />
                                    <JWC:ServerAlert ID="errMsg" runat="server" />
                                </div>
                            </div>
                        </fieldset>
                        </form>
                    </div>
                    <!--滚动文本-->
                    <fieldset style="float:left; margin-top:75px; margin-left:15px; width:600px; height:370px;border:solid 1px #aaa;">
                        <legend style="font-weight:bold;">工会活动</legend>
                        <div id="slides" style="padding-top:5px; padding-left:2px;"></div>
                    </fieldset>
                    <!--版权信息-->
                    <div style="float:left;width:100%; margin-top:12px;">
                        <span style="float:right; margin-right:5px; font-size:9pt;color:#fff;"><%=this.CopyRight %></span>
                    </div>
               </div>
             </div>
        </div>
        
        //
    </body>
</html>