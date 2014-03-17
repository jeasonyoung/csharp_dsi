//================================================================================
//  FileName: frmDSIEduAudit.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-20
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
    public partial class frmDSIEduAudit : ModuleBasePage, IDSIEduAuditEditView
    {
        #region 成员变量，构造函数。
        private DSIEduAuditPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSIEduAudit()
        {
            this.presenter = new DSIEduAuditPresenter(this);
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
        protected void btnApproval_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.presenter.Audit(float.Parse(this.txtCommitteeAllowance.Text.Trim()),
                                        float.Parse(this.txtLeadershipAllowance.Text.Trim()),
                                        float.Parse(this.txtFinalAllowance.Text.Trim()),
                                        int.Parse(this.rdAuditStatus.SelectedValue)))
                    this.SaveData();
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
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<DSIStaffAppFormReq>>(delegate(object sender, EntityEventArgs<DSIStaffAppFormReq> e)
            {
                if (e != null && e.Entity != null)
                {
                    this.txtCommitteeAllowance.Text = (e.Entity.CommitteeAllowance > 0 ? e.Entity.CommitteeAllowance : e.Entity.PrimaryAllowance).ToString();
                    this.txtLeadershipAllowance.Text = (e.Entity.LeadershipAllowance > 0 ? e.Entity.LeadershipAllowance : e.Entity.PrimaryAllowance).ToString();
                    this.txtFinalAllowance.Text = (e.Entity.FinalAllowance > 0 ? e.Entity.FinalAllowance : e.Entity.PrimaryAllowance).ToString();
                    this.rdAuditStatus.SelectedValue = e.Entity.Status.ToString();
                }
            }));
        }
        #endregion

        #region IDSIAuditView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

        #region IDSIAuditEditView 成员
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