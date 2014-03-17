<%--
//================================================================================
//  FileName: frmDSIEduAuditList.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-19
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSIEduAuditList.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIEduAuditList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIEduAuditList" runat="server" ShowMessageBox="true" ShowSummary="false" />

<div class="easyui-layout" data-options="fit:true,border:false">
    <div data-options="region:'north',border:false" style="height:50px;">
        <!--查询区域-->
        <asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
            <div style="float:left;">
		        <JWC:LabelEx ID="lbYear" runat="server" Style="float:left;" meta:resourcekey="DSI_Year">年度：</JWC:LabelEx>
		        <JWC:DropDownListEx ID="ddlYear" runat="server" Width="128px" ShowUnDefine="true" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_OnSelectedIndexChanged" />
	        </div>
	        <div style="float:left;">
		        <JWC:LabelEx ID="lbProjectID" runat="server" Style="float:left;" meta:resourcekey="DSI_ProjectID">申报项目名称：</JWC:LabelEx>
		        <JWC:DropDownListEx ID="ddlProject" runat="server" Width="168px" ShowUnDefine="true" />
	        </div>
	        <div style="float:left;">
		        <JWC:LabelEx ID="lbUnitName" runat="server" Style="float:left;" meta:resourcekey="DSI_StaffName">所属单位：</JWC:LabelEx>
		        <JWC:TextBoxEx ID="txtUnitName" runat="server" Width="128px" />
	        </div>
	        <div style="float:left;">
		        <JWC:LabelEx ID="lbStaffName" runat="server" Style="float:left;" meta:resourcekey="DSI_StaffName">教职工姓名：</JWC:LabelEx>
		        <JWC:TextBoxEx ID="txtStaffName" runat="server" Width="128px" />
	        </div>
	        <div style="float:right;">
		        <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
		        <JWC:ServerAlert ID="errMessage" runat="server" />
	        </div>
        </asp:Panel>
    </div>

    <div data-options="region:'center',border:false">
        <!--数据显示区域-->
        <JWC:DataGridView ID="dgfrmDSIEduAuditList" runat="server" CssClass="DataGrid" Width="96%" ShowFooter="true"
	        AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
	        PageSize="11" onbuilddatasource="dgfrmDSIEduAuditList_BuildDataSource">
	        <PagerSettings Mode="NextPreviousFirstLast" />
	        <AlternatingRowStyle CssClass="DataGridAlter" />
	        <HeaderStyle CssClass="DataGridHeader" />
	        <FooterStyle CssClass="DataGridFooter" />
	        <RowStyle CssClass="DataGridItem" />
	        <Columns>
		        <JWC:BoundFieldEx DataField="ProjectName" HeaderText="申报项目" SortExpression="ProjectName" meta:resourcekey="DSI_DGV_ProjectName">
			        <HeaderStyle Width="13%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="UnitName" HeaderText="所属单位" SortExpression="UnitName" meta:resourcekey="DSI_DGV_UnitName">
			        <HeaderStyle Width="8%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>
    			
		        <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="960px" WinHeight="670px"
			        DataNavigateUrlFormatString="frmDSIEduAuditEdit.aspx?StaffID={0}&ProjectID={1}" DataNavigateUrlField="StaffID,ProjectID"
			        HeaderText="申报职工" DataField="StaffName" SortExpression="StaffName" meta:resourcekey="DSI_DGV_StaffName">
			        <HeaderStyle Width="5%" HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:MultiQueryStringFieldEx>
		        
		        <JWC:BoundFieldEx DataField="GenderName" HeaderText="性别" SortExpression="GenderName" meta:resourcekey="DSI_DGV_GenderName">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
    			
		        <JWC:BoundFieldEx DataField="Age" HeaderText="年龄" SortExpression="Age" meta:resourcekey="DSI_DGV_Age">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" />
		        </JWC:BoundFieldEx>
		        		        
		        <JWC:BoundFieldEx DataField="TheidentityName" HeaderText="身份" SortExpression="TheidentityName" meta:resourcekey="DSI_DGV_TheidentityName">
			        <HeaderStyle Width="5%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="MaritalstatusName" HeaderText="婚姻" SortExpression="MaritalstatusName" meta:resourcekey="DSI_DGV_MaritalstatusName">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="HardCategoryName" HeaderText="困难类别" SortExpression="HardCategoryName" meta:resourcekey="DSI_DGV_HardCategoryName">
			        <HeaderStyle Width="8%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>
		        		        
		        <JWC:BoundFieldEx DataField="HardBecauseName" HeaderText="致困主要原因" SortExpression="HardBecauseName" meta:resourcekey="DSI_DGV_HardBecauseName">
			        <HeaderStyle Width="18%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="PrimaryAllowance" HeaderText="拟初审额" SortExpression="PrimaryAllowance" DataFormatString="{0:##,###.00}" meta:resourcekey="DSI_DGV_PrimaryAllowance">
			        <HeaderStyle Width="5%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="Blue"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="FinalAllowance" HeaderText="补助金额" SortExpression="FinalAllowance" DataFormatString="{0:##,###.00}" meta:resourcekey="DSI_DGV_FinalAllowance">
			        <HeaderStyle Width="5%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="Red"/>
		        </JWC:BoundFieldEx>
    			
		        <JWC:BoundFieldEx DataField="CreateTime" HeaderText="申报时间" SortExpression="CreateTime" DataFormatString="{0:yyyy-MM-dd}" meta:resourcekey="DSI_DGV_CreateTime">
			        <HeaderStyle Width="6%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
    			
		        <JWC:BoundFieldEx DataField="StatusName" HeaderText="审批状态" SortExpression="StatusName" meta:resourcekey="DSI_DGV_StatusName">
			        <HeaderStyle Width="6%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="CreateUserName" HeaderText="申报人" SortExpression="CreateUserName" meta:resourcekey="DSI_DGV_CreateUserName">
			        <HeaderStyle Width="5%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="420px" WinHeight="200px"
			        DataNavigateUrlFormatString="frmDSIEduAudit.aspx?StaffID={0}&ProjectID={1}" DataNavigateUrlField="StaffID,ProjectID"
			        HeaderText="终审/反终审" DataField="AuditName" SortExpression="AuditName" meta:resourcekey="DSI_DGV_AuditName">
			        <HeaderStyle Width="7%" HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:MultiQueryStringFieldEx>
	        </Columns>
        </JWC:DataGridView>
    </div>
</div>
</asp:Content>