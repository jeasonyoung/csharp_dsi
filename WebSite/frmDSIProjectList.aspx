<%--
//================================================================================
//  FileName: frmDSIProjectList.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-11
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSIProjectList.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIProjectList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIProjectList" runat="server" ShowMessageBox="true" ShowSummary="false" />

<div class="easyui-layout" data-options="fit:true,border:false">
    <div data-options="region:'north',border:false" style="height:80px;">
        <!--标题-->
        <div class="TitleBar">
	        <span style="float:left;">
		        <JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmDSIProjectEdit.aspx" PickerType="Modal" PickerWidth="620px" PickerHeight="420px" onclick="btnAdd_Click"/>
	        </span>
	        <span style="float:left;">|</span>
	        <span style="float:left;">
		        <JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="您确定要删除当前所选择的数据吗？" onclick="btnDelete_Click" />
	        </span>
        </div>
    	
        <!--查询区域-->
        <asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
	        <div style="float:left;">
		        <JWC:LabelEx ID="lbProjectName" runat="server" Style="float:left;" meta:resourcekey="DSI_ProjectName">申报项目名称：</JWC:LabelEx>
		        <JWC:TextBoxEx ID="txtProjectName" runat="server" Width="198px" />
	        </div>
	        <div style="float:right;">
		        <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
		        <JWC:ServerAlert ID="errMessage" runat="server" />
	        </div>
        </asp:Panel>
    </div>

    <div data-options="region:'center',border:false">
        <!--数据显示区域-->
        <JWC:DataGridView ID="dgfrmDSIProjectList" runat="server" CssClass="DataGrid" Width="96%" ShowFooter="true"
	        AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
	        PageSize="11" onbuilddatasource="dgfrmDSIProjectList_BuildDataSource">
	        <PagerSettings Mode="NextPreviousFirstLast" />
	        <AlternatingRowStyle CssClass="DataGridAlter" />
	        <HeaderStyle CssClass="DataGridHeader" />
	        <FooterStyle CssClass="DataGridFooter" />
	        <RowStyle CssClass="DataGridItem" />
	        <Columns>
		        <JWC:CheckBoxFieldEx DataField="ProjectID">
			        <HeaderStyle Width="8px" />
		        </JWC:CheckBoxFieldEx>
    			
		        <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="620px" WinHeight="420px"
			        DataNavigateUrlFormatString="frmDSIProjectEdit.aspx?ProjectID={0}" DataNavigateUrlField="ProjectID"
			        HeaderText="申报项目名称" DataField="ProjectName" SortExpression="ProjectName" meta:resourcekey="DSI_DGV_ProjectName">
			        <HeaderStyle Width="60%" HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:MultiQueryStringFieldEx>
    			
		        <JWC:BoundFieldEx DataField="StartTime" HeaderText="申报开始时间" SortExpression="StartTime" DataFormatString="{0:yyyy-MM-dd}" meta:resourcekey="DSI_DGV_StartTime">
			        <HeaderStyle Width="15%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
    			
		        <JWC:BoundFieldEx DataField="EndTime" HeaderText="申报结束时间" SortExpression="EndTime" DataFormatString="{0:yyyy-MM-dd}" meta:resourcekey="DSI_DGV_EndTime">
			        <HeaderStyle Width="15%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
    			
		        <JWC:BoundFieldEx DataField="IsViewName" HeaderText="是否在首页显示" SortExpression="IsViewName" meta:resourcekey="DSI_DGV_IsViewName">
			        <HeaderStyle Width="10%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
	        </Columns>
        </JWC:DataGridView>
    </div>
</div>
</asp:Content>