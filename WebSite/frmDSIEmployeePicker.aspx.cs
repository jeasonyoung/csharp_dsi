//================================================================================
// FileName: frmDSIEmployeePicker.aspx.cs
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using iPower.Web.Utility;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
	///<summary>
	///frmDSIEmployeePicker�б�ҳ���̨���롣
	///</summary>
    public partial class frmDSIEmployeePicker : ModuleBasePage, IDSIEmployeePickerView
    {
        #region ��Ա���������캯����
        DSIEmployeePresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmDSIEmployeePicker()
        {
            this.presenter = new DSIEmployeePresenter(this);
        }
        #endregion

        #region �¼�����

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.presenter.InitializeComponent();
            }
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            this.presenter.PickerSearch();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string[] text = new string[0], values = new string[0];
            ListBoxHelper.GetSelected(this.listSingleSelect, out text, out values);
            this.SaveData(string.Join(",", text), string.Join(",", values));
        }

        #endregion

        #region ����
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<DSIEmployee>>(delegate(object sender, EntityEventArgs<DSIEmployee> e)
            {
                if (e.Entity != null)
                {
                    this.txtEmployeeName.Text = e.Entity.EmployeeName;
                    this.btnSearch_OnClick(null, EventArgs.Empty);
                    this.listSingleSelect.SelectedValue = this.EmployeeID;
                }
            }));
        }
        #endregion

        #region IDSIEmployeePickerView ��Ա

        public string EmployeeName
        {
            get { return this.txtEmployeeName.Text.Trim(); }
        }

        public GUIDEx EmployeeID
        {
            get { return this.RequestGUIEx("Value"); }
        }

        public void BindEmployees(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.listSingleSelect, data);
            if (this.EmployeeID.IsValid)
            {
                this.listSingleSelect.SelectedValue = this.EmployeeID;
            }
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        #endregion
    }
}