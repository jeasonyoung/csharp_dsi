<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSIEduSetBaseAdminEdit.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIEduSetBaseAdminEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="ContentworkPlace" ContentPlaceHolderID="workPlace" runat="server">
<div class="easyui-layout" data-options="fit:true,border:false">
    <JWC:ValidationSummaryEx id="vsfrmDSIEduSetBaseAdminEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
    <!--查询条件-->
    <div class="TableSearch">
       <div style="float:left;">
            <JWC:LabelEx ID="lbUnitName" runat="server" Style="float:left;" meta:resourcekey="DSI_UnitName">基层工会单位：</JWC:LabelEx>
            <JWC:DropDownListEx ID="ddlUnit" runat="server" Width="168px" ShowUnDefine="true" />
       </div>
       <div style="float:left;">
            <JWC:LabelEx ID="lbStaffName" runat="server" Style="float:left;" meta:resourcekey="DSI_StaffName">教职工姓名：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtStaffName" runat="server" Width="128px" />
       </div>
       <div style="float:right;">
            <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" OnClick="btnSearch_OnClick" />
       </div>
    </div>
    <!--数据显示-->
    <div class="TableSearch">
         <asp:ListBox ID="listStaffSelect" runat="server" Width="100%" Height="260px" SelectionMode="Single" />
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