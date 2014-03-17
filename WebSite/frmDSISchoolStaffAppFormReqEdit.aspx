<%--
//================================================================================
//  FileName: frmDSISchoolStaffAppFormReqEdit.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-14
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSISchoolStaffAppFormReqEdit.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSISchoolStaffAppFormReqEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register TagPrefix="JWC" TagName="UCStaffReq" Src="UCStaffReq.ascx" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSISchoolStaffAppFormReqEdit" runat="server" ShowMessageBox="true" ShowSummary="false" />

<div class="easyui-layout" data-options="fit:true,border:false">
    <div class="easyui-layout" data-options="region:'center',border:false">
        <div data-options="region:'north',border:false" style="height:32px;background:#E0ECFF;">
            <div style="float:left;margin-top:2px;margin-left:10px; border:solid 0px red;">
                 <JWC:LabelEx ID="lbProjectName" runat="server" Style="float:left; margin-top:7px; font-weight:bold;" meta:resourcekey="DSI_ProjectName">申报项目名称：</JWC:LabelEx>
                 <JWC:DropDownListEx ID="ddlProject" runat="server" Width="438px" ShowUnDefine="true" IsRequired="true" ErrorMessage="申报项目名称不能为空！" />
            </div>
            <div style="float:left;margin-top:5px;margin-left:10px; border:solid 0px red;">
                 <JWC:LabelEx ID="lbStaffName" runat="server" Style="float:left; margin-top:7px; font-weight:bold;" meta:resourcekey="DSI_StaffName">教职工姓名：</JWC:LabelEx>
                  <JWC:PickerBase ID="pbStaff" runat="server" ToolTip="请点击输入框后的圆圈图标在弹出界面中选择职工档案！" Width="198px" MultiSelect="false" PickerPage="frmDSIStaffPicker.aspx?isAll=false" PickerWidth="460px" PickerHeight="380px" 
                    AutoPostBack="true" OnTextChanged="pbStaff_OnTextChanged" IsRequired="true" ErrorMessage="教职工姓名不能为空！" />
            </div>
        </div>
        <div data-options="region:'center',border:false">
            <JWC:UCStaffReq ID="ucStaffReq" runat="server" />
        </div>
    </div>
    <div data-options="region:'south',border:true" style="height:32px;">
        <div style="margin:0 auto; margin-top:2px; text-align:center; width:100%; background-color:#f5f5f5;">
			<JWC:ServerAlert ID="errMessage" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" Text="[申报补助]" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定申报补助？" ShowConfirmMsg="true"/>
    	</div>		
    </div>
</div>
</asp:Content>