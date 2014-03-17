<%--
//================================================================================
// FileName: frmDSIEmployeeList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmDSIEmployeeList.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIEmployeeList" %>
<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIEmployeeList" runat="server" ShowMessageBox="true" ShowSummary="false" />

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
    <JWC:DataGridView ID="dgfrmDSIEmployeeList" runat="server" CssClass="DataGrid" Width="96%"
        ShowFooter="true" AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
        PageSize="11" OnBuildDataSource="dgfrmDSIEmployeeList_BuildDataSource">
        <PagerSettings Mode="NextPreviousFirstLast" />
        <AlternatingRowStyle CssClass="DataGridAlter" />
        <HeaderStyle CssClass="DataGridHeader" />
        <FooterStyle CssClass="DataGridFooter" />
        <RowStyle CssClass="DataGridItem" />
        <Columns>
            <JWC:BoundFieldEx DataField="EmployeeCode" HeaderText="�û�����" SortExpression="EmployeeCode"
                meta:resourcekey="DSI_EmployeeCode">
                <HeaderStyle Width="40%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
            
            <JWC:BoundFieldEx DataField="EmployeeName" HeaderText="�û���" SortExpression="EmployeeName" meta:resourcekey="DSI_EmployeeName">
                <HeaderStyle Width="60%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
            
        </Columns>
    </JWC:DataGridView>
</asp:Content>
