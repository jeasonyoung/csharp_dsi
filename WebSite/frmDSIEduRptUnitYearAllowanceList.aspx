<%-- 
//================================================================================
//  FileName: frmDSIEduRptUnitYearAllowanceList.aspx
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSIEduRptUnitYearAllowanceList.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIEduRptUnitYearAllowanceList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="ContentworkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIEduRptUnitYearAllowanceList" runat="server" ShowMessageBox="true" ShowSummary="false" />

<div class="easyui-layout" data-options="fit:true,border:false">
    <div data-options="region:'north',border:false" style="height:46px;">
        <!--查询区域-->
        <asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
            <div style="float:left;">
		        <JWC:LabelEx ID="lbYear" runat="server" Style="float:left;" meta:resourcekey="DSI_Year">年度：</JWC:LabelEx>
		        <JWC:DropDownListEx ID="ddlYear" runat="server" ShowUnDefine="true" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_OnSelectedIndexChanged" Width="128" />
	        </div>
	        <div style="float:left;">
		        <JWC:LabelEx ID="lbProject" runat="server" Style="float:left;" meta:resourcekey="DSI_Project">申报项目名称：</JWC:LabelEx>
		        <JWC:DropDownListEx ID="ddlProject" runat="server" ShowUnDefine="true" Width="168" />
	        </div>
	        <div style="float:left;">
		        <JWC:LabelEx ID="lbUnitName" runat="server" Style="float:left;" meta:resourcekey="DSI_UnitName">单位名称：</JWC:LabelEx>
		        <JWC:TextBoxEx ID="txtUnitName" runat="server" Width="168px" />
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
        <JWC:DataGridView ID="dgfrmDSIEduRptUnitYearAllowanceList" runat="server" CssClass="DataGrid" Width="96%" ShowFooter="true"
	        AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
	        PageSize="9" onbuilddatasource="dgfrmDSIEduRptUnitYearAllowanceList_BuildDataSource">
	        <PagerSettings Mode="NextPreviousFirstLast" />
	        <AlternatingRowStyle CssClass="DataGridAlter" />
	        <HeaderStyle CssClass="DataGridHeader" />
	        <FooterStyle CssClass="DataGridFooter" />
	        <RowStyle CssClass="DataGridItem" />
	        <Columns>
		        <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="980px" WinHeight="680px"
			        DataNavigateUrlFormatString="frmDSIEduRptAllowanceDetail.aspx?UnitID={0}&Year={1}" DataNavigateUrlField="UnitID,CreateYear"
			        HeaderText="所属单位" DataField="UnitName" SortExpression="UnitName" meta:resourcekey="DSI_DGV_UnitName">
			        <HeaderStyle Width="20%" HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:MultiQueryStringFieldEx>
		                
	            <JWC:BoundFieldEx DataField="CreateYear" HeaderText="年度" SortExpression="CreateYear" meta:resourcekey="DSI_DGV_CreateYear">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
	                    
	            <JWC:BoundFieldEx DataField="HardCategory_Disaster" HeaderText="因天灾人祸致困" SortExpression="HardCategory_Disaster" meta:resourcekey="DSI_DGV_HardCategory_Disaster">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center"/>
			        <ItemStyle HorizontalAlign="Right" ForeColor="Blue" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="HardCategory_Disease" HeaderText="因病致困" SortExpression="HardCategory_Disease" meta:resourcekey="DSI_DGV_HardCategory_Disease">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center"/>
			        <ItemStyle HorizontalAlign="Right" ForeColor="Blue"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="HardCategory_Other" HeaderText="其他特殊情况" SortExpression="HardCategory_Other" meta:resourcekey="DSI_DGV_HardCategory_Other">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center"/>
			        <ItemStyle HorizontalAlign="Right" ForeColor="Blue"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="HardBecause_Disaster3_5" HeaderText="因天灾人祸致困造成损失3-5万" SortExpression="HardBecause_Disaster3_5" meta:resourcekey="DSI_DGV_HardBecause_Disaster3_5">
			        <HeaderStyle Width="4%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="BlueViolet" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="HardBecause_Disaster5_10" HeaderText="因天灾人祸致困造成损失5-10万" SortExpression="HardBecause_Disaster5_10" meta:resourcekey="DSI_DGV_HardBecause_Disaster5_10">
			        <HeaderStyle Width="4%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="BlueViolet"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="HardBecause_Disaster10_" HeaderText="因天灾人祸致困造成损失10万以上" SortExpression="HardBecause_Disaster10_" meta:resourcekey="DSI_DGV_HardBecause_Disaster10_">
			        <HeaderStyle Width="4%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="BlueViolet"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="HardBecause_Disease" HeaderText="因病致困年度自付金额1万元以上" SortExpression="HardBecause_Disease" meta:resourcekey="DSI_DGV_HardBecause_Disease">
			        <HeaderStyle Width="4%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="BlueViolet"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="HardBecause_Other3_5" HeaderText="其他特殊情况致家庭负债3-5万" SortExpression="HardBecause_Other3_5" meta:resourcekey="DSI_DGV_HardBecause_Other3_5">
			        <HeaderStyle Width="4%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="BlueViolet"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="HardBecause_Other5_10" HeaderText="其他特殊情况致家庭负债5-10万" SortExpression="HardBecause_Other5_10" meta:resourcekey="DSI_DGV_HardBecause_Other5_10">
			        <HeaderStyle Width="4%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="BlueViolet"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="HardBecause_Other10_" HeaderText="其他特殊情况致家庭负债10万以上" SortExpression="HardBecause_Other10_" meta:resourcekey="DSI_DGV_HardBecause_Other10_">
			        <HeaderStyle Width="4%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="BlueViolet"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="HardBecause_Children" HeaderText="子女读大学" SortExpression="HardBecause_Children" meta:resourcekey="DSI_DGV_HardBecause_Children">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="BlueViolet"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="Theidentity_InService" HeaderText="在职" SortExpression="Theidentity_InService" meta:resourcekey="DSI_DGV_Theidentity_InService">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="Green"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="Theidentity_Retirement" HeaderText="退休" SortExpression="Theidentity_Retirement" meta:resourcekey="DSI_DGV_Theidentity_Retirement">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="Green"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="Theidentity_Retired" HeaderText="离休" SortExpression="Theidentity_Retired" meta:resourcekey="DSI_DGV_Theidentity_Retired">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="Green"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="Theidentity_Illness" HeaderText="病休" SortExpression="Theidentity_Illness" meta:resourcekey="DSI_DGV_Theidentity_Illness">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="Green"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="Theidentity_Temporary" HeaderText="临时聘用" SortExpression="Theidentity_Temporary" meta:resourcekey="DSI_DGV_Theidentity_Temporary">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="Green"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="Maritalstatus_Married" HeaderText="已婚" SortExpression="Maritalstatus_Married" meta:resourcekey="DSI_DGV_Maritalstatus_Married">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right"  ForeColor="Chocolate"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="Maritalstatus_Unmarried" HeaderText="未婚" SortExpression="Maritalstatus_Unmarried" meta:resourcekey="DSI_DGV_Maritalstatus_Unmarried">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="Chocolate"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="Maritalstatus_Divorced" HeaderText="离异" SortExpression="Maritalstatus_Divorced" meta:resourcekey="DSI_DGV_Maritalstatus_Divorced">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="Chocolate"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="Maritalstatus_Widowed" HeaderText="丧偶" SortExpression="Maritalstatus_Widowed" meta:resourcekey="DSI_DGV_Maritalstatus_Widowed">
			        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" ForeColor="Chocolate"/>
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="Count" HeaderText="总人数" SortExpression="Count" meta:resourcekey="DSI_DGV_Count">
			        <HeaderStyle Width="4%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="Money" HeaderText="补助总金额" SortExpression="Money" DataFormatString="{0:##,###.00}" meta:resourcekey="DSI_DGV_Money">
			        <HeaderStyle Width="9%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" />
		        </JWC:BoundFieldEx>
	        </Columns>
        </JWC:DataGridView>
    </div>
</div>
</asp:Content>