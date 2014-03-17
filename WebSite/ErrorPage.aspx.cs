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
    public partial class ErrorPage : ModuleBasePage,IModuleView
    {
        #region 成员变量，构造函数。
        private ModulePresenter<IModuleView> presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ErrorPage()
        {
            this.presenter = new ModulePresenter<IModuleView>(this);
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
                this.presenter.InitializeComponent();
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            Exception exp = this.Session["Exception"] as Exception;
            if (exp != null)
            {
                this.lbTitle.Text = exp.Message;
            }
        }
        #endregion
    }
}