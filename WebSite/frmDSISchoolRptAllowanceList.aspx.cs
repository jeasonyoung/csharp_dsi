//================================================================================
//  FileName: frmSchoolRptAllowanceList.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-23
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
    public partial class frmDSISchoolRptAllowanceList : ModuleBasePage, IDSISchoolRptAllowanceListView
    {
        #region 成员变量，构造函数。
        private DSISchoolRptAllowancePresenter presenter;
        /// <summary>
        /// 
        /// </summary>
        public frmDSISchoolRptAllowanceList()
        {
            this.presenter = new DSISchoolRptAllowancePresenter(this);
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
        protected void dgfrmSchoolRptAllowanceList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmSchoolRptAllowanceList.DataSource = this.presenter.ListDataSource;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.dgfrmSchoolRptAllowanceList.InvokeBuildDataSource();
        }
        #endregion

        #region IDSISchoolRptAllowanceListView 成员
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="summary"></param>
        public void ShowSummary(object[] summarys)
        {
            this.lbSummary.Text = string.Format("汇总： 总人数 [{0}], 补助总金额 [{1:##,###.00}]", summarys);
        }
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

        #endregion
    }
}