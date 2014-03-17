//================================================================================
// FileName: frmDSIStaffInfoEdit.aspx.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
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
using System.Text.RegularExpressions;

using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using iPower.Web.UI;

using Yaesoft.DSI.Engine;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    ///<summary>
    ///frmDSIStaffInfoEdit列表页面后台代码。
    ///</summary>
    public partial class frmDSIEduStaffInfoEdit : ModuleBasePage, IDSIEduStaffInfoEditView
    {
        #region 成员变量，构造函数。
        private DSIEduStaffInfoPresenter presenter;
        ///<summary>
        ///构造函数。
        ///</summary>
        public frmDSIEduStaffInfoEdit()
        {
            this.presenter = new DSIEduStaffInfoPresenter(this);
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
                this.ucStaffInfo.ShowMessageEvent += new ShowMessageHandler(delegate(string message, string afterAlertScript)
               {
                   this.errMessage.Message = message;
                   if (!string.IsNullOrEmpty(afterAlertScript)) this.errMessage.AfterAlertFunction = afterAlertScript;
               });
            }
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
                DSIStaffInfo data = new DSIStaffInfo();
                data.StaffID = this.StaffID.IsValid ? this.StaffID : GUIDEx.New;
                if (this.ucStaffInfo.SaveData(data))
                    this.SaveData();
            }
            catch (System.Data.SqlClient.SqlException x)
            {
                if (x.Number == 2627)
                    this.ShowMessage("教职工编号或身份证号重复！");
                else
                    this.ShowMessage(x.Message);
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadData();
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        public override bool ViewStateInServer
        {
            get
            {
                return this.CurrentUserID.IsValid;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.LoadComplete += new EventHandler(delegate(object s, EventArgs ex)
            {
               this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<DSIStaffInfo>>(delegate(object sender, EntityEventArgs<DSIStaffInfo> e)
               {
                   if (e.Entity != null)
                   {
                       this.ucStaffInfo.LoadData(e.Entity);
                       //if (this.ReadOnly) this.DisEnableAllControls(this);
                       //if (e.Entity.StaffID.IsValid)
                       //{
                       //    string url = this.btnPrint.PickerPage;
                       //    if (!string.IsNullOrEmpty(url))
                       //    {
                       //        this.btnPrint.PickerPage = string.Format(url, e.Entity.StaffID);
                       //        this.btnPrint.Visible = true;
                       //    }
                       //}
                   }
               }));
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool DeleteData()
        {
            return false;
        }
        #endregion

        #region IDSIEditStaffInfoView 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion

        #region IDSIStaffInfoEditView 成员
        /// <summary>
        /// 
        /// </summary>
        public GUIDEx StaffID
        {
            get { return this.RequestGUIEx("StaffID"); }
        }

        #endregion
    }
}