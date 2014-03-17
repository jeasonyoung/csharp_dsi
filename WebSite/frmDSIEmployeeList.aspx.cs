//================================================================================
// FileName: frmDSIEmployeeList.aspx.cs
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
	///frmDSIEmployeeList列表页面后台代码。
	///</summary>
    public partial class frmDSIEmployeeList : ModuleBasePage, IDSIEmployeeListView
	{
		#region 成员变量，构造函数。
		DSIEmployeePresenter presenter = null;
		///<summary>
		///构造函数。
		///</summary>
		public frmDSIEmployeeList()
		{
			this.presenter = new DSIEmployeePresenter(this);

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
		protected void dgfrmDSIEmployeeList_BuildDataSource(object sender, EventArgs e)
		{
            this.dgfrmDSIEmployeeList.DataSource = this.presenter.ListDataScuore;

		}
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			this.LoadData();

		}
		#endregion

		#region 重载。

		public override void LoadData()
		{
			this.dgfrmDSIEmployeeList.InvokeBuildDataSource();
		}
		#endregion

        #region IDSIEmployeeListView 成员

        public string EmployeeName
        {
            get
            {
                return this.txtEmployeeName.Text.Trim();
            }
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion
    }
}