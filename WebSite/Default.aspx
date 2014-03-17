<%--
//================================================================================
//  FileName: Default.aspx
//  Desc:用户默认首页。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/7
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Yaesoft.DSI.Web._Default" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <link rel="stylesheet" href="<%#Request.ApplicationPath %>/jquery-slides/font-awesome.min.css" type="text/css"/>
    <link rel="stylesheet" href="<%#Request.ApplicationPath %>/jquery-slides/slides.css" type="text/css"/>
    <script type="text/javascript" charset="utf-8" src="<%#Request.ApplicationPath %>/jquery-slides/js/jquery.slides.min.js"></script>
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
    <!--滚动文本-->
    <fieldset style="float:left; margin-top:15px; margin-left:60px; width:600px; height:380px;">
        <legend style="font-weight:bold;">工会活动</legend>
        <div id="slides" style="padding-top:5px; padding-left:2px;"></div>
    </fieldset>
</asp:Content>