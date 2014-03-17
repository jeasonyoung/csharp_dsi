//================================================================================
//  FileName: frmDSIStaffAppFormReqPrint.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-16
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

using System.Xml;

using iPower;
using Yaesoft.DSI.Engine.Service;

namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmDSIStaffAppFormReqPrint : ModuleBasePage, IDSIStaffAppFormReqPrintView
    {
        #region 成员变量，构造函数。
        private DSIStaffAppFormReqPrintPresenter presenter;
        /// <summary>
        /// 
        /// </summary>
        public frmDSIStaffAppFormReqPrint()
        {
            this.presenter = new DSIStaffAppFormReqPrintPresenter(this);
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
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.content.Text = this.presenter.PrintContent();
        }
        #endregion

        #region IDSIStaffAppFormReqPrintView 成员
        /// <summary>
        /// 
        /// </summary>
        public GUIDEx StaffID
        {
            get { return this.RequestGUIEx("StaffID"); }
        }
        /// <summary>
        /// 
        /// </summary>
        public GUIDEx ProjectID
        {
            get { return this.RequestGUIEx("ProjectID"); }
        }

        #endregion
    }
}