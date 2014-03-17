<%--
//================================================================================
// FileName: frmDSIStaffInfoList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmDSIEduStaffInfoList.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIEduStaffInfoList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIEduStaffInfoList" runat="server" ShowMessageBox="true" ShowSummary="false" />

    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height:80px;">
            <!--标题-->
	        <div class="TitleBar">
		        <span style="float:left;">
			        <JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmDSIEduStaffInfoEdit.aspx" PickerType="Modal" PickerWidth="960px" PickerHeight="658px" onclick="btnAdd_Click"/>
		        </span>
		        <span style="float:left;">|</span>
		        <span style="float:left;">
			        <JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="您确定要删除当前所选择的数据吗？" onclick="btnDelete_Click" />
		        </span>
	        </div>
        	
	        <!--查询区域-->
	        <asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
	            <div style="float:left;">
	                <JWC:LabelEx ID="lbUnitName" runat="server" Style="float:left;" meta:resourcekey="DSI_UnitName">工作单位：</JWC:LabelEx>
	                <JWC:TextBoxEx ID="txtUnitName" runat="server" Width="168px" />
                </div>
		        <div style="float:left;">
			        <JWC:LabelEx ID="lbStaffNameCodeCard" runat="server" Style="float:left;" meta:resourcekey="DSI_StaffNameCodeCard">教职工姓名：</JWC:LabelEx>
			        <JWC:TextBoxEx ID="txtStaffNameCodeCard" runat="server" Width="128px" />
		        </div>
		        <div style="float:right;">
			        <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			        <JWC:ServerAlert ID="errMessage" runat="server" />
		        </div>
	        </asp:Panel>
        </div>
    
        <div data-options="region:'center',border:false">
            <!--数据显示区域-->
	        <JWC:DataGridView ID="dgfrmDSIStaffInfoList" runat="server" CssClass="DataGrid" Width="96%" ShowFooter="true"
		        AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
		        PageSize="11" onbuilddatasource="dgfrmDSIStaffInfoList_BuildDataSource">
		        <PagerSettings Mode="NextPreviousFirstLast" />
		        <AlternatingRowStyle CssClass="DataGridAlter" />
		        <HeaderStyle CssClass="DataGridHeader" />
		        <FooterStyle CssClass="DataGridFooter" />
		        <RowStyle CssClass="DataGridItem" />
		        <Columns>
			        <JWC:CheckBoxFieldEx DataField="StaffID">
				        <HeaderStyle Width="8px" />
			        </JWC:CheckBoxFieldEx>
        			
			        <JWC:BoundFieldEx DataField="StaffCode" HeaderText="职工编号" SortExpression="StaffCode" meta:resourcekey="DSI_DGV_StaffCode">
				        <HeaderStyle Width="10%" HorizontalAlign="Center" />
				        <ItemStyle HorizontalAlign="Left" />
			        </JWC:BoundFieldEx>
        			
			        <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="960px" WinHeight="658px"
				        DataNavigateUrlFormatString="frmDSIEduStaffInfoEdit.aspx?StaffID={0}" DataNavigateUrlField="StaffID"
				        HeaderText="姓名" DataField="StaffName" SortExpression="StaffName" meta:resourcekey="DSI_DGV_StaffName">
				        <HeaderStyle Width="6%" HorizontalAlign="Center"/>
				        <ItemStyle HorizontalAlign="Left" />
			        </JWC:MultiQueryStringFieldEx>
        			
			        <JWC:BoundFieldEx DataField="GenderName" HeaderText="性别" SortExpression="GenderName" meta:resourcekey="DSI_DGV_Gender">
				        <HeaderStyle Width="3%" HorizontalAlign="Center"/>
				        <ItemStyle HorizontalAlign="Center" />
			        </JWC:BoundFieldEx>
			        			        
		            <JWC:BoundFieldEx DataField="Age" HeaderText="年龄" SortExpression="Age" meta:resourcekey="DSI_DGV_Age">
			            <HeaderStyle Width="3%"  HorizontalAlign="Center" />
			            <ItemStyle HorizontalAlign="Right" />
		            </JWC:BoundFieldEx>
        			
			        <JWC:BoundFieldEx DataField="IDCard" HeaderText="身份证号" SortExpression="IDCard" meta:resourcekey="DSI_DGV_IDCard">
				        <HeaderStyle Width="12%" HorizontalAlign="Center"/>
				        <ItemStyle HorizontalAlign="Left" />
			        </JWC:BoundFieldEx>
			        
			        <JWC:BoundFieldEx DataField="TheidentityName" HeaderText="身份" SortExpression="TheidentityName" meta:resourcekey="DSI_DGV_TheidentityName">
			            <HeaderStyle Width="5%"  HorizontalAlign="Center" />
			            <ItemStyle HorizontalAlign="Center" />
		            </JWC:BoundFieldEx>
		            
		            <JWC:BoundFieldEx DataField="MaritalstatusName" HeaderText="婚姻" SortExpression="MaritalstatusName" meta:resourcekey="DSI_DGV_MaritalstatusName">
			            <HeaderStyle Width="4%"  HorizontalAlign="Center" />
			            <ItemStyle HorizontalAlign="Center" />
		            </JWC:BoundFieldEx>
		            
		            <JWC:BoundFieldEx DataField="HealthStatusName" HeaderText="健康状态" SortExpression="HealthStatusName" meta:resourcekey="DSI_DGV_HealthStatusName">
				        <HeaderStyle Width="5%" HorizontalAlign="Center"/>
				        <ItemStyle HorizontalAlign="Center" />
			        </JWC:BoundFieldEx>
        			
			        <JWC:BoundFieldEx DataField="UnitName" HeaderText="工作单位" SortExpression="UnitName" meta:resourcekey="DSI_DGV_UnitName">
				        <HeaderStyle Width="12%" HorizontalAlign="Center"/>
				        <ItemStyle HorizontalAlign="Left" />
			        </JWC:BoundFieldEx>
        			
			        <JWC:BoundFieldEx DataField="HardCategoryName" HeaderText="困难类别" SortExpression="HardCategoryName" meta:resourcekey="DSI_DGV_HardCategoryName">
				        <HeaderStyle Width="9%" HorizontalAlign="Center"/>
				        <ItemStyle HorizontalAlign="Left" />
			        </JWC:BoundFieldEx>
			        
			        <JWC:BoundFieldEx DataField="HardBecauseName" HeaderText="致困主要原因" SortExpression="HardBecauseName" meta:resourcekey="DSI_DGV_HardBecauseName">
				        <HeaderStyle Width="18%" HorizontalAlign="Center"/>
				        <ItemStyle HorizontalAlign="Left" />
			        </JWC:BoundFieldEx>
        			
        			<JWC:BoundFieldEx DataField="CreateTime" HeaderText="创建时间" SortExpression="CreateTime" DataFormatString="{0:yyyy-MM-dd}" meta:resourcekey="DSI_DGV_CreateTime">
				        <HeaderStyle Width="6%" HorizontalAlign="Center"/>
				        <ItemStyle HorizontalAlign="Center" />
			        </JWC:BoundFieldEx>
			        
			        <JWC:BoundFieldEx DataField="CreateUserName" HeaderText="创建\管理者" SortExpression="CreateUserName" meta:resourcekey="DSI_DGV_CreateUserName">
				        <HeaderStyle Width="7%" HorizontalAlign="Center"/>
				        <ItemStyle HorizontalAlign="Center" />
			        </JWC:BoundFieldEx>
		        </Columns>
	        </JWC:DataGridView>
        </div>
    </div>
</asp:Content>