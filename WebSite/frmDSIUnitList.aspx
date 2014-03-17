<%--
//================================================================================
// FileName: frmDSIUnitList.aspx
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

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmDSIUnitList.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIUnitList" %>
<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
    <!--��ѯ����-->
    <asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
        <div style="float: left;">
            <JWC:LabelEx ID="lbUnitName" runat="server" Style="float: left;" meta:resourcekey="DSI_UnitName">��λ��</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtUnitName" runat="server" Width="168px" />
        </div>
        <div style="float: right;">
            <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" OnClick="btnSearch_Click" />
            <JWC:ServerAlert ID="errMessage" runat="server" />
        </div>
    </asp:Panel>
    <!--������ʾ����-->
    <JWC:DataGridView ID="dgfrmDSIUnitList" runat="server" CssClass="DataGrid" Width="96%"
        ShowFooter="true" AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
        PageSize="11" OnBuildDataSource="dgfrmDSIUnitList_BuildDataSource">
        <PagerSettings Mode="NextPreviousFirstLast" />
        <AlternatingRowStyle CssClass="DataGridAlter" />
        <HeaderStyle CssClass="DataGridHeader" />
        <FooterStyle CssClass="DataGridFooter" />
        <RowStyle CssClass="DataGridItem" />
        <Columns>
            <JWC:BoundFieldEx DataField="UnitCode" HeaderText="��λ����" SortExpression="UnitCode"
                meta:resourcekey="DSI_UnitCode">
                <HeaderStyle Width="50%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
            <JWC:BoundFieldEx DataField="UnitName" HeaderText="�û���" SortExpression="UnitName"
                meta:resourcekey="DSI_UnitName">
                <HeaderStyle Width="50%" />
                <ItemStyle HorizontalAlign="Left" />
            </JWC:BoundFieldEx>
        </Columns>
    </JWC:DataGridView>
</asp:Content>
