<%--
//================================================================================
//  FileName: frmDSIPersonalStaffAppFormReqList.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-13
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
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSIPersonalStaffAppFormReqList.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIPersonalStaffAppFormReqList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIPersonalStaffAppFormReqList" runat="server" ShowMessageBox="true" ShowSummary="false" />

<script language="javascript" type="text/javascript">
<!--
    $(function() { 
        <% if(!this.IsPostBack && !string.IsNullOrEmpty(this.Request["ProjectID"])){ %>
            $("#<%=this.btnAdd.ClientID %>").click();
        <%} %>
    });
//-->
</script>
<div class="easyui-layout" data-options="fit:true,border:false">
    <div data-options="region:'north',border:false" style="height:80px;">
        <!--标题-->
        <div class="TitleBar">
	        <span style="float:left;">
		        <JWC:ButtonEx ID="btnAdd" runat="server" Text="申报补助" ToolTip="申报补助" PickerPage="frmDSIPersonalStaffAppFormReqEdit.aspx" PickerType="Modal" PickerWidth="970px" PickerHeight="680px" onclick="btnAdd_Click"/>
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
        <JWC:DataGridView ID="dgfrmDSIPersonalStaffAppFormReqList" runat="server" CssClass="DataGrid" Width="96%" ShowFooter="true"
	        AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
	        PageSize="11" onbuilddatasource="dgfrmDSIPersonalStaffAppFormReqList_BuildDataSource">
	        <PagerSettings Mode="NextPreviousFirstLast" />
	        <AlternatingRowStyle CssClass="DataGridAlter" />
	        <HeaderStyle CssClass="DataGridHeader" />
	        <FooterStyle CssClass="DataGridFooter" />
	        <RowStyle CssClass="DataGridItem" />
	        <Columns>
		        <JWC:CheckBoxFieldEx DataField="StaffID,ProjectID" DataFormatString="{0}-{1}">
			        <HeaderStyle Width="8px" />
		        </JWC:CheckBoxFieldEx>
		        
		        <JWC:BoundFieldEx DataField="ProjectName" HeaderText="申报项目" SortExpression="ProjectName" meta:resourcekey="DSI_DGV_ProjectName">
			        <HeaderStyle Width="14%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="UnitName" HeaderText="所属单位" SortExpression="UnitName" meta:resourcekey="DSI_DGV_UnitName">
			        <HeaderStyle Width="9%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>
    			
		        <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="970px" WinHeight="680px"
			        DataNavigateUrlFormatString="frmDSIPersonalStaffAppFormReqEdit.aspx?StaffID={0}&ProjectID={1}" DataNavigateUrlField="StaffID,ProjectID"
			        HeaderText="申报职工" DataField="StaffName" SortExpression="StaffName" meta:resourcekey="DSI_DGV_StaffName">
			        <HeaderStyle Width="6%" HorizontalAlign="Center" />
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
			        <HeaderStyle Width="6%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="MaritalstatusName" HeaderText="婚姻" SortExpression="MaritalstatusName" meta:resourcekey="DSI_DGV_MaritalstatusName">
			        <HeaderStyle Width="4%"  HorizontalAlign="Center" />
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
		        
		         <JWC:BoundFieldEx DataField="PrimaryAllowance" HeaderText="拟初审金额" SortExpression="PrimaryAllowance" DataFormatString="{0:##,###.00}" meta:resourcekey="DSI_DGV_CreateUserName">
			        <HeaderStyle Width="7%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="FinalAllowance" HeaderText="补助金额" SortExpression="FinalAllowance" DataFormatString="{0:##,###.00}"  meta:resourcekey="DSI_DGV_FinalAllowance">
			        <HeaderStyle Width="5%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Right" />
		        </JWC:BoundFieldEx>
    			
		        <JWC:BoundFieldEx DataField="CreateTime" HeaderText="申报时间" SortExpression="CreateTime" DataFormatString="{0:yyyy-MM-dd}" meta:resourcekey="DSI_DGV_CreateTime">
			        <HeaderStyle Width="6%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
    			
		        <JWC:BoundFieldEx DataField="StatusName" HeaderText="审批状态" SortExpression="StatusName" meta:resourcekey="DSI_DGV_StatusName">
			        <HeaderStyle Width="6%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Center" />
		        </JWC:BoundFieldEx>
		        		        
		        <JWC:TemplateFieldEx>
		            <HeaderStyle Width="4%" HorizontalAlign="Center" CssClass="DataGridHeader" />
		            <ItemStyle HorizontalAlign="Center" />
		            <ItemTemplate>
		                <a target="_blank" href='frmDSIStaffAppFormReqPrint.aspx?StaffID=<%# Eval("StaffID")%>&ProjectID=<%# Eval("ProjectID") %>'>[打印]</a>
		            </ItemTemplate>
		        </JWC:TemplateFieldEx>
	        </Columns>
        </JWC:DataGridView>
    </div>
</div>
</asp:Content>