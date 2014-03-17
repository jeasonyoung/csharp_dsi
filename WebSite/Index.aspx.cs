//================================================================================
//  FileName: Index.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-25
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

using Yaesoft.DSI.Engine.Persistence;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Index : ModuleBasePage, IDSIIndexView
    {
        #region 成员变量，构造函数。
        private DSIIndexPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Index()
        {
            this.presenter = new DSIIndexPresenter(this);
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {
            this.Theme = "";
            base.OnPreInit(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.CurrentUserID.IsValid)
            {
                string url = ModuleConfiguration.ModuleConfig.MyDesktopURL;
                if (!string.IsNullOrEmpty(url))
                {
                    this.Response.Redirect(url, true);
                }
            }
            else if (!this.IsPostBack)
            {
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
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.presenter.LoadEntityData();
        }
        #endregion

        #region ILoginView 成员
        /// <summary>
        /// 
        /// </summary>
        public string EmployeeSign
        {
            get { return this.txtLoginAccount.Value.Trim(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmployeePassword
        {
            get { return this.txtLoginPassword.Value.Trim(); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            this.errMessage.Message = message;
        }

        #endregion

        #region IDSIIndexView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="indicators"></param>
        public void RenderCarouselIndicators(string[] indicators)
        {
            this.liIndicators.Text = string.Concat(indicators);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public void RenderItems(string[] items)
        {
            this.liItems.Text = string.Concat(items);
        }

        #endregion
    }
}