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
    public partial class frmDSIEduRptAllowanceDetail : ModuleBasePage, IDSIEduRptAllowanceDetailView
    {
        #region 成员变量，构造函数。
        private DSIEduRptAllowanceDetailPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSIEduRptAllowanceDetail()
        {
            this.presenter = new DSIEduRptAllowanceDetailPresenter(this);
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
            if (!this.IsPostBack) this.presenter.InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dgfrmDSIEduRptAllowanceDetail_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmDSIEduRptAllowanceDetail.DataSource = this.presenter.ListDataSource;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.dgfrmDSIEduRptAllowanceDetail.InvokeBuildDataSource();
        }
        #endregion

        #region IDSIEduRptAllowanceDetailView 成员
        /// <summary>
        /// 
        /// </summary>
        public string UnitID
        {
            get { return this.Request["UnitID"]; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Year
        {
            get { return this.Request["Year"]; }
        }
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