<%--
//================================================================================
//  FileName: UCStaffInfo.ascx
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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCStaffInfo.ascx.cs" Inherits="Yaesoft.DSI.Web.UCStaffInfo" %>
<%@ Register TagPrefix="S" TagName="UCStaff" Src="UCStaff.ascx" %>
<script language="javascript" type="text/javascript">
<!--
    $(function() {
        //档案修改记录
        $("#ucstaffinfo_modifyrecord_dg").datagrid({
        url: 'staffModifyRecordHandler.ashx?StaffID=<%=this.ucStaff.StaffID %>',
            fit: true,
            fitColumns: true,
            rownumbers: true,
            pagination: true,
            pagePosition: "bottom",
            pageSize: 20,
            pageList: [20, 30, 40],
            border: true,
            striped: true,
            idField: "id",
            sortName: "CreateTime",
            sortOrder: "desc",
            columns: [[{
                title: "时间",
                field: "CreateTime",
                width: 90,
                sortable: true
            }, {
                title: "变更信息",
                field: "Content",
                width: 398
            }, {
                title: "操作人",
                field: "CreateUserName",
                width: 128,
                sortable: true
            }]]
         });
        //补助记录
        $("#ucstaffinfo_allowance_dg").datagrid({
                url: "staffAllowanceHandler.ashx?StaffID=<%=this.ucStaff.StaffID %>",
                fit: true,
                fitColumns: true,
                rownumbers: true,
                pagination: true,
                pagePosition: "bottom",
                pageSize: 20,
                pageList: [20, 30, 40],
                border: true,
                striped: true,
                idField: "id",
                sortName: "time",
                sortOrder: "asc",
                columns: [[{
                    title: "时间",
                    field: "Time",
                    width: 90,
                    sortable: true
                },{
                    title: "项目",
                    field: "ProjectName",
                    width: 168,
                    sortable: true
                },{
                    title: "所属单位",
                    field: "UnitName",
                    width: 100,
                    sortable: true
                },{
                    title: "职工姓名",
                    field: "StaffName",
                    width: 100,
                    sortable: true
                },{
                    title: "性别",
                    field: "GenderName",
                    align: "center",
                    width: 30,
                    sortable: true
                },{
                    title: "年龄",
                    field: "Age",
                    width: 30,
                    align:"center",
                    sortable: true
                },{
                    title: "金额",
                    field: "Money",
                    align: "right",
                    width: 100,
                    sortable: true
                }]]
        });
    });
//-->
</script>
<div class="easyui-tabs" data-options="fit:true">
    <div title="档案信息" style="background-color:#F5F5F5;">
        <S:UCStaff id="ucStaff" runat="server" />
    </div>
    
    <div title="档案修改记录" style="background-color:#F5F5F5;">
        <table id="ucstaffinfo_modifyrecord_dg"></table>
    </div>
    
    <div title="补助记录" style="background-color:#F5F5F5;">
        <table id="ucstaffinfo_allowance_dg"></table>
    </div>
</div>