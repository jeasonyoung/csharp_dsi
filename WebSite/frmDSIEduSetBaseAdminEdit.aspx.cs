using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Yaesoft.DSI.Engine.Service;
using iPower.Web.Utility;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmDSIEduSetBaseAdminEdit : ModuleBasePage,IDSIEduSetBaseAdminEditView
    {
        #region 成员变量，构造函数。
        private DSIEduSetBaseAdminPresenter prensenter;
        /// <summary>
        /// 
        /// </summary>
        public frmDSIEduSetBaseAdminEdit()
        {
            this.prensenter = new DSIEduSetBaseAdminPresenter(this);
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
                this.prensenter.InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            this.ListControlsDataSourceBind(this.listStaffSelect, this.prensenter.SearchEmployees(this.ddlUnit.SelectedValue, this.txtStaffName.Text.Trim()));
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
                string[] text = new string[0], values = new string[0];
                ListBoxHelper.GetSelected(this.listStaffSelect, out text, out values);
                if (this.prensenter.UpdateEntityData(values[0], text[0]))
                {
                    base.SaveData();
                }
            }
            catch (Exception ex)
            {
                this.errMessage.Message = ex.Message;
            }
        }
        #endregion

        #region IDSIEduSetBaseAdminEditView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void BindUnits(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlUnit, data);
        }

        #endregion
    }
}