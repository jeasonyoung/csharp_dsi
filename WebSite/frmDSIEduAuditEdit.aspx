<%--
//================================================================================
//  FileName: frmDSIEduAuditEdit.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-19
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSIEduAuditEdit.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIEduAuditEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register TagPrefix="JWC" TagName="UCStaffReq" Src="UCStaffReq.ascx" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIEduAuditEdit" runat="server" ShowMessageBox="true" ShowSummary="false" />
<div class="easyui-layout" data-options="fit:true,border:false">
    <div data-options="region:'center',border:false">
        <JWC:UCStaffReq ID="ucStaffReq" runat="server" />
    </div>
    <div data-options="region:'south',border:true" style="height:32px;">
        <div style="margin:0 auto; margin-top:2px; text-align:center; width:100%; background-color:#f5f5f5;">
			<JWC:ServerAlert ID="errMessage" runat="server" />
			<a title="打印教职工申报明细" target="_blank" href='frmDSIStaffAppFormReqPrint.aspx?StaffID=<%=this.StaffID%>&ProjectID=<%=this.ProjectID %>'>[打印]</a>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" RightSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
    	</div>		
    </div>
</div>
</asp:Content>