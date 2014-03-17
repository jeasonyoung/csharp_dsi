//================================================================================
//  FileName: frmDSIPersonalStaffList.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-1
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

using iPower;
using iPower.Platform.Engine.Service;

using Yaesoft.DSI.Engine;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    public partial class frmDSIPersonalStaffList : ModuleBasePage, IDSIPersonalStaffView
    {
        #region 成员变量，构造函数。
        private DSIPersonalStaffPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmDSIPersonalStaffList()
        {
            this.presenter = new DSIPersonalStaffPresenter(this);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public GUIDEx StaffID
        {
            get
            {
                return new GUIDEx(this.ViewState["StaffID"]);
            }
            set
            {
                this.ViewState["StaffID"] = value;
            }
        }

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

            this.ucStaffInfo.ShowMessageEvent += new ShowMessageHandler(delegate(string msg, string atfer)
            {
                this.ShowMessage(msg);
            });
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
                data.StaffID = this.StaffID.IsValid ? this.StaffID : (this.CurrentUserID.IsValid ? this.CurrentUserID : GUIDEx.New);
                if (this.ucStaffInfo.SaveData(data))
                {
                    this.ShowMessage("保存成功！");
                }
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
            this.LoadComplete += new EventHandler(delegate(object o, EventArgs s)
            {
                this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<DSIStaffInfo>>(delegate(object sender, EntityEventArgs<DSIStaffInfo> e)
                {
                    if (e != null && e.Entity != null)
                    {
                        this.StaffID = e.Entity.StaffID;
                        this.ucStaffInfo.LoadData(e.Entity);
                    }
                }));
            });
        }
        #endregion

        #region IDSIPersonalStaffView 成员
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