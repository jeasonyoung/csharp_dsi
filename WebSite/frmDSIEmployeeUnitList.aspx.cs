//================================================================================
// FileName: frmDSIEmployeeUnitList.aspx.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
	
using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    ///<summary>
    ///frmDSIEmployeeUnitList列表页面后台代码。
    ///</summary>
    public partial class frmDSIEmployeeUnitList : ModuleBasePage, IDSIEmployeeUnitListView
    {
        #region 成员变量，构造函数。
        DSIEmployeeUnitPresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmDSIEmployeeUnitList()
        {
            this.presenter = new DSIEmployeeUnitPresenter(this);
        }
        #endregion

        #region 事件处理。

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.presenter.InitializeComponent();
            }
        }

        protected void dgfrmDSIEmployeeUnitList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmDSIEmployeeUnitList.DataSource = this.presenter.ListDataSource;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.DeleteData())
                this.LoadData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        #endregion

        #region 重载。

        public override void LoadData()
        {
            this.dgfrmDSIEmployeeUnitList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return false;
        }
        #endregion

        #region IDSIEmployeeUnitListView 成员

        public string EmployeeName
        {
            get { return this.txtEmployeeName.Text.Trim(); }
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        #endregion
    }
}