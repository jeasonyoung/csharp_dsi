//================================================================================
//  FileName: frmDSIPersonalStaffAppFormReqEdit.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-13
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
using Yaesoft.DSI.Engine.Persistence;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmDSIPersonalStaffAppFormReqEdit : ModuleBasePage, IDSIPersonalStaffAppFormReqEditView
    {
        #region 成员变量，构造函数。
        private DSIPersonalStaffAppFormReqPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSIPersonalStaffAppFormReqEdit()
        {
            this.presenter = new DSIPersonalStaffAppFormReqPresenter(this);
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
                this.ucStaffReq.ShowMessageEvent += new Yaesoft.DSI.Engine.ShowMessageHandler(delegate(string msg, string after)
                {
                    this.ShowMessage(msg);
                });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DSIStaffAppFormReq req = new DSIStaffAppFormReq();
                req.ProjectID = this.ddlProject.SelectedValue;
                req.StaffID = this.StaffID.IsValid ? this.StaffID : GUIDEx.New;
                req.CreateUserID = this.CurrentUserID;
                req.CreateUserName = this.CurrentUserName;
                req.CreateTime = DateTime.Now;
                if (this.ucStaffReq.SaveData(req))
                {
                    this.SaveData();
                }
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
            this.LoadComplete += new EventHandler(delegate(object o, EventArgs s)
            {
                this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<DSIStaffAppFormReq>>(delegate(object sender, EntityEventArgs<DSIStaffAppFormReq> e)
                {
                    if (e != null && e.Entity != null)
                    {
                        this.ucStaffReq.LoadData(e.Entity);
                        if (!string.IsNullOrEmpty(e.Entity.ProjectID))
                        {
                            this.ddlProject.Enabled = false;
                        }
                        else if (this.ProjectID.IsValid)
                        {
                            this.SetProject(this.ProjectID);
                            this.ddlProject.Enabled = false;
                        }
                        if (e.Entity.Status > 0)
                        {
                            this.btnSave.Visible = false;
                        }
                    }
                }));
            });
        }
        #endregion

        #region IDSIPersonalStaffAppFormReqEditView 成员
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindProjects(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlProject, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectID"></param>
        public void SetProject(string projectID)
        {
            this.ddlProject.SelectedValue = projectID;
        }
        #endregion

        #region IDSIPersonalStaffAppFormReqView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        #endregion
    }
}