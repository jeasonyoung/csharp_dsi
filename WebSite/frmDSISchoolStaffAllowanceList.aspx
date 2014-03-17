<%-- 
//================================================================================
//  FileName: frmDSISchoolStaffAllowanceList.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-22
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSISchoolStaffAllowanceList.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSISchoolStaffAllowanceList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSISchoolStaffAllowanceList" runat="server" ShowMessageBox="true" ShowSummary="false" />

<div class="easyui-layout" data-options="fit:true,border:false">
    <div data-options="region:'north',border:false" style="height:50px;">
        <!--查询区域-->
        <asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
            <div style="float:left;">
		        <JWC:LabelEx ID="lbYear" runat="server" Style="float:left;" meta:resourcekey="DSI_Year">年度：</JWC:LabelEx>
		        <JWC:DropDownListEx ID="ddlYear" runat="server" Width="128px" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_OnSelectedIndexChanged" ShowUnDefine="true" />
	        </div>
	        <div style="float:left;">
		        <JWC:LabelEx ID="lbProjectName" runat="server" Style="float:left;" meta:resourcekey="DSI_ProjectName">申报项目名称：</JWC:LabelEx>
		        <JWC:DropDownListEx ID="ddlProject" runat="server" Width="168px" ShowUnDefine="true" />
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
        <JWC:DataGridView ID="dgfrmDSISchoolStaffAllowanceList" runat="server" CssClass="DataGrid" Width="96%" ShowFooter="true"
	        AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
	        PageSize="11" onbuilddatasource="dgfrmDSISchoolStaffAllowanceList_BuildDataSource">
	        <PagerSettings Mode="NextPreviousFirstLast" />
	        <AlternatingRowStyle CssClass="DataGridAlter" />
	        <HeaderStyle CssClass="DataGridHeader" />
	        <FooterStyle CssClass="DataGridFooter" />
	        <RowStyle CssClass="DataGridItem" />
	        <Columns>
		        <JWC:BoundFieldEx DataField="ProjectName" HeaderText="申报项目" SortExpression="ProjectName" meta:resourcekey="DSI_DGV_ProjectName">
			        <HeaderStyle Width="15%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="UnitName" HeaderText="所属单位" SortExpression="UnitName" meta:resourcekey="DSI_DGV_UnitName">
			        <HeaderStyle Width="10%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>
    			
		        <JWC:BoundFieldEx DataField="StaffName" HeaderText="申报职工" SortExpression="StaffName" meta:resourcekey="DSI_DGV_StaffName">
			        <HeaderStyle Width="5%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="GenderName" HeaderText="性别" SortExpression="GenderName" meta:resourcekey="DSI_DGV_GenderName">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
		        
		         <JWC:BoundFieldEx DataField="IDCard" HeaderText="身份证号" SortExpression="IDCard" meta:resourcekey="DSI_DGV_IDCard">
			        <HeaderStyle Width="12%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
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
			        <HeaderStyle Width="9%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="HardBecauseName" HeaderText="致困主要原因" SortExpression="HardBecauseName" meta:resourcekey="DSI_DGV_HardBecauseName">
			        <HeaderStyle Width="18%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>
		        		        
		        <JWC:BoundFieldEx DataField="Money" HeaderText="补助金额" SortExpression="Money" DataFormatString="{0:##,###.00}" meta:resourcekey="DSI_DGV_Money">
			        <HeaderStyle Width="10%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="Red" />
		        </JWC:BoundFieldEx>
    			
		        <JWC:BoundFieldEx DataField="Time" HeaderText="申报时间" SortExpression="Time" DataFormatString="{0:yyyy-MM-dd}" meta:resourcekey="DSI_DGV_Time">
			        <HeaderStyle Width="7%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
	        </Columns>
        </JWC:DataGridView>
    </div>
</div>
</asp:Content>