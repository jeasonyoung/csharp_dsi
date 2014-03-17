<%--
//================================================================================
// FileName: frmDSIEmployeeUnitEdit.aspx
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
//================================================================================
//--%>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmDSIEmployeeUnitEdit.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIEmployeeUnitEdit" %>
<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <JWC:ValidationSummaryEx ID="vsfrmDSIEmployeeUnitEdit" runat="server" ShowMessageBox="true" ShowSummary="false" />
    <!--数据查询区域-->
    <div class="TableSearch">
        <div style="float: left;">
            <JWC:LabelEx ID="lbUnitName" runat="server" Style="float: left;" meta:resourcekey="DSI_UnitName">用户：</JWC:LabelEx>
            <JWC:PickerBase ID="pbEmployee" runat="server" Width="198px" MultiSelect="false" PickerPage="frmDSIEmployeePicker.aspx"
                PickerWidth="320px" PickerHeight="380px" AutoPostBack="true" OnTextChanged="pbEmployee_OnTextChanged" />
        </div>
    </div>
    <!--多选-->
    <asp:Panel ID="panelMultiSelect" runat="server" CssClass="TableSearch" Height="280px">
        <table cellpadding="1" cellspacing="1" border="0" style="width: 100%; height: 280px;">
            <tr>
                <td valign="top" width="50%">
                    <asp:ListBox ID="lbMulti" runat="server" Width="100%" Height="270px" SelectionMode="Multiple" />
                </td>
                <td width="80px">
                    <p align="center">
                        <JWC:ButtonEx ID="btnSelectAll" runat="server" OnClick="btnSelectAll_OnClick" CausesValidation="false" Text="&gt;&gt;" />
                    </p>
                    <p align="center">
                        <JWC:ButtonEx ID="btnSelect" runat="server" OnClick="btnSelect_OnClick" CausesValidation="false" Text="&gt;" />
                    </p>
                    <p align="center">
                        <JWC:ButtonEx ID="btnRemove" runat="server" OnClick="btnRemove_OnClick" CausesValidation="false" Text="&lt;" />
                    </p>
                    <p align="center">
                        <JWC:ButtonEx ID="btnRemoveAll" runat="server" OnClick="btnRemoveAll_OnClick" CausesValidation="false" Text="&lt;&lt;" />
                    </p>
                </td>
                <td valign="top" width="50%">
                    <asp:ListBox ID="lbSelect" runat="server" Width="100%" Height="270px" SelectionMode="Multiple" />
                </td>
            </tr>
        </table>
    </asp:Panel>  
    <!--数据控制区域-->
    <div class="TableControl">
        <div style="margin: 0 auto; text-align:center; width:100%;">
            <JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" OnClick="btnSave_Click" CausesValidation="true" ConfirmMsg="您确定保存数据？" ShowConfirmMsg="true" />
            <JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" BeforeClickScript='window.returnValue="";window.close();return false;' />
            <JWC:ServerAlert ID="errMessage" runat="server" />
        </div>
    </div>
</asp:Content>
