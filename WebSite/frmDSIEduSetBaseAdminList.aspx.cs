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
    public partial class frmDSIEduSetBaseAdminList : ModuleBasePage, IDSIEduSetBaseAdminListView
    {
        #region 成员变量，构造函数。
        private DSIEduSetBaseAdminPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSIEduSetBaseAdminList()
        {
            this.presenter = new DSIEduSetBaseAdminPresenter(this);
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 构造函数。
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
            {
                this.LoadData();
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
        protected void frmDSIEduSetBaseAdminList_BuildDataSource(object sender, EventArgs e)
        {
            this.dgfrmDSIEduSetBaseAdminList.DataSource = this.presenter.ListDataSource;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.dgfrmDSIEduSetBaseAdminList.InvokeBuildDataSource();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool DeleteData()
        {
            return this.presenter.DeleteEntityData(this.dgfrmDSIEduSetBaseAdminList.CheckedValue);
        }
        #endregion

        #region IDSIEduSetBaseAdminListView 成员
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
        public string EmployeeName
        {
            get { return this.txtEmployeeName.Text.Trim(); }
        }

        #endregion
    }
}
