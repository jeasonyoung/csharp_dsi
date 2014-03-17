<%-- 
//================================================================================
//  FileName: frmDSIEduRptTimeAllowanceList.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-24
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSIEduRptTimeAllowanceList.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIEduRptTimeAllowanceList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="ContentworkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIEduRptTimeAllowanceList" runat="server" ShowMessageBox="true" ShowSummary="false" />

<div class="easyui-layout" data-options="fit:true,border:false">
    <div data-options="region:'north',border:false" style="height:50px;">
        <!--查询区域-->
        <asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
	        <div style="float:left;">
		        <JWC:LabelEx ID="lbProject" runat="server" Style="float:left;" meta:resourcekey="DSI_Project">补助项目名称：</JWC:LabelEx>
		        <JWC:TextBoxEx ID="txtProject" runat="server" Width="168px" />
	        </div>
	        <div style="float:left;">
		        <JWC:LabelEx ID="lbStartTime" runat="server" Style="float:left;" meta:resourcekey="DSI_StartTime">时间段：</JWC:LabelEx>
		        <JWC:TextBoxCalendar ID="txtStartTime" runat="server" Width="128px" />
	            <span>-</span>
		        <JWC:TextBoxCalendar ID="txtEndTime" runat="server" Width="128px" />
	        </div>
	        <div style="float:right;">
		        <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
		        <JWC:ServerAlert ID="errMessage" runat="server" />
	        </div>
        </asp:Panel>
    </div>

    <div data-options="region:'center',border:false">
        <div class="TableControl">
            <JWC:LabelEx ID="lbSummary" runat="server" Style="float:left;" />
        </div>
        <!--数据显示区域-->
        <JWC:DataGridView ID="dgfrmDSIEduRptTimeAllowanceList" runat="server" CssClass="DataGrid" Width="96%" ShowFooter="true"
	        AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
	        PageSize="11" onbuilddatasource="dgfrmDSIEduRptTimeAllowanceList_BuildDataSource">
	        <PagerSettings Mode="NextPreviousFirstLast" />
	        <AlternatingRowStyle CssClass="DataGridAlter" />
	        <HeaderStyle CssClass="DataGridHeader" />
	        <FooterStyle CssClass="DataGridFooter" />
	        <RowStyle CssClass="DataGridItem" />
	        <Columns>		  
	            <JWC:BoundFieldEx DataField="ProjectName" HeaderText="申报项目" SortExpression="ProjectName" meta:resourcekey="DSI_DGV_ProjectName">
			        <HeaderStyle Width="40%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>   
		          
		         <JWC:BoundFieldEx DataField="UnitCount" HeaderText="补助总单位数" SortExpression="UnitCount" meta:resourcekey="DSI_DGV_UnitCount">
			        <HeaderStyle Width="20%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" />
		        </JWC:BoundFieldEx>		        
		        
		        <JWC:BoundFieldEx DataField="Count" HeaderText="补助总人数" SortExpression="Count" meta:resourcekey="DSI_DGV_Count">
			        <HeaderStyle Width="10%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="Money" HeaderText="补助总金额" SortExpression="Money" DataFormatString="{0:##,###.00}" meta:resourcekey="DSI_DGV_Money">
			        <HeaderStyle Width="30%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" />
		        </JWC:BoundFieldEx>
	        </Columns>
        </JWC:DataGridView>
    </div>
</div>
</asp:Content>