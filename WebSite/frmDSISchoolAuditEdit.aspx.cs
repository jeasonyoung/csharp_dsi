//================================================================================
//  FileName: frmDSISchoolAuditEdit.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-19
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
using iPower.Platform.Engine.Service;

using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmDSISchoolAuditEdit : ModuleBasePage, IDSISchoolAuditEditView
    {
        #region 成员变量，构造函数。
        private DSISchoolAuditPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSISchoolAuditEdit()
        {
            this.presenter = new DSISchoolAuditPresenter(this);
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
            this.ucStaffReq.ShowMessageEvent += new Yaesoft.DSI.Engine.ShowMessageHandler(delegate(string msg, string after)
            {
                this.ShowMessage(msg);
            });
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.LoadComplete += new EventHandler(delegate(object o, EventArgs s)
            {
                this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<DSIStaffAppFormReq>>(delegate(object sender, EntityEventArgs<DSIStaffAppFormReq> e)
                {
                    if (e != null && e.Entity != null)
                    {
                        this.ucStaffReq.LoadData(e.Entity);
                    }
                }));
            });
        }
        #endregion

        #region IDSIAuditAuditView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

        #region IDSIAuditAuditEditView 成员
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