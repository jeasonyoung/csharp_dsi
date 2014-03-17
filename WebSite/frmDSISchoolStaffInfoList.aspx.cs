//================================================================================
//  FileName: frmDSISchoolStaffInfoList.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-9
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
    public partial class frmDSISchoolStaffInfoList : ModuleBasePage, IDSISchoolStaffInfoListView
    {
        #region 成员变量，构造函数。
        private DSISchoolStaffInfoPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSISchoolStaffInfoList()
        {
            this.presenter = new DSISchoolStaffInfoPresenter(this);
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
            {
                this.presenter.InitializeComponent();
            }
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
        protected void dgfrmDSISchoolStaffInfoList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmDSISchoolStaffInfoList.DataSource = this.presenter.ListDataSource;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.dgfrmDSISchoolStaffInfoList.InvokeBuildDataSource();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteEntityData(this.dgfrmDSISchoolStaffInfoList.CheckedValue);
        }
        #endregion

        #region IDSISchoolStaffInfoListView 成员
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
        public string StaffCodeNameCard
        {
            get { return this.txtStaffNameCodeCard.Text.Trim(); }
        }

        #endregion

        #region IDSISchoolStaffInfoView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

        #region IDSISchoolStaffInfoListView 成员

       

        #endregion
    }
}