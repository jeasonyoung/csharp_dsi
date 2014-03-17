//================================================================================
//  FileName: frmDSISchoolAuditList.aspx.cs
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
    public partial class frmDSISchoolAuditList : ModuleBasePage, IDSISchoolAuditListView
    {
        #region 成员变量，构造函数。
        private DSISchoolAuditPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSISchoolAuditList()
        {
            this.presenter = new DSISchoolAuditPresenter(this);
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
        protected void dgfrmDSISchoolAuditList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmDSISchoolAuditList.DataSource = this.presenter.ListDataSource;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.dgfrmDSISchoolAuditList.InvokeBuildDataSource();
        }
        #endregion 

        #region IDSISchoolAuditListView 成员
        /// <summary>
        /// 
        /// </summary>
        public string ProjectName
        {
            get { return this.txtProjectName.Text.Trim(); }
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