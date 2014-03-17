//================================================================================
//  FileName: frmDSISchoolStaffAppFormReqEdit.aspx.cs
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
using iPower.Platform.Engine.Service;

using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmDSISchoolStaffAppFormReqEdit : ModuleBasePage, DSISchoolStaffAppFormReqEditView
    {
        #region 成员变量，构造函数。
        private DSISchoolStaffAppFormReqPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSISchoolStaffAppFormReqEdit()
        {
            this.presenter = new DSISchoolStaffAppFormReqPresenter(this);
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
        protected void pbStaff_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadComplete += new EventHandler(delegate(object o, EventArgs e1)
                {
                    if (string.IsNullOrEmpty(this.ddlProject.SelectedValue))
                    {
                        this.pbStaff.Text = this.pbStaff.Value = string.Empty;
                        this.ShowMessage("请先选择[" + this.lbProjectName.Text.Remove(this.lbProjectName.Text.Length - 1) + "]！");
                        return;
                    }
                    DSIStaffAppFormReq data = new DSIStaffAppFormReq();
                    data.ProjectID = this.ddlProject.SelectedValue;
                    data.StaffID = this.pbStaff.Value;
                    if (this.presenter.LoadStaffAppFormReq(ref data))
                    {
                        this.ucStaffReq.LoadData(data);
                    }
                });
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message);
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
                req.StaffID = this.StaffID.IsValid ? this.StaffID.Value : this.pbStaff.Value;
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
                        this.ddlProject.Enabled = this.pbStaff.Enabled = false;
                        this.ucStaffReq.LoadData(e.Entity);
                    }
                }));
            });
        }
        #endregion

        #region DSISchoolStaffAppFormReqEditView 成员
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="staffName"></param>
        public void SetStaff(string staffID, string staffName)
        {
            this.pbStaff.Text = staffName;
            this.pbStaff.Value = staffID;
        }
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

        #region IDSIStaffAppFormReqView 成员
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