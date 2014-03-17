//================================================================================
//  FileName: UCStaffInfo.ascx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/22
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
using iPower.Web.UI;

using Yaesoft.DSI.Engine;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 教职工基本信息。
    /// </summary>
    public partial class UCStaffInfo : ModuleBaseControl, IDSIStaffInfoUCView
    {
        #region 成员变量，构造函数。
        private DSIStaffInfoUCPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCStaffInfo()
        {
            this.presenter = new DSIStaffInfoUCPresenter(this);
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
            this.ucStaff.ShowMessageEvent += new ShowMessageHandler(delegate(string msg, string afterscript)
            {
                this.ShowMessage(msg, afterscript);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="afterAlertScript"></param>
        protected void ShowMessage(string message, string afterAlertScript)
        {
            ShowMessageHandler handler = this.ShowMessageEvent;
            if (handler != null) handler(message, afterAlertScript);
        }
        #endregion

        #region IDSIStaffInfoUCView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void LoadData(DSIStaffInfo data)
        {
            this.ucStaff.LoadData(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SaveData(DSIStaffInfo data)
        {
            return this.ucStaff.SaveData(data);
        }
        /// <summary>
        /// 
        /// </summary>
        public event ShowMessageHandler ShowMessageEvent;
        #endregion
    }
}