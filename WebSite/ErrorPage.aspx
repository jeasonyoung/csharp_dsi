<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameMasterPage.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Yaesoft.DSI.Web.ErrorPage" %>
<asp:Content ID="ContentMainPlace" ContentPlaceHolderID="MainPlace" runat="server">
    <div style="width:600px; height:400px; padding:10px 15px; background-color:#fffdfd;margin:-9px auto 0; border:solid 1px #eee;">
        <h1><asp:Literal ID="lbTitle" runat="server" /></h1>
        <div style="color:Blue;">
            <h3>如果您无权限访问本页面，您将有如下选择：</h3>
            <ul>
                <li>
                    <h4>返回<a target="_self" href="Default.aspx">首页</a>。</h4>
                </li>
                <li>
                    <h4>如您是基层工会管理人员，需为离退休教职工进行补助申报。</h4>
                    <p>请点击<a target="_self" href="frmDSISchoolStaffAppFormReqList.aspx"><span style="font-style:italic; font-weight:bold; font-size:12pt;">我要代申报</span></a></p>
                </li>
                <li>
                    <h5 style="color:Green;">如果您按上述操作后依旧停留在当前页面，说明您确实没有在本系统中使用权限！</h5>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>