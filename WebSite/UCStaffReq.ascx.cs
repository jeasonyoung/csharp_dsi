//================================================================================
//  FileName: UCStaffReq.ascx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-15
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

using Yaesoft.DSI.Engine;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCStaffReq : ModuleBaseControl, IDSIStaffReqUCView
    {
        #region 成员变量，构造函数。
        private DSIStaffReqUCPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCStaffReq()
        {
            this.presenter = new DSIStaffReqUCPresenter(this);
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
            this.ucStaff.ShowMessageEvent += new ShowMessageHandler(delegate(string msg, string after)
            {
                this.ShowMessage(msg, after);
            });
        }
        #endregion

        #region IDSIStaffReqUCView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void LoadData(DSIStaffAppFormReq data)
        {
            this.ucStaff.LoadData(data.Staff);
            if (data.PrimaryAllowance > 0)
            {
                this.txtPrimaryAllowance.Text = string.Format("{0}", data.PrimaryAllowance);
                this.txtPrimaryAudit.Text = data.PrimaryAudit;
                this.txtPrimaryAuditTime.Text = string.Format("{0:yyyy-MM-dd}", data.PrimaryAuditTime);
            }
            if (data.CommitteeAllowance > 0)
            {
                this.txtCommitteeAllowance.Text = string.Format("{0}", data.CommitteeAllowance);
            }
            if (data.LeadershipAllowance > 0)
            {
                this.txtLeadershipAllowance.Text = string.Format("{0}", data.LeadershipAllowance);
            }
            if (data.FinalAllowance > 0)
            {
                this.txtFinalAllowance.Text = string.Format("{0}", data.FinalAllowance);
            }
            this.txtPayee.Text = data.Payee;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SaveData(DSIStaffAppFormReq data)
        {
            if (data.Staff == null)
            {
                data.Staff = new DSIStaffInfo();
                data.Staff.StaffID = data.StaffID;
            }
            if (this.presenter.UpdateEntityData(data))
            {
                return this.ucStaff.SaveData(data.Staff);
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        public event ShowMessageHandler ShowMessageEvent;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMessage(string msg)
        {
            this.ShowMessage(msg, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="afterscript"></param>
        protected void ShowMessage(string msg, string afterscript)
        {
            ShowMessageHandler handler = this.ShowMessageEvent;
            if (handler != null) handler(msg, afterscript);
        }
        #endregion
    }
}