//================================================================================
// FileName: frmDSIStaffInfoList.aspx.cs
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
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
	///<summary>
	///frmDSIStaffInfoList�б�ҳ���̨���롣
	///</summary>
    public partial class frmDSIEduStaffInfoList : ModuleBasePage, IDSIEduStaffInfoListView
    {
        #region ��Ա���������캯����
        private DSIEduStaffInfoPresenter presenter;
        ///<summary>
        ///���캯����
        ///</summary>
        public frmDSIEduStaffInfoList()
        {
            this.presenter = new DSIEduStaffInfoPresenter(this);
        }
        #endregion

        #region �¼�����
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
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dgfrmDSIStaffInfoList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmDSIStaffInfoList.DataSource = this.presenter.ListDataSource;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.DeleteData())
                this.LoadData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        #endregion

        #region ���ء�
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.dgfrmDSIStaffInfoList.InvokeBuildDataSource();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool DeleteData()
        {
            return this.presenter.BatchDeleteEntityData(this.dgfrmDSIStaffInfoList.CheckedValue);
        }
        #endregion

        #region IDSIStaffInfoEduListView ��Ա
        /// <summary>
        /// 
        /// </summary>
        public string UnitName
        {
            get { return this.txtUnitName.Text.Trim(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StaffCodeNameCard
        {
            get { return this.txtStaffNameCodeCard.Text.Trim(); }
        }

        #endregion

        #region IDSIStaffInfoEduView ��Ա
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