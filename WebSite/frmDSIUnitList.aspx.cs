//================================================================================
// FileName: frmDSIUnitList.aspx.cs
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
	///frmDSIUnitList列表页面后台代码。
	///</summary>
    public partial class frmDSIUnitList : ModuleBasePage, IDSIUnitListView
	{
		#region 成员变量，构造函数。
		DSIUnitPresenter presenter = null;
		///<summary>
		///构造函数。
		///</summary>
		public frmDSIUnitList()
		{
			this.presenter = new DSIUnitPresenter(this);
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
		protected void dgfrmDSIUnitList_BuildDataSource(object sender, EventArgs e)
		{
            this.dgfrmDSIUnitList.DataSource = this.presenter.ListDataSource;
		}
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			this.LoadData();
		}
		#endregion

		#region 重载。
		public override void LoadData()
		{
			this.dgfrmDSIUnitList.InvokeBuildDataSource();				
		}
		#endregion

        #region IDSIUnitListView 成员
        /// <summary>
        /// 错误消息
        /// </summary>
        /// <param name="Msg"></param>
        public void ShowMessage(string Msg)
        {
            this.errMessage.Message = Msg;
        }
        /// <summary>
        /// 单位名
        /// </summary>
        public string Unitname
        {
            get { return this.txtUnitName.Text.Trim(); }
        }
        #endregion
    }
}