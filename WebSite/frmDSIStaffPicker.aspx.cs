//================================================================================
//  FileName: frmDSIStaffPicker.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-14
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
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using iPower.Web.Utility;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 选择教职工档案。
    /// </summary>
    public partial class frmDSIStaffPicker : ModuleBasePage, IDSIStaffPickerView
    {
        #region 成变量，构造函数。
        private DSIStaffUCPresenter presenter;
        /// <summary>
        /// 
        /// </summary>
        public frmDSIStaffPicker()
        {
            this.presenter = new DSIStaffUCPresenter(this);
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
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            this.presenter.PickerSeacher(this.ddlUnit.SelectedValue, this.txtStaffName.Text.Trim());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string[] text = new string[0], values = new string[0];
            ListBoxHelper.GetSelected(this.listSingleSelect, out text, out values);
            this.SaveData(string.Join(",", text), string.Join(",", values));
        }
        #endregion

        #region IDSIStaffPickerView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindUnits(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlUnit, data);
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsAllUnit
        {
            get
            {
                try
                {
                    string str = this.Request["isAll"];
                    if (!string.IsNullOrEmpty(str)) return bool.Parse(str);
                }
                catch (Exception) { }
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void DisplayStaffs(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.listSingleSelect, data);
        }

        #endregion

        #region IDSIStaffView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            this.errMessage.Message = message;
        }

        #endregion
    }
}