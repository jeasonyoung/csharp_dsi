<%--
//================================================================================
//  FileName: UCStaff.ascx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-15
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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCStaff.ascx.cs" Inherits="Yaesoft.DSI.Web.UCStaff" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.Upload" tagprefix="JWC" %>
<%@ Register TagPrefix="Staff" TagName="UCStaffFamilyMember" Src="UCStaffFamily.ascx" %>
<script language="javascript" type="text/javascript">
<!--
    $(function() {
        //计算平均数。
        function CalculateAvgIncome(allClientID, perClientID, targetClientID) {
            try {
                var reg = /^(([\d|,]+)(\.(\d+))?)$/

                var all = $("#" + allClientID).val();
                var per = $("#" + perClientID).val();
                var target = $("#" + targetClientID);

                if (reg.test(all) && reg.test(per) && (per != "0")) {
                    target.val(ForDight(parseFloat(all.replace(/,/g, '')) / parseFloat(per), 2));
                }
            } catch (e) {
                alert(e.description);
            }
        };
        //计算结果保留几位小数。
        function ForDight(data, how) {
            return Math.round(data * Math.pow(10, how)) / Math.pow(10, how);
        };
        //计算家庭年人均收入。
        $("#<%= this.txtFamilyIncome.ClientID %>").change(function() {
            CalculateAvgIncome("<%=this.txtFamilyIncome.ClientID %>", "<%=this.txtFamilyCount.ClientID %>", "<%=this.txtFamilyAvgIncome.ClientID %>");
        });
        $("#<%=this.txtFamilyCount.ClientID %>").change(function() {
            CalculateAvgIncome("<%=this.txtFamilyIncome.ClientID %>", "<%=this.txtFamilyCount.ClientID %>", "<%=this.txtFamilyAvgIncome.ClientID %>");
        });
    });
//-->
</script>
<style type="text/css">
    .TextBoxFlat,.NumberTextBoxFlat,.BorderDropDownList
    {
    	border-top:solid 0px #000;
    	border-left:solid 0px #000;
    	border-right:solid 0px #000;
    	border-bottom:solid 1px #000;
    }
    .ErrorTextBoxFlat
    {
    	border:solid 1px red;
    }
</style>
<table class="DataGrid" cellpadding="0" cellspacing="0" border="1" style="border-collapse:collapse;">
   <tr class="DataGridItem">
        <td style="text-align:center;">
            <JWC:LabelEx ID="lbStaffCode" runat="server" meta:resourcekey="DSI_StaffCode">职工编号</JWC:LabelEx>
        </td>
        <td colspan="3">
            <JWC:TextBoxEx ID="txtStaffCode" runat="server" Width="198px" IsRequired="true" RequiredErrorMessage="教职工编号不能为空！" />
        </td>
        <td style="text-align:center;">
            <JWC:LabelEx ID="lbTheidentity" runat="server" meta:resourcekey="DSI_Theidentity">身份</JWC:LabelEx>
        </td>
        <td style="text-align:center;">
            <JWC:DropDownListEx ID="ddlTheidentity" runat="server" Width="120px" IsRequired="true" ErrorMessage="身份不能为空！" />
        </td>
        <td style="text-align:center;">
            <JWC:LabelEx ID="lbHardCategory" runat="server" meta:resourcekey="DSI_HardCategory">困难类别</JWC:LabelEx>
        </td>
        <td style="text-align:center;">
            <JWC:DropDownListEx ID="ddlHardCategory" runat="server" Width="120px" IsRequired="true" ErrorMessage="困难类别不能为空！" />
        </td>
   </tr>
   <tr class="DataGridItem">
        <td style="width:120px;text-align:center;">
            <JWC:LabelEx ID="lbStaffName" runat="server" meta:resourcekey="DSI_StaffName">姓名</JWC:LabelEx>
        </td>
        <td style="width:100px;text-align:center;">
            <JWC:LabelEx ID="lbPeople" runat="server" meta:resourcekey="DSI_People">民族</JWC:LabelEx>
        </td>
        <td style="width:80px;text-align:center;">
            <JWC:LabelEx ID="lbGender" runat="server" meta:resourcekey="DSI_Gender">性别</JWC:LabelEx>
        </td>
        <td style="width:100px;text-align:center;">
            <JWC:LabelEx ID="lbPoliticalFace" runat="server" meta:resourcekey="DSI_PoliticalFace">政治面貌</JWC:LabelEx>
        </td>
        <td style="width:128px;text-align:center;">
            <JWC:LabelEx ID="lbBirthday" runat="server" meta:resourcekey="DSI_Birthday">出生年月</JWC:LabelEx>
        </td>
        <td style="width:168px;text-align:center;">
            <JWC:LabelEx ID="lbIDCard" runat="server" meta:resourcekey="DSI_IDCard">身份证号</JWC:LabelEx>
        </td>
        <td style="width:100px;text-align:center;">
            <JWC:LabelEx ID="lbHealthStatus" runat="server" meta:resourcekey="DSI_HealthStatus">健康状况</JWC:LabelEx>
        </td>
        <td style="width:138px;text-align:center;">
            <JWC:LabelEx ID="lbDisability" runat="server" meta:resourcekey="DSI_Disability">疾病名称/残疾类别</JWC:LabelEx>
        </td>
   </tr>
   <tr class="DataGridItem">
        <td style="text-align:center;">
            <JWC:TextBoxEx ID="txtStaffName" runat="server" Width="80px" IsRequired="true" RequiredErrorMessage="教职工姓名不能为空！"  />
        </td>
        <td style="text-align:center;">
            <JWC:DropDownListEx ID="ddlPeople" runat="server" Width="90px" IsRequired="true" ErrorMessage="民族不能为空！" />
        </td>
        <td style="text-align:center;">
            <JWC:DropDownListEx ID="ddlGender" runat="server" Width="56px" />
        </td>
        <td style="text-align:center;">
            <JWC:DropDownListEx ID="ddlPoliticalFace" runat="server" Width="90px" />
        </td>
        <td style="text-align:center;">
            <JWC:TextBoxEx  ID="txtBirthday" runat="server" IsRequired="true" ToolTip="格式应为：2012-01" ValidationExpression="\d{4}-\d{2}" RegularErrorMessage="出生年月格式不正确！(格式应为：2012-01)" Width="126px" />
        </td>
        <td style="text-align:center;">
            <JWC:TextBoxEx ID="txtIDCard" runat="server" Width="128px" IsRequired="true" RequiredErrorMessage="教职工身份证号不能为空！" ValidationExpression="(^\d{15}$)|(^\d{17}([0-9]|X|x)$)" RegularErrorMessage="身份证号为15或18位半角数字！"  />
        </td>
        <td style="text-align:center;">
            <JWC:DropDownListEx ID="ddlHealthStatus" runat="server" Width="70px" IsRequired="true" ErrorMessage="健康状况不能为空！" />
        </td>
        <td>
             <JWC:TextBoxEx ID="txtDisability" runat="server" Width="128px"/>
        </td>
   </tr>
   <tr class="DataGridItem">
        <td style="text-align:center;">
            <JWC:LabelEx ID="lbHouseType" runat="server" meta:resourcekey="DSI_HouseType">住房类型</JWC:LabelEx>
        </td>
        <td colspan="3" style="text-align:center;">
            <JWC:LabelEx ID="lbBuildArea" runat="server" meta:resourcekey="DSI_BuildArea">建筑面积</JWC:LabelEx>
        </td>
        <td style="text-align:center;">
            <JWC:LabelEx ID="lbZipCode" runat="server" meta:resourcekey="DSI_ZipCode">邮政编码</JWC:LabelEx>
        </td>
        <td style="text-align:center;">
            <JWC:LabelEx ID="lbContact" runat="server" meta:resourcekey="DSI_Contact">联系电话</JWC:LabelEx>
        </td>
        <td style="text-align:center;">
            <JWC:LabelEx ID="lbTimeWorkStart" runat="server" meta:resourcekey="DSI_TimeWorkStart">参加工作年月</JWC:LabelEx>
        </td>
        <td style="text-align:center;">
            <JWC:LabelEx ID="lbMaritalstatus" runat="server" meta:resourcekey="DSI_Maritalstatus">婚姻状况</JWC:LabelEx>
        </td>
   </tr>
   <tr class="DataGridItem">
        <td style="text-align:center;">
            <JWC:DropDownListEx ID="ddlHouseType" runat="server" Width="110px" />
        </td>
        <td colspan="3" style="text-align:center;">
            <JWC:TextBoxEx ID="txtBuildArea" runat="server" Width="168px" CssClass="NumberTextBoxFlat" Text="0" ToolTip="请输入半角数字！"
             ValidationExpression="(\d+)(\.(\d+))?" RegularErrorMessage="建筑面积请输入半角的数字！" />
            <span>(平方米)</span>
        </td>
        <td style="text-align:center;">
            <JWC:TextBoxEx ID="txtZipCode" runat="server" Width="120px"  />
        </td>
        <td style="text-align:center;">
            <JWC:TextBoxEx ID="txtContact" runat="server" Width="128px"  />
        </td>
        <td style="text-align:center;">
            <JWC:TextBoxEx ID="txtTimeWorkStart" runat="server" ToolTip="格式应为：2012-01" ValidationExpression="\d{4}-\d{2}" RegularErrorMessage="参加工作年月格式不正确！(格式应为：2012-01)" Width="90px" />
        </td>
        <td>
            <JWC:DropDownListEx ID="ddlMaritalstatus" runat="server" Width="80px" />
        </td>
   </tr>
   <tr class="DataGridItem">
        <td colspan="4" style="text-align:center;">
            <JWC:LabelEx ID="lbUnit" runat="server" meta:resourcekey="DSI_Unit">工作单位</JWC:LabelEx>
        </td>
        <td colspan="2" style="text-align:center;">
            <JWC:LabelEx ID="lbAddress" runat="server" meta:resourcekey="DSI_Address">家庭住址</JWC:LabelEx>
        </td>
        <td colspan="2" style="text-align:center;">
            <JWC:LabelEx ID="lbSelfHelp" runat="server" meta:resourcekey="DSI_SelfHelp">是否有一定自救能力</JWC:LabelEx>
        </td>
   </tr>
    <tr class="DataGridItem">
        <td colspan="4" style="text-align:center;">
            <JWC:DropDownListEx ID="ddlUnit" runat="server" Width="328px" IsRequired="true" ErrorMessage="工作单位不能为空！"  />
        </td>
        <td colspan="2" style="text-align:center;">
            <JWC:TextBoxEx ID="txtAddress" runat="server" Width="268px"  />
        </td>
        <td colspan="2" style="text-align:center;">
            <div style="float:left; margin-left:40px;">
                <JWC:RadioButtonListEx ID="rdSelfHelp" runat="server"  RepeatDirection="Horizontal" BorderWidth="0px" IsRequired="true" ErrorMessage="请选中是否有一定自救能力！" />
            </div>
        </td>
   </tr>
   <tr class="DataGridItem">
        <td colspan="4" style="text-align:center;">
            <JWC:LabelEx ID="lbAvgIncome" runat="server" meta:resourcekey="DSI_AvgIncome">本人月平均收入</JWC:LabelEx>
        </td>
        <td style="text-align:center;">
            <JWC:LabelEx ID="lbFamilyIncome" runat="server" meta:resourcekey="DSI_FamilyIncome">家庭年度总收入</JWC:LabelEx>
        </td>
        <td style="text-align:center;">
            <JWC:LabelEx ID="lbFamilyCount" runat="server" meta:resourcekey="DSI_FamilyCount">家庭人口</JWC:LabelEx>
        </td>
        <td colspan="2" style="text-align:center;">
            <JWC:LabelEx ID="lbFamilyAvgIncome" runat="server" meta:resourcekey="DSI_FamilyAvgIncome">家庭年人均收入</JWC:LabelEx>
        </td>
   </tr>
   <tr class="DataGridItem">
        <td colspan="4" style="text-align:center;">
            <JWC:TextBoxEx ID="txtAvgIncome" runat="server" Width="128px" CssClass="NumberTextBoxFlat" Text="0" ToolTip="请输入半角数字！" ValidationExpression="([\d|,]+)(\.(\d+))?" RegularErrorMessage="本人月平均收入请输入半角的数字！" />
        </td>
        <td style="text-align:center;">
            <JWC:TextBoxEx ID="txtFamilyIncome" runat="server"  Width="100px" CssClass="NumberTextBoxFlat" Text="0" ToolTip="请输入半角数字！" ValidationExpression="([\d|,]+)(\.(\d+))?" RegularErrorMessage="家庭年度总收入请输入半角的数字！"/>
        </td>
        <td style="text-align:center;">
            <JWC:TextBoxEx ID="txtFamilyCount" runat="server" Width="100px" OnlyNumber="true" CssClass="NumberTextBoxFlat" Text="0" ToolTip="请输入半角数字！" ValidationExpression="(\d+)" RegularErrorMessage="家庭人口请输入半角的数字！" />
        </td>
        <td colspan="2" style="text-align:center;">
            <JWC:TextBoxEx ID="txtFamilyAvgIncome" runat="server" Width="128px" CssClass="NumberTextBoxFlat" Text="0" ToolTip="请输入半角数字！" ValidationExpression="([\d|,]+)(\.(\d+))?" RegularErrorMessage="家庭年人均收入请输入半角的数字！"/>
        </td>
   </tr>
   <tr class="DataGridItem">
        <td colspan="8" style=" padding-top:2px; padding-bottom:2px; padding-left:1px; padding-right:1px;">
           <Staff:UCStaffFamilyMember ID="ucStaffFamily" runat="server" />
        </td>
   </tr>
   <tr class="DataGridItem">
        <td style="text-align:center;">
            <JWC:LabelEx ID="lbHardBecause" runat="server" meta:resourcekey="DSI_HardBecause">致困主要原因</JWC:LabelEx>
        </td>
        <td colspan="7" style="text-align:center;">
            <JWC:DropDownListEx ID="ddlHardBecause" runat="server" Width="428px" IsRequired="true" ErrorMessage="致困主要原因不能为空！" />
        </td>
   </tr>
   <tr class="DataGridItem">
        <td colspan="8" style="padding:2px;">
          <fieldset style="margin-top:2px;">
               <legend style="font-weight:bold;">证明材料上传</legend>
               <JWC:UploadView ID="uploadAttachments" runat="server" Width="95%" MaxUploadSize="10" MaxUploadCount="10" DownloadBaseURI="AccessoriesDownload.ashx?FileID=" AllowOfficeOnlineEdit="false" OnUploadViewExceptionEvent="uploadAttachments_OnUploadViewExceptionEvent" />
          </fieldset>
        </td>
   </tr>
   <tr class="DataGridItem">
        <td style="text-align:center;">
            <JWC:LabelEx ID="lbHardBecauseDesc" runat="server" meta:resourcekey="DSI_HardBecauseDesc">其他情况补充说明</JWC:LabelEx>
        </td>
        <td colspan="7" style="text-align:center;">
            <JWC:TextBoxEx ID="txtHardBecauseDesc" runat="server" Width="95%" TextMode="MultiLine" Rows="3" />
        </td>
   </tr>
</table>