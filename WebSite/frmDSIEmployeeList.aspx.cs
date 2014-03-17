//================================================================================
// FileName: frmDSIEmployeeList.aspx.cs
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
	///frmDSIEmployeeList�б�ҳ���̨���롣
	///</summary>
    public partial class frmDSIEmployeeList : ModuleBasePage, IDSIEmployeeListView
	{
		#region ��Ա���������캯����
		DSIEmployeePresenter presenter = null;
		///<summary>
		///���캯����
		///</summary>
		public frmDSIEmployeeList()
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
		protected void dgfrmDSIEmployeeList_BuildDataSource(object sender, EventArgs e)
		{
            this.dgfrmDSIEmployeeList.DataSource = this.presenter.ListDataScuore;

		}
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			this.LoadData();

		}
		#endregion

		#region ���ء�

		public override void LoadData()
		{
			this.dgfrmDSIEmployeeList.InvokeBuildDataSource();
		}
		#endregion

        #region IDSIEmployeeListView ��Ա

        public string EmployeeName
        {
            get
            {
                return this.txtEmployeeName.Text.Trim();
            }
        }

        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion
    }
}