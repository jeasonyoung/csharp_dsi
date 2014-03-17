//================================================================================
//  FileName: frmDSISchoolStaffAllowanceList.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-22
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

using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmDSISchoolStaffAllowanceList : ModuleBasePage, IDSISchoolStaffAllowanceListView
    {
        #region 成员变量，构造函数。
        private DSISchoolStaffAllowancePresenter presenter;
        /// <summary>
        /// 
        /// </summary>
        public frmDSISchoolStaffAllowanceList()
        {
            this.presenter = new DSISchoolStaffAllowancePresenter(this);
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
            if (!this.IsPostBack) this.presenter.InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlYear_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.presenter.ProjectYearChanged();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dgfrmDSISchoolStaffAllowanceList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmDSISchoolStaffAllowanceList.DataSource = this.presenter.ListDataSource;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.dgfrmDSISchoolStaffAllowanceList.InvokeBuildDataSource();
        }
        #endregion

        #region IDSIStaffAllowanceView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

        #region IDSISchoolStaffAllowanceListView 成员
        /// <summary>
        /// 
        /// </summary>
        public string Year
        {
            get { return this.ddlYear.SelectedValue.Trim(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectID
        {
            get { return this.ddlProject.SelectedValue.Trim(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StaffName
        {
            get { return this.txtStaffName.Text.Trim(); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindProjectYears(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlYear, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindProjects(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlProject, data);
        }

        #endregion
    }
}