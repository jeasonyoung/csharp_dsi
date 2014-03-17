<%--
//================================================================================
//  FileName: UCStaffFamily.ascx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/22
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
//--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCStaffFamily.ascx.cs" Inherits="Yaesoft.DSI.Web.UCStaffFamily" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>

<fieldset style="float:left; margin-top:1px; margin-left:5px; width:95%;">
    <legend style="float:left;font-weight:bold;">家庭成员</legend>
     <!--家庭成员关系-->
    <JWC:DataGridView ID="dgStaffFamilyMember" runat="server" CssClass="DataGrid" Width="100%" ShowFooter="true"
        AllowSorting="false" AllowPaging="false" AllowExport="false" MouseoverCssClass="DataGridHighLight"
        PageSize="15" onbuilddatasource="dgStaffFamilyMember_BuildDataSource" OnRowDataBound="dgStaffFamilyMember_OnRowDataBound">
        <PagerSettings Mode="NextPreviousFirstLast" />
        <AlternatingRowStyle CssClass="DataGridAlter" />
        <HeaderStyle CssClass="DataGridHeader" />
        <FooterStyle CssClass="DataGridFooter NoPrint" />
        <RowStyle CssClass="DataGridItem" />
        <Columns>
            <JWC:TemplateFieldEx HeaderText="姓名">
                <HeaderStyle Width="10%" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <JWC:TextBoxEx ID="txtMemberName" runat="server" Width="80%" IsRequired="false" RequiredErrorMessage="姓名不能为空！" />
                </ItemTemplate>
            </JWC:TemplateFieldEx>
			
            <JWC:TemplateFieldEx HeaderText="关系">
                 <HeaderStyle Width="8%" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <JWC:DropDownListEx ID="ddlRelation" runat="server" Width="100%" />
                </ItemTemplate>
            </JWC:TemplateFieldEx>
			
			<JWC:TemplateFieldEx HeaderText="性别">
                 <HeaderStyle Width="6%" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <JWC:DropDownListEx ID="ddlGender" runat="server" Width="100%" />
                </ItemTemplate>
            </JWC:TemplateFieldEx>
            
            <JWC:TemplateFieldEx HeaderText="政治面貌">
                 <HeaderStyle Width="10%" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <JWC:DropDownListEx ID="ddlPoliticalFace" runat="server" Width="100%" />
                </ItemTemplate>
            </JWC:TemplateFieldEx>
            
            <JWC:TemplateFieldEx HeaderText="身份证号">
                 <HeaderStyle Width="15%" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <JWC:TextBoxEx ID="txtIDCard" runat="server" Width="100%" ToolTip="身份证号位15或18位半角数字！" ValidationExpression="(^\d{15}$)|(^\d{17}([0-9]|X|x)$)" RegularErrorMessage="身份证号位15或18位半角数字！" />
                </ItemTemplate>
            </JWC:TemplateFieldEx>
            
            <JWC:TemplateFieldEx HeaderText="出生年月">
                 <HeaderStyle Width="8%" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <JWC:TextBoxEx ID="txtBirthday" runat="server" Width="100%" ToolTip="格式应为2012-01"
                        ValidationExpression="\d{4}-\d{2}" RegularErrorMessage="出生日期的时间格式不正确！(格式应为2012-01)" />
                </ItemTemplate>
            </JWC:TemplateFieldEx>
            
            <JWC:TemplateFieldEx HeaderText="健康状况">
                <HeaderStyle Width="9%" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <JWC:DropDownListEx ID="ddlHealthStatus" runat="server" Width="100%" />
                </ItemTemplate>
            </JWC:TemplateFieldEx>
                        
            <JWC:TemplateFieldEx HeaderText="月收入">
                <HeaderStyle Width="7%" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <JWC:TextBoxEx ID="txtIncome" runat="server" Width="100%"  CssClass="NumberTextBoxFlat" Text="0" ToolTip="请输入半角数字！"
	                    ValidationExpression="([\d|,]+)(\.(\d+))?" RegularErrorMessage="月收入请输入半角的数字！"/>
                </ItemTemplate>
            </JWC:TemplateFieldEx>
            
            <JWC:TemplateFieldEx HeaderText="身份">
                 <HeaderStyle Width="9%" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <JWC:DropDownListEx ID="ddlMemberTheidentity" runat="server" Width="100%" />
                </ItemTemplate>
            </JWC:TemplateFieldEx>
            
            <JWC:TemplateFieldEx HeaderText="单位或学校">
                 <HeaderStyle Width="10%" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <JWC:TextBoxEx ID="txtUnitSchool" runat="server" Width="100%" />
                </ItemTemplate>
            </JWC:TemplateFieldEx>
            
            <JWC:TemplateFieldEx>
                <HeaderStyle CssClass="DataGridHeader NoPrint" Width="8%" HorizontalAlign="Center" />
                <ItemStyle CssClass="DataGridItem NoPrint" HorizontalAlign="Center" />
                <HeaderTemplate>
                    <asp:LinkButton ID="btnAddMember" runat="server" Text="[添加成员]" CausesValidation="false" ToolTip="添加家庭成员" OnClick="btnAddMember_OnClick" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="btnSaveMember" runat="server" Text="[确定]" CausesValidation="false" ToolTip="保存家庭成员" OnClick="btnSaveMember_OnClick" />
                    <asp:LinkButton ID="btnDeleteMember" runat="server" Text="[移除]" CausesValidation="false" ToolTip="移除家庭成员" OnClick="btnDeleteMember_OnClick" />
                </ItemTemplate>
            </JWC:TemplateFieldEx>
        </Columns>
    </JWC:DataGridView>    
</fieldset>