//================================================================================
//  FileName: frmDSIEduStaffAppFormReqList.aspx.cs
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
    public partial class frmDSIEduStaffAppFormReqList : ModuleBasePage, IDSIEduStaffAppFormReqListView
    {
        #region 成员变量，构造函数。
        private DSIEduStaffAppFormReqPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSIEduStaffAppFormReqList()
        {
            this.presenter = new DSIEduStaffAppFormReqPresenter(this);
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.DeleteData())
                this.LoadData();
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
        protected void dgfrmDSIEduStaffAppFormReqList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmDSIEduStaffAppFormReqList.DataSource = this.presenter.ListDataSource;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.dgfrmDSIEduStaffAppFormReqList.InvokeBuildDataSource();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool DeleteData()
        {
            return this.presenter.DeleteEntityData(this.dgfrmDSIEduStaffAppFormReqList.CheckedValue);
        }
        #endregion

        #region IDSIEduStaffAppFormReqListView 成员
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

        #region IDSIStaffAppFormReqView 成员
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