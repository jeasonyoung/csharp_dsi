//================================================================================
//  FileName: frmDSIEduRptTimeAllowanceList.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-24
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

using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmDSIEduRptTimeAllowanceList : ModuleBasePage, IDSIEduRptTimeAllowanceListView
    {
        #region 成员变量，构造函数。
        private DSIEduRptTimeAllowancePresenter presenter;
        /// <summary>
        /// 
        /// </summary>
        public frmDSIEduRptTimeAllowanceList()
        {
            this.presenter = new DSIEduRptTimeAllowancePresenter(this);
        }
        #endregion

        #region  事件处理。
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
                this.txtStartTime.Text = string.Format("{0:yyyy-MM-dd}", new DateTime(DateTime.Now.Year, 1, 1));
                this.txtEndTime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
            }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dgfrmDSIEduRptTimeAllowanceList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmDSIEduRptTimeAllowanceList.DataSource = this.presenter.ListDataSource;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.dgfrmDSIEduRptTimeAllowanceList.InvokeBuildDataSource();
        }
        #endregion

        #region IDSIEduRptTimeAllowanceListView 成员
        /// <summary>
        /// 
        /// </summary>
        public string ProjectName
        {
            get { return this.txtProject.Text.Trim(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                try
                {
                    return DateTime.Parse(this.txtStartTime.Text.Trim());
                }
                catch (Exception)
                {
                    return new DateTime(DateTime.Now.Year, 1, 1);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                try
                {
                    return DateTime.Parse(this.txtEndTime.Text.Trim());
                }
                catch (Exception)
                {
                    return DateTime.Now;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="summarys"></param>
        public void ShowSummary(object[] summarys)
        {
            this.lbSummary.Text = string.Format("汇总：申报项目[{0}], 总单位数 [{1}], 总人数 [{2}], 补助总金额 [{3:##,###.00}]", summarys);
        }

        #endregion
    }
}