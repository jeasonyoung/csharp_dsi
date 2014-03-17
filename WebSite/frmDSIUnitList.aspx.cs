//================================================================================
// FileName: frmDSIUnitList.aspx.cs
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
	///frmDSIUnitList�б�ҳ���̨���롣
	///</summary>
    public partial class frmDSIUnitList : ModuleBasePage, IDSIUnitListView
	{
		#region ��Ա���������캯����
		DSIUnitPresenter presenter = null;
		///<summary>
		///���캯����
		///</summary>
		public frmDSIUnitList()
		{
			this.presenter = new DSIUnitPresenter(this);
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
		protected void dgfrmDSIUnitList_BuildDataSource(object sender, EventArgs e)
		{
            this.dgfrmDSIUnitList.DataSource = this.presenter.ListDataSource;
		}
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			this.LoadData();
		}
		#endregion

		#region ���ء�
		public override void LoadData()
		{
			this.dgfrmDSIUnitList.InvokeBuildDataSource();				
		}
		#endregion

        #region IDSIUnitListView ��Ա
        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="Msg"></param>
        public void ShowMessage(string Msg)
        {
            this.errMessage.Message = Msg;
        }
        /// <summary>
        /// ��λ��
        /// </summary>
        public string Unitname
        {
            get { return this.txtUnitName.Text.Trim(); }
        }
        #endregion
    }
}