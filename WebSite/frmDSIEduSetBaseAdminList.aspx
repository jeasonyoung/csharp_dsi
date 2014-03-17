<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSIEduSetBaseAdminList.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIEduSetBaseAdminList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="ContentworkPlace" ContentPlaceHolderID="workPlace" runat="server">
<JWC:ValidationSummaryEx ID="vsfrmDSIEduSetBaseAdminList" runat="server" ShowMessageBox="true" ShowSummary="false" />
<div class="easyui-layout" data-options="fit:true,border:false">
    <div data-options="region:'north',border:false" style="height:80px;">
        <!--标题-->
        <div class="TitleBar">
	        <span style="float:left;">
		        <JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmDSIEduSetBaseAdminEdit.aspx" PickerType="Modal" PickerWidth="620px" PickerHeight="420px" onclick="btnAdd_Click"/>
	        </span>
	        <span style="float:left;">|</span>
	        <span style="float:left;">
		        <JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="您确定要删除当前所选择的数据吗？" onclick="btnDelete_Click" />
	        </span>
        </div>
        
        <!--查询区域-->
        <asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
	        <div style="float:left;">
		        <JWC:LabelEx ID="lbUnitName" runat="server" Style="float:left;" meta:resourcekey="DSI_UnitName">基层单位名称：</JWC:LabelEx>
		        <JWC:TextBoxEx ID="txtUnitName" runat="server" Width="198px" />
	        </div>
	        <div style="float:left;">
		        <JWC:LabelEx ID="lbEmployeeName" runat="server" Style="float:left;" meta:resourcekey="DSI_EmployeeName">管理员姓名：</JWC:LabelEx>
		        <JWC:TextBoxEx ID="txtEmployeeName" runat="server" Width="198px" />
	        </div>
	        <div style="float:right;">
		        <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
		        <JWC:ServerAlert ID="errMessage" runat="server" />
	        </div>
        </asp:Panel>
    </div>
    
    <div data-options="region:'center',border:false">
        <!--数据显示区域-->
        <JWC:DataGridView ID="dgfrmDSIEduSetBaseAdminList" runat="server" CssClass="DataGrid" Width="96%" ShowFooter="true"
	        AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
	        PageSize="11" onbuilddatasource="frmDSIEduSetBaseAdminList_BuildDataSource">
	        <PagerSettings Mode="NextPreviousFirstLast" />
	        <AlternatingRowStyle CssClass="DataGridAlter" />
	        <HeaderStyle CssClass="DataGridHeader" />
	        <FooterStyle CssClass="DataGridFooter" />
	        <RowStyle CssClass="DataGridItem" />
	        <Columns>
		        <JWC:CheckBoxFieldEx DataField="EmployeeID">
			        <HeaderStyle Width="8px" />
		        </JWC:CheckBoxFieldEx>
		        
		        <JWC:BoundFieldEx DataField="UnitName" HeaderText="所属基层单位" SortExpression="UnitName" meta:resourcekey="DSI_DGV_UnitName">
			        <HeaderStyle Width="65%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>
		        
		        <JWC:BoundFieldEx DataField="EmployeeName" HeaderText="基层工会管理员" SortExpression="EmployeeName" meta:resourcekey="DSI_DGV_EmployeeName">
			        <HeaderStyle Width="35%"  HorizontalAlign="Center" />
			        <ItemStyle HorizontalAlign="Left" />
		        </JWC:BoundFieldEx>
    			
	        </Columns>
        </JWC:DataGridView>
    </div>
</div>
</asp:Content>