//================================================================================
// FileName: frmDSIEmployeeUnitEdit.aspx.cs
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
using System.Collections.Specialized;
using System.Text;

using iPower.Web.Utility;

using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    ///<summary>
    ///frmDSIEmployeeUnitEdit列表页面后台代码。
    ///</summary>
    public partial class frmDSIEmployeeUnitEdit : ModuleBasePage, IDSIEmployeeUnitEditView
    {
        #region 成员变量，构造函数。
        DSIEmployeeUnitPresenter presenter = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmDSIEmployeeUnitEdit()
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

        protected void pbEmployee_OnTextChanged(object sender, EventArgs e)
        {
            this.presenter.QueryAuthorize();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string[] text = new string[0], values = new string[0];
            ListBoxHelper.GetAll(this.lbSelect, out text, out values);
            if (this.presenter.UpdateEntityData(values))
                this.SaveData();
        }

        protected void btnSelect_OnClick(object sender, EventArgs e)
        {
            ListBoxHelper.AddSelected(this.lbMulti, this.lbSelect);
        }

        protected void btnRemove_OnClick(object sender, EventArgs e)
        {
            ListBoxHelper.RemoveSelected(this.lbMulti, this.lbSelect);
        }

        protected void btnRemoveAll_OnClick(object sender, EventArgs e)
        {
            ListBoxHelper.RemoveAll(this.lbMulti, this.lbSelect);
        }

        protected void btnSelectAll_OnClick(object sender, EventArgs e)
        {
            ListBoxHelper.AddAll(this.lbMulti, this.lbSelect);
        }

        #endregion

        #region 重载。
        /// <summary>
        /// 重载。
        /// </summary>
        public override void LoadData()
        {
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<DSIEmployee>>(delegate(object sender, EntityEventArgs<DSIEmployee> e)
            {
                if (e.Entity != null)
                {
                    this.pbEmployee.Text = e.Entity.EmployeeName;
                    this.pbEmployee.Value = e.Entity.EmployeeID;
                    this.pbEmployee.Enabled = false;
                    this.pbEmployee_OnTextChanged(null, EventArgs.Empty);
                }
            }));
        }
        #endregion

        #region IDSIEmployeeUnitEditView 成员

        public GUIDEx EmployeeID
        {
            get
            {
                GUIDEx employeeID = this.RequestGUIEx("EmployeeID");
                if (!employeeID.IsValid)
                    employeeID = this.pbEmployee.Value;
                return employeeID;
            }
        }

        public void BindAuthorize(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.lbSelect, data);
        }

        public void BindNonAuthorize(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.lbMulti, data);
        }

        public void ShowMessage(string Msg)
        {
            this.errMessage.Message = Msg;
        }
        #endregion
    }
}