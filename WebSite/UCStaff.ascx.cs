//================================================================================
//  FileName: UCStaff.ascx.cs
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

using iPower;
using iPower.Web.UI;

using Yaesoft.DSI.Engine;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
using Yaesoft.DSI.Engine.Service;

namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCStaff : ModuleBaseControl, IDSIStaffUCView
    {
        #region 成员变量，构造函数。
        private DSIStaffUCPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public UCStaff()
        {
            this.presenter = new DSIStaffUCPresenter(this);
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
            this.ucStaffFamily.ShowMessageEvent += new ShowMessageHandler(delegate(string message, string afterAlertScript)
            {
                this.ShowMessage(message, afterAlertScript);
            });
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
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.txtStaffCode.Text = string.Format("{0:yyyyMMddHHmmssfff}", DateTime.Now);
            if (this.ParentModuleView is IDSIPersonalStaffView)
            {
                this.txtStaffName.Text = this.CurrentUserName;
            }
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

        #region IDSIStaffUCView 成员
        /// <summary>
        /// 
        /// </summary>
        public IModuleView ParentModuleView
        {
            get { return this.Page as ModuleBasePage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public GUIDEx StaffID
        {
            get
            {
                return new GUIDEx(this.ViewState["StaffID"]);
            }
            set
            {
                this.ViewState["StaffID"] = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindHardCategory(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlHardCategory, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindTheidentity(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlTheidentity, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindPeople(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlPeople, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindGender(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlGender, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindPoliticalFace(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlPoliticalFace, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindHouseType(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlHouseType, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindMaritalstatus(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlMaritalstatus, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindUnit(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlUnit, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindHealthStatus(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlHealthStatus, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindSelfHelp(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.rdSelfHelp, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindHardBecause(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlHardBecause, data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void LoadData(DSIStaffInfo data)
        {
            if (data != null)
            {
                this.StaffID = data.StaffID;

                this.txtStaffCode.Text = data.StaffCode;
                this.ddlHardCategory.SelectedValue = data.HardCategory.ToString();
                this.ddlTheidentity.SelectedValue = data.Theidentity.ToString();

                this.txtStaffName.Text = data.StaffName;
                this.ddlPeople.SelectedValue = data.PeopleID;
                this.ddlGender.SelectedValue = data.Gender.ToString();
                this.ddlPoliticalFace.SelectedValue = data.PoliticalFace.ToString();
                this.ddlHealthStatus.SelectedValue = data.HealthStatus.ToString();
                this.txtDisability.Text = data.Disability;

                this.txtIDCard.Text = data.IDCard;
                if (data.Birthday != DateTime.MinValue && data.Birthday != DateTime.MaxValue)
                    this.txtBirthday.Text = string.Format("{0:yyyy-MM}", data.Birthday);
                else
                    this.txtBirthday.Text = string.Empty;

                this.ddlHouseType.SelectedValue = data.HouseType.ToString();
                this.txtBuildArea.Text = string.Format("{0:N2}", data.BuildArea);
                this.txtZipCode.Text = data.ZipCode;
                this.txtContact.Text = data.Contact;

                this.txtAddress.Text = data.Address;
                this.ddlMaritalstatus.SelectedValue = data.Maritalstatus.ToString();

                if (data.TimeWorkStart != DateTime.MinValue && data.TimeWorkStart != DateTime.MaxValue)
                    this.txtTimeWorkStart.Text = string.Format("{0:yyyy-MM}", data.TimeWorkStart);
                else
                    this.txtTimeWorkStart.Text = string.Empty;

                this.ddlUnit.SelectedValue = data.UnitID;

                this.txtAvgIncome.Text = string.Format("{0:N2}", data.AvgIncome);
                this.txtFamilyIncome.Text = string.Format("{0:N2}", data.FamilyIncome);
                this.txtFamilyCount.Text = string.Format("{0}", data.FamilyCount);
                this.txtFamilyAvgIncome.Text = string.Format("{0:N2}", data.FamilyAvgIncome);

                this.rdSelfHelp.SelectedValue = data.SelfHelp.ToString();

                this.ddlHardBecause.SelectedValue = data.HardBecause.ToString();
                this.txtHardBecauseDesc.Text = data.HardBecauseDesc;

                this.uploadAttachments.DataSource = data.Attachments;
                this.uploadAttachments.BuildUploadView();

                this.ucStaffFamily.FamilyMemberDataSource = data.FamilyMembers;
                this.ucStaffFamily.LoadData();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SaveData(DSIStaffInfo data)
        {
            bool result = false;
            if (data == null) return result;

            data.StaffCode = this.txtStaffCode.Text;
            data.HardCategory = int.Parse(this.ddlHardCategory.SelectedValue);
            data.Theidentity = int.Parse(this.ddlTheidentity.SelectedValue);

            data.StaffName = this.txtStaffName.Text;
            data.PeopleID = this.ddlPeople.SelectedValue;
            data.Gender = int.Parse(this.ddlGender.SelectedValue);
            data.PoliticalFace = int.Parse(this.ddlPoliticalFace.SelectedValue);
            data.HealthStatus = int.Parse(this.ddlHealthStatus.SelectedValue);
            data.Disability = this.txtDisability.Text;

            data.IDCard = this.txtIDCard.Text;
            if (!string.IsNullOrEmpty(this.txtBirthday.Text))
                data.Birthday = DateTime.Parse(this.txtBirthday.Text + "-01");

            data.HouseType = int.Parse(this.ddlHouseType.SelectedValue);
            data.BuildArea = float.Parse(this.txtBuildArea.Text);
            data.ZipCode = this.txtZipCode.Text;
            data.Contact = this.txtContact.Text;

            data.Address = this.txtAddress.Text;
            data.Maritalstatus = int.Parse(this.ddlMaritalstatus.SelectedValue);

            if (!string.IsNullOrEmpty(this.txtTimeWorkStart.Text))
                data.TimeWorkStart = DateTime.Parse(this.txtTimeWorkStart.Text + "-01");

            data.UnitID = this.ddlUnit.SelectedValue;

            data.AvgIncome = float.Parse(this.txtAvgIncome.Text);
            data.FamilyIncome = float.Parse(this.txtFamilyIncome.Text);
            data.FamilyCount = int.Parse(this.txtFamilyCount.Text);
            data.FamilyAvgIncome = float.Parse(this.txtFamilyAvgIncome.Text);

            data.SelfHelp = int.Parse(this.rdSelfHelp.SelectedValue);

            data.HardBecause = int.Parse(this.ddlHardBecause.SelectedValue);
            data.HardBecauseDesc = this.txtHardBecauseDesc.Text.Trim();
            data.CreateUserID = this.CurrentUserID;
            data.CreateUserName = this.CurrentUserName;
            data.CreateTime = DateTime.Now;

            data.FamilyMembers = this.ucStaffFamily.FamilyMemberDataSource;

            this.uploadAttachments.SaveUploadAs(new EventHandler<iPower.Web.Upload.UploadViewEventArgs>(delegate(object sender, iPower.Web.Upload.UploadViewEventArgs e)
            {
                if (e != null && e.ItemRaw != null)
                {
                    DSIAttachment attachment = new DSIAttachment();
                    attachment.ID = e.ItemRaw.FileID;
                    attachment.Name = e.ItemRaw.FileName;
                    attachment.ContentType = e.ItemRaw.ContentType;
                    attachment.Create = DateTime.Now;
                    attachment.Raw = e.ItemRaw.FileRaw;

                    if (data.Attachments == null) data.Attachments = new List<DSIAttachment>();
                    data.Attachments.Add(attachment);
                }
            }));

            return this.presenter.UpdateData(data, this.uploadAttachments.DeleteFileID);
        }
        /// <summary>
        /// 
        /// </summary>
        public event ShowMessageHandler ShowMessageEvent;
        #endregion

        #region IDSIStaffView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            this.ShowMessage(message, null);
        }
        #endregion

        #region IDSIStaffUCView 成员


       

        #endregion
    }
}