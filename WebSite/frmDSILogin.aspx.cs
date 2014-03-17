//================================================================================
//  FileName: frmDSILogin.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/6
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
    public partial class frmDSILogin : ModuleBasePage, IDSILoginView
    {
        #region 成员变量，构造函数。
        private DSILoginPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSILogin()
        {
            this.presenter = new DSILoginPresenter(this);
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
                this.CurrentPageTile = "系统登录";
                this.presenter.InitializeComponent();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.presenter.Login();
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }
        #endregion

        #region ILoginView 成员
        /// <summary>
        /// 
        /// </summary>
        public string EmployeePassword
        {
            get { return this.txtLoginPassword.Text.Trim(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmployeeSign
        {
            get { return this.txtLoginSign.Text.Trim(); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            this.errMsg.Message = message;
        }

        #endregion
    }
}