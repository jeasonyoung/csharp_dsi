<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmDSIStaffPicker.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIStaffPicker" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="content" ContentPlaceHolderID="workPlace" runat="server">
<div class="easyui-layout" data-options="fit:true,border:false">
<JWC:ValidationSummaryEx id="vsfrmDSIEmployeePicker" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
    <!--查询条件-->
    <div class="TableSearch">
       <div style="float:left;">
            <JWC:LabelEx ID="lbUnitName" runat="server" Style="float:left;" meta:resourcekey="DSI_UnitName">所属单位：</JWC:LabelEx>
            <JWC:DropDownListEx ID="ddlUnit" runat="server" Width="128px" IsRequired="true" ErrorMessage="所属单位不能为空！" />
       </div>
       <div style="float:left;">
            <JWC:LabelEx ID="lbStaffName" runat="server" Style="float:left;" meta:resourcekey="DSI_StaffName">职工姓名：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtStaffName" runat="server" Width="68px" />
       </div>
       <div style="float:right;">
            <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" OnClick="btnSearch_OnClick" />
       </div>
    </div>
    <!--数据显示-->
    <div class="TableSearch">
         <asp:ListBox ID="listSingleSelect" runat="server" Width="100%" Height="250px" SelectionMode="Single" />
    </div>
    <!--数据控制区域-->
    <div class="TableControl">
	    <div style="margin:0 auto; text-align:center; width:100%;">
		    <JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="false"/>
		    <JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		    <JWC:ServerAlert ID="errMessage" runat="server" />
	    </div>
    </div>
</div>
</asp:Content>