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
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=this.CurrentSystemName %> 系统登录 </title>
    <script type="text/javascript" charset="utf-8" src="<%#Request.ApplicationPath %>/jquery-easyui/jquery-1.9.1.min.js"></script>
    <base target="_self" />
    <script type="text/javascript">
        <!--
         $(function() {
                $.ajax({
                    url: "<%#Request.ApplicationPath %>/projectHandler.ashx",
                    data: { "isview": true },
                    dataType: "json",
                    success: function(data) {
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
                                $("#login_ative").append(html);
                            });
                        }
                    }
                });
            });
        //-->
    </script>
</head>
<body style="text-align: center; font-size: 11pt; background-color: #afdf55; margin-top: 0px; margin-left: 0px; overflow: auto;">
    <div class="loginPanel">
        <div class="row1"></div>
        <div class="row2"></div>
        <div class="row3">
            <div class="row3_1"></div>
            <div class="row3_2"></div>
            <div class="row3_3"></div>
            <div class="row3_4"></div>
            <div class="row3_5"></div>
        </div>
        <div class="row4"></div>
        <div class="row5">
            <div class="row5_1"></div>
            <div class="row5_2">
                <div class="row5_2_1">
                    <strong>政策文件</strong>
                    <ul>
                        <li style="margin: 1px;">
                            <a target="_blank" href="<%#Request.ApplicationPath %>/downloads/困难教职工慰问帮扶工作实施方案.doc">
                                <span>困难教职工慰问帮扶工作实施方案</span>
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="row5_2_2">
                    <p>
                        <strong>补助活动</strong>
                        <p id="login_ative" style="overflow-y:auto;"></p>
                    </p>
                </div>
            </div>
            <div class="row5_3"></div>
        </div>
        <div class="row6"></div>
        <div class="row7">
            <div class="row7_1"></div>
            <div class="row7_2">
                <div>
                    <form id="form1" runat="server">
                        <JWC:ValidationSummaryEx ID="vsfrmLogin" runat="server" ShowMessageBox="true" ShowSummary="false" />
                        <p>
                            <strong>用户登录</strong>
                            <label class="common-font">帐号</label>
                            <JWC:TextBoxEx ID="txtLoginSign" runat="server" Width="128px"　IsRequired="true"  RequiredErrorMessage="账号不能为空！"/>
                            <label class="common-font">密码</label>
                            <JWC:TextBoxEx ID="txtLoginPassword" runat="server" TextMode="Password" Width="128px"　IsRequired="true"  RequiredErrorMessage="密码不能为空！"/>
                            <JWC:ButtonEx ID="btnLogin" runat="server" CausesValidation="true" Text="登录" OnClick="btnLogin_OnClick" />
                            <JWC:ServerAlert ID="errMsg" runat="server" />
                        </p>
                    </form>
                </div>
            </div>
            <div class="row7_3"></div>
        </div>
        <div class="row8">
            <p class="common-font">
                <%=this.CopyRight %>
                <br />
                建议使用1024*768以上的屏幕分辨率和6.0以上版本的IE来访问本站
            </p>
        </div>
    </div>
</body>
</html>