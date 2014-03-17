<%--
//================================================================================
//  FileName: frmDSISchoolAudit.aspx
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSISchoolAudit.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSISchoolAudit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSISchoolAudit" runat="server" ShowMessageBox="true" ShowSummary="false" />
<style type="text/css">
.Audit
{
    border-left:0px;
    border-right:0px;
    border-top:0px;
}
</style>
<div class="easyui-layout" data-options="fit:true,border:false">
    <div data-options="region:'center',border:false">
        <fieldset style="float:left; margin-top:10px; margin-left:2px; width:96%;">
            <legend>基础工会意见</legend>
            <div style="float:left; width:96%;">
                <JWC:LabelEx ID="lbPrimaryAllowance" runat="server" Style="float:left; margin-top:7px;" meta:resourcekey="DSI_PrimaryAllowance">拟申请补助金额：</JWC:LabelEx>
                <JWC:RadioButtonListEx ID="rdPrimaryAllowance" runat="server" RepeatDirection="Vertical" RepeatColumns="3" IsRequired="true" ErrorMessage="拟申请补助金额不能空选！">
                    <asp:ListItem Text="800元" Value="800" />
                    <asp:ListItem Text="1000元" Value="1000" />
                    <asp:ListItem Text="2000元" Value="2000" />
                    <asp:ListItem Text="3000元" Value="3000" />
                    <asp:ListItem Text="4000元" Value="4000" />
                    <asp:ListItem Text="5000元" Value="5000" />
                    <asp:ListItem Text="6000元" Value="6000" />
                    <asp:ListItem Text="8000元" Value="8000" />
                    <asp:ListItem Text="10000元" Value="10000" />
                </JWC:RadioButtonListEx>
            </div>
            <div style="float:left; width:96%;">
                <JWC:LabelEx ID="lbAuditStatus" runat="server" Style="float:left;margin-top:7px; margin-left:36px;" meta:resourcekey="DSI_AuditStatus">审核结果：</JWC:LabelEx>
                <JWC:RadioButtonListEx ID="rdAuditStatus" runat="server" RepeatDirection="Horizontal" IsRequired="true" ErrorMessage="请选择审核结果！">
                    <asp:ListItem Text="初审通过" Value="1" />
                    <asp:ListItem Text="初审未通过" Value="-1" />
                </JWC:RadioButtonListEx>
            </div>
            <div style="float:left; width:96%;">
                <JWC:LabelEx ID="lbPrimaryAudit" runat="server" Style="float:left;margin-top:6px; margin-left:48px;" meta:resourcekey="DSI_PrimaryAudit">审核人：</JWC:LabelEx>
                <JWC:TextBoxEx ID="txtPrimaryAudit" runat="server" Width="128px" CssClass="Audit" ReadOnly="true" />
            </div>
            <div style="float:left; width:96%;">
                <div style="float:right;margin-right:20px;">
                    <JWC:TextBoxEx ID="txtPrimaryAuditTime" runat="server" Width="100px" CssClass="Audit" ReadOnly="true" />
                </div>
            </div>
        </fieldset>
    </div>
    <div data-options="region:'south',border:true" style="height:32px;">
        <div style="margin:0 auto; margin-top:2px; text-align:center; width:100%; background-color:#f5f5f5;">
			<JWC:ServerAlert ID="errMessage" runat="server" />
			<JWC:ButtonEx ID="btnApproval" runat="server" ButtonType="Approval" onclick="btnApproval_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true"/>
 			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" RightSpace="2" beforeclickscript='window.returnValue="";window.close();return false;' />  
    	</div>		
    </div>
</div>
</asp:Content>