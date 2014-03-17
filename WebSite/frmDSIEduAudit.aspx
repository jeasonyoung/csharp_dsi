<%--
//================================================================================
//  FileName: frmDSIEduAudit.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-20
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSIEduAudit.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIEduAudit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIEduAudit" runat="server" ShowMessageBox="true" ShowSummary="false" />
<div class="easyui-layout" data-options="fit:true,border:false">
    <div data-options="region:'center',border:false">
        <fieldset style="float:left; margin-top:10px; margin-left:2px; width:96%;">
            <legend>终审意见</legend>
            <div style="float:left; width:96%;">
                <JWC:LabelEx ID="lbCommitteeAllowance" runat="server" Style="float:left;margin-top:6px; margin-left:20px;" meta:resourcekey="DSI_CommitteeAllowance">审查委员会意见：</JWC:LabelEx>
                <span style="float:left; margin-top:4px; margin-left:5px; padding-right:3px;color:#aaa;">拟补助</span>
                <JWC:TextBoxEx ID="txtCommitteeAllowance" runat="server" Width="128px" OnlyNumber="true" IsRequired="true" RequiredErrorMessage="审查委员会意见不能为空！"/>
            </div>
            <div style="float:left; width:96%;">
                <JWC:LabelEx ID="lbLeadershipAllowance" runat="server" Style="float:left;margin-top:6px; margin-left:32px;" meta:resourcekey="DSI_LeadershipAllowance">主管领导意见：</JWC:LabelEx>
                <span style="float:left; margin-top:4px; margin-left:5px; padding-right:3px;color:#aaa;">拟补助</span>
                <JWC:TextBoxEx ID="txtLeadershipAllowance" runat="server" Width="128px" OnlyNumber="true" IsRequired="true" RequiredErrorMessage="主管领导意见不能为空！"/>
            </div>
            <div style="float:left; width:96%;">
                <JWC:LabelEx ID="lbFinalAllowance" runat="server" Style="float:left;margin-top:6px; margin-left:32px;" meta:resourcekey="DSI_FinalAllowance">总负责人意见：</JWC:LabelEx>
                <span style="float:left; margin-top:4px; margin-left:5px; padding-right:3px;color:#aaa;">拟补助</span>
                <JWC:TextBoxEx ID="txtFinalAllowance" runat="server" Width="128px" OnlyNumber="true" IsRequired="true" RequiredErrorMessage="总负责人意见不能为空！"/>
            </div>
            <div style="float:left; width:96%;">
                <JWC:LabelEx ID="lbAuditStatus" runat="server" Style="float:left;margin-top:7px; margin-left:36px;" meta:resourcekey="DSI_AuditStatus">审核结果：</JWC:LabelEx>
                <JWC:RadioButtonListEx ID="rdAuditStatus" runat="server" RepeatDirection="Horizontal" IsRequired="true" ErrorMessage="请选择审核结果！">
                    <asp:ListItem Text="终审通过" Value="2" />
                    <asp:ListItem Text="终审未通过" Value="-2" />
                </JWC:RadioButtonListEx>
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