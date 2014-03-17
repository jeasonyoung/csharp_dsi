//================================================================================
//  FileName: frmDSIPersonalStaffAppFormReqList.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-13
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

using iPower;
using iPower.Platform.Engine.Service;

using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmDSIPersonalStaffAppFormReqList : ModuleBasePage, IDSIPersonalStaffAppFormReqListView
    {
        #region 成员变量，构造函数。
        private DSIPersonalStaffAppFormReqPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSIPersonalStaffAppFormReqList()
        {
            this.presenter = new DSIPersonalStaffAppFormReqPresenter(this);
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
        protected void dgfrmDSIPersonalStaffAppFormReqList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmDSIPersonalStaffAppFormReqList.DataSource = this.presenter.ListDataSource;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            string pid = this.Request["ProjectID"], url = this.btnAdd.PickerPage;
            if (!this.IsPostBack && !string.IsNullOrEmpty(pid) && !string.IsNullOrEmpty(url))
            {
                this.btnAdd.PickerPage = url.Split('?')[0] + "?ProjectID=" + pid;
            }
            if (this.IsPostBack && url.IndexOf('?') > 0)
            {
                this.btnAdd.PickerPage = url.Split('?')[0];
            }

            this.dgfrmDSIPersonalStaffAppFormReqList.InvokeBuildDataSource();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool DeleteData()
        {
            return this.presenter.DeleteEntityData(this.dgfrmDSIPersonalStaffAppFormReqList.CheckedValue);
        }
        #endregion

        #region IDSIPersonalStaffAppFormReqListView 成员
        /// <summary>
        /// 
        /// </summary>
        public string ProjectName
        {
            get { return this.txtProjectName.Text.Trim(); }
        }

        #endregion

        #region IDSIPersonalStaffAppFormReqView 成员
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