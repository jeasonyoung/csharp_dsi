<%@ Page Language="C#" MasterPageFile="Share/ModuleNormalMasterPage.Master" AutoEventWireup="true" CodeBehind="frmDSIEduRptAllowanceDetail.aspx.cs" Inherits="Yaesoft.DSI.Web.frmDSIEduRptAllowanceDetail" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="ContentworkPlace" ContentPlaceHolderID="workPlace" runat="server">
<div style="margin:3px;">
    <JWC:ServerAlert ID="errMessage" runat="server" />
    <!--数据显示区域-->
    <JWC:DataGridView ID="dgfrmDSIEduRptAllowanceDetail" runat="server" CssClass="DataGrid" Width="96%" ShowFooter="true"
        AllowSorting="true" AllowPaging="false" AllowExport="true" MouseoverCssClass="DataGridHighLight"
        PageSize="15" onbuilddatasource="dgfrmDSIEduRptAllowanceDetail_BuildDataSource">
        <PagerSettings Mode="NextPreviousFirstLast" />
        <AlternatingRowStyle CssClass="DataGridAlter" />
        <HeaderStyle CssClass="DataGridHeader" />
        <FooterStyle CssClass="DataGridFooter" />
        <RowStyle CssClass="DataGridItem" />
        <Columns>
	        <JWC:BoundFieldEx DataField="ProjectName" HeaderText="申报项目" SortExpression="ProjectName" meta:resourcekey="DSI_DGV_ProjectName">
		        <HeaderStyle Width="14%"  HorizontalAlign="Center" />
		        <ItemStyle HorizontalAlign="Left" />
	        </JWC:BoundFieldEx>
	        
	        <JWC:BoundFieldEx DataField="UnitName" HeaderText="所属单位" SortExpression="UnitName" meta:resourcekey="DSI_DGV_UnitName">
		        <HeaderStyle Width="10%"  HorizontalAlign="Center" />
		        <ItemStyle HorizontalAlign="Left" />
	        </JWC:BoundFieldEx>
			
	        <JWC:BoundFieldEx DataField="StaffName" HeaderText="申报职工" SortExpression="StaffName" meta:resourcekey="DSI_DGV_StaffName">
		        <HeaderStyle Width="6%"  HorizontalAlign="Center" />
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
		        <HeaderStyle Width="6%"  HorizontalAlign="Center" />
		        <ItemStyle HorizontalAlign="Center" />
	        </JWC:BoundFieldEx>
	        
	        <JWC:BoundFieldEx DataField="MaritalstatusName" HeaderText="婚姻" SortExpression="MaritalstatusName" meta:resourcekey="DSI_DGV_MaritalstatusName">
		        <HeaderStyle Width="3%"  HorizontalAlign="Center" />
		        <ItemStyle HorizontalAlign="Center" />
	        </JWC:BoundFieldEx>
	        
	        <JWC:BoundFieldEx DataField="HardCategoryName" HeaderText="困难类别" SortExpression="HardCategoryName" meta:resourcekey="DSI_DGV_HardCategoryName">
		        <HeaderStyle Width="10%"  HorizontalAlign="Center" />
		        <ItemStyle HorizontalAlign="Left" />
	        </JWC:BoundFieldEx>
	        
	        <JWC:BoundFieldEx DataField="HardBecauseName" HeaderText="致困主要原因" SortExpression="HardBecauseName" meta:resourcekey="DSI_DGV_HardBecauseName">
		        <HeaderStyle Width="20%"  HorizontalAlign="Center" />
		        <ItemStyle HorizontalAlign="Left" />
	        </JWC:BoundFieldEx>
	        
	        <JWC:BoundFieldEx DataField="Money" HeaderText="补助金额" SortExpression="Money" DataFormatString="{0:##,###.00}" meta:resourcekey="DSI_DGV_Money">
		        <HeaderStyle Width="6%"  HorizontalAlign="Center" />
		        <ItemStyle HorizontalAlign="Right" ForeColor="Red" />
	        </JWC:BoundFieldEx>
			
	        <JWC:BoundFieldEx DataField="Time" HeaderText="申报时间" SortExpression="Time" DataFormatString="{0:yyyy-MM-dd}" meta:resourcekey="DSI_DGV_Time">
		        <HeaderStyle Width="7%"  HorizontalAlign="Center" />
		        <ItemStyle HorizontalAlign="Center" />
	        </JWC:BoundFieldEx>
        </Columns>
    </JWC:DataGridView>
</div>
</asp:Content>