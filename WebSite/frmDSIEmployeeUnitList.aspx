<%--
//================================================================================
// FileName: frmDSIEmployeeUnitList.aspx
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmDSIEmployeeUnitList.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIEmployeeUnitList" %>
<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIEmployeeUnitList" runat="server" ShowMessageBox="true" ShowSummary="false" />

    <!--����-->
    <div class="TitleBar">
        <div style="float:left;">
            <span style="float: left;  margin-right:5px">
                <JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmDSIEmployeeUnitEdit.aspx" PickerType="Modal" PickerWidth="600px" PickerHeight="400px" OnClick="btnAdd_Click" />
            </span>
        </div>
    </div>
    <!--��ѯ����-->
    <asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
        <div style="float: left;">
            <JWC:LabelEx ID="lbEmployeeName" runat="server" Style="float: left;" meta:resourcekey="DSI_EmployeeName">�û�����</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtEmployeeName" runat="server" Width="168px" />
        </div>
        <div style="float: right;">
            <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" OnClick="btnSearch_Click" />
            <JWC:ServerAlert ID="errMessage" runat="server" />
        </div>
    </asp:Panel>
    <!--������ʾ����-->
    <JWC:DataGridView ID="dgfrmDSIEmployeeUnitList" runat="server" CssClass="DataGrid"
        Width="96%" ShowFooter="true" AllowSorting="true" AllowPaging="true" AllowExport="false"
        MouseoverCssClass="DataGridHighLight" PageSize="11" OnBuildDataSource="dgfrmDSIEmployeeUnitList_BuildDataSource">
        <PagerSettings Mode="NextPreviousFirstLast" />
        <AlternatingRowStyle CssClass="DataGridAlter" />
        <HeaderStyle CssClass="DataGridHeader" />
        <FooterStyle CssClass="DataGridFooter" />
        <RowStyle CssClass="DataGridItem" />
        <Columns>
            <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="600px" WinHeight="400px"
                DataNavigateUrlFormatString="frmDSIEmployeeUnitEdit.aspx?EmployeeID={0}" DataNavigateUrlField="EmployeeID"
                HeaderText="�û���" DataField="EmployeeName" SortExpression="EmployeeName" meta:resourcekey="DSI_EmployeeName">
                <HeaderStyle Width="20%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:MultiQueryStringFieldEx>
            
            <JWC:BoundFieldEx DataField="UnitName" HeaderText="������λ" SortExpression="UnitName" meta:resourcekey="DSI_UnitNames">
                <HeaderStyle Width="80%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
        </Columns>
    </JWC:DataGridView>
</asp:Content>
