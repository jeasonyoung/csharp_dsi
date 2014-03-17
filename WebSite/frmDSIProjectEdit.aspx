<%--
//================================================================================
//  FileName: frmDSIProjectEdit.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-11
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
--%>
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSIProjectEdit.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIProjectEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.Upload" tagprefix="JWC" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIProjectEdit" runat="server" ShowMessageBox="true" ShowSummary="false" />
<div class="easyui-layout" data-options="fit:true,border:false">
    <div data-options="region:'center',border:false">
        <div class="TableSearch" style="overflow:auto;">
            <div style="float: left; width:96%">
                <JWC:LabelEx ID="lbProjectName" runat="server" Style="float:left;" meta:resourcekey="DSI_ProjectName">申报项目名称：</JWC:LabelEx>
                <JWC:TextBoxEx ID="txtProjectName" runat="server" Width="468px" IsRequired="true" RequiredErrorMessage="申报项目名称不能为空！" />
            </div>
            
            <div style="float: left; width:96%">
                <div style="float:left;border:solid 0px red;">
                    <JWC:LabelEx ID="lbStartTime" runat="server" Style="float: left;" meta:resourcekey="DSI_StartTime">申报开始时间：</JWC:LabelEx>
                    <JWC:TextBoxCalendar ID="txtStartTime" runat="server" Width="168px" IsRequired="true" ErrorMessage="申报开始时间不能为空！" />
                </div>
                
                <div style="float:left; margin-left:56px; border:solid 0px red;">
                    <JWC:LabelEx ID="lbEndTime" runat="server" Style="float: left;" meta:resourcekey="DSI_EndTime">申报结束时间：</JWC:LabelEx>
                    <JWC:TextBoxCalendar ID="txtEndTime" runat="server" Width="168px" IsRequired="true" ErrorMessage="申报结束时间不能为空！" />
                </div>
            </div>
            
            <div style="float: left; width:96%">
                <fieldset>
                   <legend style="color:#ccc;">附件上传</legend>
                   <JWC:UploadView ID="uploadAttachments" runat="server" Width="98%" MaxUploadSize="10" MaxUploadCount="10" DownloadBaseURI="AccessoriesDownload.ashx?FileID=" AllowOfficeOnlineEdit="false" OnUploadViewExceptionEvent="uploadAttachments_OnUploadViewExceptionEvent" />
                </fieldset>
            </div>
            
            <div style="float: left; width:96%">
                <JWC:LabelEx ID="lbIsView" runat="server" Style="float:left;" meta:resourcekey="DSI_IsView">是否在首页显示：</JWC:LabelEx>
                <JWC:RadioButtonListEx ID="rdIsView" runat="server" RepeatDirection="Horizontal" IsRequired="true" ErrorMessage="是否在首页显示必须选择！">
                    <asp:ListItem Text="是" Value="1" Selected="True" />
                    <asp:ListItem Text="否" Value="0" />
                </JWC:RadioButtonListEx>
            </div>
            
            <div style="float: left; width:96%">
                <JWC:LabelEx ID="lbContent" runat="server" Style="float:left;" meta:resourcekey="DSI_Content">项目内容描述：</JWC:LabelEx>
                <JWC:TextBoxEx ID="txtContent" runat="server" Width="468px" TextMode="MultiLine" Rows="8" />
            </div>
        </div>
    </div>
    <div data-options="region:'south',border:true" style="height:40px;">
        <div style="margin:0 auto; margin-top:2px; text-align:center; width:98%; background-color:#f5f5f5;">
			<JWC:ServerAlert ID="errMessage" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
 			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" RightSpace="2" beforeclickscript='window.returnValue="";window.close();return false;' />  
    	</div>		
    </div>
</div>
</asp:Content>