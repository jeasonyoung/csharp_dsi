<%--
//================================================================================
//  FileName: frmDSIPersonalStaffList.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-1
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSIPersonalStaffList.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIPersonalStaffList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register TagPrefix="JWC" TagName="UCStaffInfo" Src="UCStaffInfo.ascx" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIPersonalStaffList" runat="server" ShowMessageBox="true" ShowSummary="false" />
<div class="easyui-layout" data-options="fit:true,border:false">
    <div data-options="region:'center',border:false">
       <JWC:UCStaffInfo ID="ucStaffInfo" runat="server" />
    </div>
    <div data-options="region:'south',border:true" style="height:32px;">
        <div style="margin:0 auto; margin-top:2px; text-align:center; width:100%; background-color:#f5f5f5;">
			<JWC:ServerAlert ID="errMessage" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>            
    	</div>		
    </div>
</div>
</asp:Content>