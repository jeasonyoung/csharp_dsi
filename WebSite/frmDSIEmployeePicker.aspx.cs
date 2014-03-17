//================================================================================
// FileName: frmDSIEmployeePicker.aspx.cs
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
using iPower.Web.Utility;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
	///<summary>
	///frmDSIEmployeePicker列表页面后台代码。
	///</summary>
    public partial class frmDSIEmployeePicker : ModuleBasePage, IDSIEmployeePickerView
    {
        #region 成员变量，构造函数。
        DSIEmployeePresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmDSIEmployeePicker()
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

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            this.presenter.PickerSearch();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string[] text = new string[0], values = new string[0];
            ListBoxHelper.GetSelected(this.listSingleSelect, out text, out values);
            this.SaveData(string.Join(",", text), string.Join(",", values));
        }

        #endregion

        #region 重载
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<DSIEmployee>>(delegate(object sender, EntityEventArgs<DSIEmployee> e)
            {
                if (e.Entity != null)
                {
                    this.txtEmployeeName.Text = e.Entity.EmployeeName;
                    this.btnSearch_OnClick(null, EventArgs.Empty);
                    this.listSingleSelect.SelectedValue = this.EmployeeID;
                }
            }));
        }
        #endregion

        #region IDSIEmployeePickerView 成员

        public string EmployeeName
        {
            get { return this.txtEmployeeName.Text.Trim(); }
        }

        public GUIDEx EmployeeID
        {
            get { return this.RequestGUIEx("Value"); }
        }

        public void BindEmployees(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.listSingleSelect, data);
            if (this.EmployeeID.IsValid)
            {
                this.listSingleSelect.SelectedValue = this.EmployeeID;
            }
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        #endregion
    }
}