//================================================================================
//  FileName: frmDSIProjectEdit.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-11
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
    public partial class frmDSIProjectEdit : ModuleBasePage,IDSIProjectEditView
    {
        #region 成员变量，构造函数。
        private DSIProjectPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSIProjectEdit()
        {
            this.presenter = new DSIProjectPresenter(this);
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
                this.uploadAttachments.FileIDField = "ID";
                this.uploadAttachments.FileNameField = "Name";
                this.uploadAttachments.ExtensionField = "Ext";
                this.uploadAttachments.SizeField = "Size";

                this.presenter.InitializeComponent();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected void uploadAttachments_OnUploadViewExceptionEvent(Exception e)
        {
            if (e != null)
            {
                this.ShowMessage("上传附件时发生异常：" + e.Message);
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
                DSIProject data = new DSIProject();
                data.ProjectID = this.ProjectID.IsValid ? this.ProjectID : GUIDEx.New;
                data.ProjectName = this.txtProjectName.Text.Trim();
                data.StartTime = DateTime.Parse(this.txtStartTime.Text.Trim());
                data.EndTime = DateTime.Parse(this.txtEndTime.Text.Trim());
                data.IsView = int.Parse(this.rdIsView.SelectedValue);
                data.Content = this.txtContent.Text.Trim();
                data.CreateTime = DateTime.Now;
                data.CreateUserID = this.CurrentUserID;
                data.CreateUserName = this.CurrentUserName;

                this.uploadAttachments.SaveUploadAs(new EventHandler<iPower.Web.Upload.UploadViewEventArgs>(delegate(object o, iPower.Web.Upload.UploadViewEventArgs el)
                {
                    if (el != null && el.ItemRaw != null)
                    {
                        DSIAttachment attachment = new DSIAttachment();
                        attachment.ID = el.ItemRaw.FileID;
                        attachment.Name = el.ItemRaw.FileName;
                        attachment.ContentType = el.ItemRaw.ContentType;
                        attachment.Create = DateTime.Now;
                        attachment.Raw = el.ItemRaw.FileRaw;

                        if (data.Attachments == null) data.Attachments = new List<DSIAttachment>();
                        data.Attachments.Add(attachment);
                    }
                }));

                if (this.presenter.UpdateEntityData(data, this.uploadAttachments.DeleteFileID))
                    this.SaveData();
            }
            catch (Exception ex)
            {
                this.errMessage.Message = ex.Message;
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override bool ViewStateInServer
        {
            get
            {
                return this.CurrentUserID.IsValid;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<DSIProject>>(delegate(object sender, EntityEventArgs<DSIProject> e)
            {
                if (e != null && e.Entity != null)
                {
                    this.txtProjectName.Text = e.Entity.ProjectName;
                    this.txtStartTime.Text = string.Format("{0:yyyy-MM-dd}", e.Entity.StartTime);
                    this.txtEndTime.Text = string.Format("{0:yyyy-MM-dd}", e.Entity.EndTime);
                    this.txtContent.Text = e.Entity.Content;
                    this.rdIsView.SelectedValue = e.Entity.IsView.ToString();

                    this.uploadAttachments.DataSource = e.Entity.Attachments;
                    this.uploadAttachments.BuildUploadView();
                }
            }));
        }
        #endregion

        #region IDSIProjectEditView 成员
        /// <summary>
        /// 
        /// </summary>
        public GUIDEx ProjectID
        {
            get { return this.RequestGUIEx("ProjectID"); }
        }

        #endregion

        #region IDSIProjectView 成员
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
