//================================================================================
// FileName: frmDSIEmployeeUnitList.aspx.cs
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
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    ///<summary>
    ///frmDSIEmployeeUnitList�б�ҳ���̨���롣
    ///</summary>
    public partial class frmDSIEmployeeUnitList : ModuleBasePage, IDSIEmployeeUnitListView
    {
        #region ��Ա���������캯����
        DSIEmployeeUnitPresenter presenter = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmDSIEmployeeUnitList()
        {
            this.presenter = new DSIEmployeeUnitPresenter(this);
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

        protected void dgfrmDSIEmployeeUnitList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmDSIEmployeeUnitList.DataSource = this.presenter.ListDataSource;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.DeleteData())
                this.LoadData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        #endregion

        #region ���ء�

        public override void LoadData()
        {
            this.dgfrmDSIEmployeeUnitList.InvokeBuildDataSource();
        }

        public override bool DeleteData()
        {
            return false;
        }
        #endregion

        #region IDSIEmployeeUnitListView ��Ա

        public string EmployeeName
        {
            get { return this.txtEmployeeName.Text.Trim(); }
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }
        #endregion
    }
}