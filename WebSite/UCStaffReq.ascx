<%-- 
//================================================================================
//  FileName: UCStaffReq.ascx
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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCStaffReq.ascx.cs" Inherits="Yaesoft.DSI.Web.UCStaffReq" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register TagPrefix="S" TagName="UCStaff" Src="UCStaff.ascx" %>
<div style="float:left">
    <div style="float:left;border:solid 0px red;">
        <S:UCStaff id="ucStaff" runat="server" />
    </div>
    <fieldset style="float:left;margin-top:5px;padding-bottom:5px;">
        <legend style="font-weight:bold;">审批信息</legend>
        <table class="DataGrid" cellpadding="0" cellspacing="0" border="1" style="border-collapse:collapse; width:932px;">
            <tr class="DataGridItem">
                <td rowspan="2" style="width:50px; text-align:center;">基层<br />工会<br />意见</td>
                <td rowspan="2" style="width:298px;">
                    <div style="float:left; width:98%;">
                        <div style="float:left; width:100%;">
                             <JWC:LabelEx ID="lbPrimaryAllowance" runat="server" meta:resourcekey="DSI_PrimaryAllowance" Style="padding-left:5px;">拟申请补助金额：</JWC:LabelEx>
                             <JWC:TextBoxEx ID="txtPrimaryAllowance" runat="server" Width="80px" DataFormatString="{0:##,####.##}" ReadOnly="true"/>
                        </div>
                        <div style="float:left; width:100%;">
                            <div style="float:right;">
                                <JWC:LabelEx ID="lbPrimaryAudit" runat="server" meta:resourcekey="DSI_PrimaryAudit">审核人：</JWC:LabelEx>
                                <JWC:TextBoxEx ID="txtPrimaryAudit" runat="server" Width="80px" ReadOnly="true"/>
                            </div>
                        </div>
                         <div style="float:left; width:100%;">
                            <div style="float:right;">
                                <JWC:LabelEx ID="lbPrimaryAuditTime" runat="server" meta:resourcekey="DSI_PrimaryAuditTime">日期：</JWC:LabelEx>
                                <JWC:TextBoxEx ID="txtPrimaryAuditTime" runat="server" Width="80px" ReadOnly="true"/>
                            </div>
                        </div>
                    </div>
                </td>
                <td style="width:128px;text-align:center;">审查委员意见</td>
                <td style="width:168px;">
                    <div style="float:left; margin-left:10px;">
                         <JWC:LabelEx ID="lbCommitteeAllowance" runat="server" meta:resourcekey="DSI_CommitteeAllowance" Style="padding-left:5px;">拟补助：</JWC:LabelEx>
                         <JWC:TextBoxEx ID="txtCommitteeAllowance" runat="server" Width="80px" DataFormatString="{0:##,####.##}" ReadOnly="true"/>
                    </div>
                </td>
                <td style="width:128px;text-align:center;"> 总责任人意见</td>
                <td>
                     <div style="float:left; margin-left:10px;">
                         <JWC:LabelEx ID="lbFinalAllowance" runat="server" meta:resourcekey="DSI_FinalAllowance" Style="padding-left:5px;">拟补助：</JWC:LabelEx>
                         <JWC:TextBoxEx ID="txtFinalAllowance" runat="server" Width="80px" DataFormatString="{0:##,####.##}" ReadOnly="true"/>
                    </div>
                </td>
            </tr>
             <tr class="DataGridItem">
                <td style="text-align:center;">主管领导意见</td>
                <td>
                    <div style="float:left; margin-left:10px;">
                         <JWC:LabelEx ID="lbLeadershipAllowance" runat="server" meta:resourcekey="DSI_LeadershipAllowance" Style="padding-left:5px;">拟补助：</JWC:LabelEx>
                         <JWC:TextBoxEx ID="txtLeadershipAllowance" runat="server" Width="80px" DataFormatString="{0:##,####.##}" ReadOnly="true"/>
                    </div>
                </td>
                <td style="text-align:center;">领取人签名</td>
                <td>
                    <div style="float:left; margin-left:10px;">
                         <JWC:TextBoxEx ID="txtPayee" runat="server" Width="80px" ReadOnly="true"/>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
</div>