//================================================================================
//  FileName: frmDSIEduAuditList.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-19
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
    public partial class frmDSIEduAuditList : ModuleBasePage, IDSIEduAuditListView
    {
        #region 成员变量，构造函数。
        private DSIEduAuditPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSIEduAuditList()
        {
            this.presenter = new DSIEduAuditPresenter(this);
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
        protected void dgfrmDSIEduAuditList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmDSIEduAuditList.DataSource = this.presenter.ListDataSource;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.dgfrmDSIEduAuditList.InvokeBuildDataSource();
        }
        #endregion

        #region IDSIEduAuditListView 成员
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
        /// <summary>
        /// 
        /// </summary>
        public string UnitName
        {
            get { return this.txtUnitName.Text.Trim(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StaffName
        {
            get { return this.txtStaffName.Text.Trim(); }
        }

        #endregion

        #region IDSIAuditAuditView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        #endregion
    }
}