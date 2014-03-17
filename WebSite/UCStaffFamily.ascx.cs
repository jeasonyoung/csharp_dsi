//================================================================================
//  FileName: UCStaffFamily.ascx.cs
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
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;

using iPower;
using iPower.Web.UI;
using Yaesoft.DSI.Engine;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 教职工家庭信息。
    /// </summary>
    public partial class UCStaffFamily : ModuleBaseControl, IDSIStaffFamilyView
    {
        #region 成员变量，构造函数。
        private DSIStaffFamilyPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCStaffFamily()
        {
            this.presenter = new DSIStaffFamilyPresenter(this);
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.presenter.InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dgStaffFamilyMember_BuildDataSource(object sender, EventArgs e)
        {
            this.dgStaffFamilyMember.DataSource = this.FamilyMemberDataSource;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dgStaffFamilyMember_OnRowDataBound(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataGridViewRowType.DataRow)
            {
                List<DSIStaffFamilyMember> dataSource = this.FamilyMemberDataSource;
                if (dataSource != null && dataSource.Count > 0)
                {
                    DSIStaffFamilyMember data = dataSource[e.Row.RowIndex];
                    if (data != null)
                    {
                        //姓名。
                        TextBoxEx txtMemberName = e.Row.Cells[0].FindControl("txtMemberName") as TextBoxEx;
                        if (txtMemberName != null) txtMemberName.Text = data.MemberName;
                        //关系。
                        DropDownListEx ddlRelation = e.Row.Cells[1].FindControl("ddlRelation") as DropDownListEx;
                        if (ddlRelation != null)
                        {
                            this.ListControlsDataSourceBind(ddlRelation, this.presenter.EnumDataSource(typeof(EnumRelation)));
                            ddlRelation.SelectedValue = data.Relation.ToString();
                        }
                        //性别。
                        DropDownListEx ddlGender = e.Row.Cells[2].FindControl("ddlGender") as DropDownListEx;
                        if (ddlGender != null)
                        {
                            this.ListControlsDataSourceBind(ddlGender, this.presenter.EnumDataSource(typeof(EnumGender)));
                            ddlGender.SelectedValue = data.Gender.ToString();
                        }
                        //政治面貌。
                        DropDownListEx ddlPoliticalFace = e.Row.Cells[3].FindControl("ddlPoliticalFace") as DropDownListEx;
                        if (ddlPoliticalFace != null)
                        {
                            this.ListControlsDataSourceBind(ddlPoliticalFace, this.presenter.EnumDataSource(typeof(EnumPoliticalFace)));
                            ddlPoliticalFace.SelectedValue = data.PoliticalFace.ToString();
                        }
                        //身份证号。
                        TextBoxEx txtIDCard = e.Row.Cells[4].FindControl("txtIDCard") as TextBoxEx;
                        if (txtIDCard != null)
                            txtIDCard.Text = data.IDCard;
                        //出生日期。
                        TextBoxEx txtBirthday = e.Row.Cells[5].FindControl("txtBirthday") as TextBoxEx;
                        if (txtBirthday != null && (data.Birthday != DateTime.MinValue && data.Birthday != DateTime.MaxValue))
                        {
                            txtBirthday.Text = string.Format("{0:yyyy-MM}", data.Birthday);
                        }
                        //if (txtIDCard != null && txtBirthday != null)
                        //{
                        //    txtIDCard.Attributes["onchange"] = string.Format("javascript:IDCardToBirthday('{0}','{1}')", txtIDCard.ClientID, txtBirthday.ClientID);
                        //}
                        //健康状况。
                        DropDownListEx ddlHealthStatus = e.Row.Cells[6].FindControl("ddlHealthStatus") as DropDownListEx;
                        if (ddlHealthStatus != null)
                        {
                            this.ListControlsDataSourceBind(ddlHealthStatus, this.presenter.EnumDataSource(typeof(EnumHealthStatus)));
                            ddlHealthStatus.SelectedValue = data.HealthStatus.ToString();
                        }
                        //月收入。
                        TextBoxEx txtIncome = e.Row.Cells[7].FindControl("txtIncome") as TextBoxEx;
                        if (txtIncome != null)
                            txtIncome.Text = string.Format("{0:N2}", data.Income);
                        //身份。
                        DropDownListEx ddlMemberTheidentity = e.Row.Cells[8].FindControl("ddlMemberTheidentity") as DropDownListEx;
                        if (ddlMemberTheidentity != null)
                        {
                            this.ListControlsDataSourceBind(ddlMemberTheidentity, this.presenter.EnumDataSource(typeof(EnumMemberTheidentity)));
                            ddlMemberTheidentity.SelectedValue = data.Theidentity.ToString();
                        }
                        //单位或学校。
                        TextBoxEx txtUnitSchool = e.Row.Cells[9].FindControl("txtUnitSchool") as TextBoxEx;
                        if (txtUnitSchool != null)
                            txtUnitSchool.Text = data.UnitSchool;
                    }
                }
            }
        }

        protected void btnAddMember_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.FamilyMemberDataSource == null) this.FamilyMemberDataSource = new List<DSIStaffFamilyMember>();
                DSIStaffFamilyMember data = new DSIStaffFamilyMember();
                data.MemberID = GUIDEx.New;
                data.Gender = 1;
                this.FamilyMemberDataSource.Add(data);
            }
            finally
            {
                this.LoadData();
            }
        }

        protected void btnSaveMember_OnClick(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                LinkButton btn = sender as LinkButton;
                if (btn != null)
                {
                    DataControlFieldCellEx fieldCellEx = btn.Parent as DataControlFieldCellEx;
                    if (fieldCellEx != null)
                    {
                        DataGridViewRow row = fieldCellEx.Parent as DataGridViewRow;
                        if (row != null)
                        {
                            List<DSIStaffFamilyMember> dataSource = this.FamilyMemberDataSource;
                            if (dataSource != null && dataSource.Count > 0)
                            {
                                DSIStaffFamilyMember data = dataSource[row.RowIndex];
                                if (data != null)
                                {
                                    //姓名。
                                    TextBoxEx txtMemberName = row.Cells[0].FindControl("txtMemberName") as TextBoxEx;
                                    if (txtMemberName != null)
                                    {
                                        string txtName = txtMemberName.Text;
                                        if (txtMemberName.IsRequired && string.IsNullOrEmpty(txtName))
                                        {
                                            this.ShowMessage(txtMemberName.ClientID, txtMemberName.RequiredErrorMessage);
                                            return;
                                        }
                                        data.MemberName = txtMemberName.Text;
                                    }
                                    //关系。
                                    DropDownListEx ddlRelation = row.Cells[1].FindControl("ddlRelation") as DropDownListEx;
                                    if (ddlRelation != null)
                                    {
                                        data.Relation = int.Parse(ddlRelation.SelectedValue);
                                    }
                                    //性别。
                                    DropDownListEx ddlGender = row.Cells[2].FindControl("ddlGender") as DropDownListEx;
                                    if (ddlGender != null)
                                    {
                                        data.Gender = int.Parse(ddlGender.SelectedValue);
                                    }
                                    //政治面貌。
                                    DropDownListEx ddlPoliticalFace = row.Cells[3].FindControl("ddlPoliticalFace") as DropDownListEx;
                                    if (ddlPoliticalFace != null)
                                    {
                                        data.PoliticalFace = int.Parse(ddlPoliticalFace.SelectedValue);
                                    }
                                    //身份证号。
                                    TextBoxEx txtIDCard = row.Cells[4].FindControl("txtIDCard") as TextBoxEx;
                                    if (txtIDCard != null && !string.IsNullOrEmpty(txtIDCard.Text))
                                    {
                                        if (!string.IsNullOrEmpty(txtIDCard.ValidationExpression))
                                        {
                                            if (!new Regex(txtIDCard.ValidationExpression).IsMatch(txtIDCard.Text))
                                            {
                                                this.ShowMessage(txtIDCard.ClientID, txtIDCard.RegularErrorMessage);
                                                return;
                                            }
                                        }
                                        data.IDCard = txtIDCard.Text;
                                    }
                                    //出生日期。
                                    TextBoxEx txtBirthday = row.Cells[5].FindControl("txtBirthday") as TextBoxEx;
                                    if (txtBirthday != null && !string.IsNullOrEmpty(txtBirthday.Text))
                                    {
                                        if (!string.IsNullOrEmpty(txtBirthday.ValidationExpression))
                                        {
                                            if (!new Regex(txtBirthday.ValidationExpression).IsMatch(txtBirthday.Text))
                                            {
                                                this.ShowMessage(txtBirthday.ClientID, txtBirthday.RegularErrorMessage);
                                                return;
                                            }
                                        }
                                        try { data.Birthday = DateTime.Parse(txtBirthday.Text + "-01"); }
                                        catch { }
                                    }
                                    //健康状况。
                                    DropDownListEx ddlHealthStatus = row.Cells[6].FindControl("ddlHealthStatus") as DropDownListEx;
                                    if (ddlHealthStatus != null)
                                    {
                                        data.HealthStatus = int.Parse(ddlHealthStatus.SelectedValue);
                                    }
                                    //月收入。
                                    TextBoxEx txtIncome = row.Cells[7].FindControl("txtIncome") as TextBoxEx;
                                    if (txtIncome != null && !string.IsNullOrEmpty(txtIncome.Text))
                                    {
                                        if (!string.IsNullOrEmpty(txtIncome.ValidationExpression))
                                        {
                                            if (!new Regex(txtIncome.ValidationExpression).IsMatch(txtIncome.Text))
                                            {
                                                this.ShowMessage(txtIncome.ClientID, txtIncome.RegularErrorMessage);
                                                return;
                                            }
                                        }
                                        try { data.Income = float.Parse(txtIncome.Text); }
                                        catch { }
                                    }
                                    //身份。
                                    DropDownListEx ddlMemberTheidentity = row.Cells[8].FindControl("ddlMemberTheidentity") as DropDownListEx;
                                    if (ddlMemberTheidentity != null)
                                    {
                                        data.Theidentity = int.Parse(ddlMemberTheidentity.SelectedValue);
                                    }
                                    //单位或学校。
                                    TextBoxEx txtUnitSchool = row.Cells[9].FindControl("txtUnitSchool") as TextBoxEx;
                                    if (txtUnitSchool != null)
                                        data.UnitSchool = txtUnitSchool.Text;
                                    result = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
            finally
            {
                if (result) this.LoadData();
            }
        }

        protected void btnDeleteMember_OnClick(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                if (btn != null)
                {
                    DataControlFieldCellEx fieldCellEx = btn.Parent as DataControlFieldCellEx;
                    if (fieldCellEx != null)
                    {
                        DataGridViewRow row = fieldCellEx.Parent as DataGridViewRow;
                        if (row != null)
                        {
                            List<DSIStaffFamilyMember> dataSource = this.FamilyMemberDataSource;
                            if (dataSource != null && dataSource.Count > 0)
                            {
                                dataSource.RemoveAt(row.RowIndex);
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
            finally
            {
                this.LoadData();
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 加载数据。
        /// </summary>
        public override void LoadData()
        {
            List<DSIStaffFamilyMember> listMembers = this.FamilyMemberDataSource;
            if (listMembers == null ||  listMembers.Count == 0)
            {
                listMembers = new List<DSIStaffFamilyMember>();

                DSIStaffFamilyMember member0 = new DSIStaffFamilyMember();
                member0.MemberID = GUIDEx.New;
                member0.Gender = 1;
                listMembers.Add(member0);

                DSIStaffFamilyMember member1 = new DSIStaffFamilyMember();
                member1.MemberID = GUIDEx.New;
                member1.Gender = 1;
                listMembers.Add(member1);

                DSIStaffFamilyMember member2 = new DSIStaffFamilyMember();
                member2.MemberID = GUIDEx.New;
                member2.Gender = 1;
                listMembers.Add(member2);

                //DSIStaffFamilyMember member3 = new DSIStaffFamilyMember();
                //member3.MemberID = GUIDEx.New;
                //member3.Gender = 1;
                //listMembers.Add(member3);

                this.FamilyMemberDataSource = listMembers;
            }
            this.dgStaffFamilyMember.InvokeBuildDataSource();
        }
        #endregion

        #region 辅助函数。
        private void ShowMessage(string clientID, string message)
        {
            StringBuilder script = new StringBuilder();
            if (!string.IsNullOrEmpty(clientID))
            {
                script.AppendFormat("$('#{0}').focus();", clientID);
            }
            ShowMessageHandler handler = this.ShowMessageEvent;
            if (handler != null) handler(message, script.ToString());
        }
        #endregion

        #region IDSIStaffFamilyView 成员
        /// <summary>
        /// 
        /// </summary>
        public List<DSIStaffFamilyMember> FamilyMemberDataSource
        {
            get
            {
                return (this.ViewState["FamilyMemberDataSource"] as List<DSIStaffFamilyMember>);
            }
            set
            {
                this.ViewState["FamilyMemberDataSource"] = value;
            }
        }
        /// <summary>
        /// 消息事件。
        /// </summary>
        public event ShowMessageHandler ShowMessageEvent;
        /// <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            this.ShowMessage(null, message);
        }
        #endregion
    }
}