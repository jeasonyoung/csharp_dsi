<%--
//================================================================================
// FileName: frmDSIEmployeeList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmDSIEmployeeList.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIEmployeeList" %>
<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIEmployeeList" runat="server" ShowMessageBox="true" ShowSummary="false" />

    <!--查询区域-->
    <asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
        <div style="float: left;">
            <JWC:LabelEx ID="lbEmployeeName" runat="server" Style="float: left;" meta:resourcekey="DSI_EmployeeName">用户名：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtEmployeeName" runat="server" Width="168px" />
        </div>
        <div style="float: right;">
            <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" OnClick="btnSearch_Click" />
            <JWC:ServerAlert ID="errMessage" runat="server" />
        </div>
    </asp:Panel>
    <!--数据显示区域-->
    <JWC:DataGridView ID="dgfrmDSIEmployeeList" runat="server" CssClass="DataGrid" Width="96%"
        ShowFooter="true" AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
        PageSize="11" OnBuildDataSource="dgfrmDSIEmployeeList_BuildDataSource">
        <PagerSettings Mode="NextPreviousFirstLast" />
        <AlternatingRowStyle CssClass="DataGridAlter" />
        <HeaderStyle CssClass="DataGridHeader" />
        <FooterStyle CssClass="DataGridFooter" />
        <RowStyle CssClass="DataGridItem" />
        <Columns>
            <JWC:BoundFieldEx DataField="EmployeeCode" HeaderText="用户代码" SortExpression="EmployeeCode"
                meta:resourcekey="DSI_EmployeeCode">
                <HeaderStyle Width="40%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
            
            <JWC:BoundFieldEx DataField="EmployeeName" HeaderText="用户名" SortExpression="EmployeeName" meta:resourcekey="DSI_EmployeeName">
                <HeaderStyle Width="60%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
            
        </Columns>
    </JWC:DataGridView>
</asp:Content>
