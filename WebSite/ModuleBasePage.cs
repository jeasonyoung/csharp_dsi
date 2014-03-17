//================================================================================
//  FileName: ModuleBasePage.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/1
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
using iPower.Platform.UI;
using iPower.Web.UI;

using iPower.Platform.Engine.Persistence;
using iPower.Platform.Engine.Service;
using Yaesoft.DSI.Engine.Persistence;
using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 模块模板页基础类。
    /// </summary>
    public class ModuleBaseMasterPage : BaseModuleMasterPage
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ModuleBaseMasterPage()
        {
            
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取模块名称。
        /// </summary>
        protected virtual string CurrentModuleTitle
        {
            get
            {
                if (this.ModulePage != null)
                    return this.ModulePage.CurrentModuleTitle;
                return string.Empty;
            }
        }
        #endregion
    }
    /// <summary>
    /// 模块页面基类。
    /// </summary>
    public class ModuleBasePage : BaseModulePage, IModuleView
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ModuleBasePage()
        {
        }
        #endregion

        #region 函数。
        /// <summary>
        /// 将所有的控件的Enable值设为False。
        /// </summary>
        /// <param name="ctrl"></param>
        protected void DisEnableAllControls(Control ctrl)
        {
            if (ctrl != null && ctrl.HasControls())
            {
                foreach (Control ctr in ctrl.Controls)
                {
                    if (ctr is WebControl)
                    {
                        if (ctr is IButtonControl)
                        {
                            ButtonEx btn = ctr as ButtonEx;
                            if (btn != null && (btn.ID == "btnCancel" || btn.ID == "btnPrint"))
                            {
                                continue;
                            }
                            else
                                ((WebControl)ctr).Enabled = false;
                        }
                        else if (ctr is iPower.Web.Upload.UploadView)
                        {
                            ((iPower.Web.Upload.UploadView)ctr).ReadOnly = true;
                        }
                        else if (ctr is DropDownList)
                        {
                            ((DropDownList)ctr).Enabled = false;
                        }
                        else if (ctr is TextBox)
                        {
                            ((TextBox)ctr).ReadOnly = true;
                        }
                        else if (ctr is PickerBase)
                        {
                            ((PickerBase)ctr).Enabled = false;
                        }

                    }
                    this.DisEnableAllControls(ctr);
                }
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            this.Error += new EventHandler(delegate(object o, EventArgs s)
            {
                string url = ModuleConfiguration.ModuleConfig.ErrorHandlerPageUrl;
                if (!string.IsNullOrEmpty(url))
                {
                    Exception exp = this.Context.Server.GetLastError();
                    if (exp != null)
                    {
                        this.Context.Session["Exception"] = exp;
                        this.Context.Server.ClearError();
                        this.Context.Response.Redirect(url,true);
                    }
                }
            });
            base.OnInit(e);
        }
        #endregion
    }
    /// <summary>
    /// 用户控件基类。
    /// </summary>
    public class ModuleBaseControl : BaseModuleControl, IModuleView
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ModuleBaseControl()
        {
        }
        #endregion
    }

    #region 用户控件。
    /// <summary>
    /// Banner头用户控件。
    /// </summary>
    public class TopBanner : ModuleBaseControl, ITopBannerView
    {
        #region 成员变量，构造函数。
        private TopBannerPresenter<ModuleConfiguration> presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public TopBanner()
        {
            this.presenter = new TopBannerPresenter<ModuleConfiguration>(this);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.IsPostBack) this.presenter.InitializeComponent();
        }

        #region ITopBannerView 成员
        /// <summary>
        /// 获取顶部菜单。
        /// </summary>
        public TopBannerMenuCollection TopBannerMenus
        {
            get
            {
                object obj = this.ViewState["TopBannerMenus"];
                return obj == null ? new TopBannerMenuCollection() : (TopBannerMenuCollection)obj;
            }
            set
            {
                this.ViewState["TopBannerMenus"] = value;
            }
        }

        #endregion
    }
    /// <summary>
    /// 主菜单用户控件。
    /// </summary>
    public class MainMenu : ModuleBaseControl, IModuleView
    {
        #region 成员变量，构造函数。
        private ModulePresenter<IModuleView> presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public MainMenu()
        {
            this.presenter = new ModulePresenter<IModuleView>(this);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        protected global::System.Web.UI.WebControls.Repeater repeaterMainMenu;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.IsPostBack) this.presenter.InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.Page.LoadComplete += new EventHandler(delegate(object sender, EventArgs e)
            {
                iPower.Platform.ModuleDefineCollection collection = this.MainMenuData;
                if (collection != null && this.repeaterMainMenu != null)
                {
                    this.repeaterMainMenu.DataSource = collection;
                    this.repeaterMainMenu.DataBind();
                }
            });
        }
    }
    /// <summary>
    /// 左边菜单用户控件。
    /// </summary>
    public class LeftMenu : ModuleBaseControl, IModuleView
    {
        #region 成员变量，构造函数。
        private ModulePresenter<IModuleView> presenter;
        private System.Data.DataTable dtSource;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public LeftMenu()
        {
            this.dtSource = new System.Data.DataTable();
            this.dtSource.Columns.Add("ModuleID", typeof(System.String));
            this.dtSource.Columns.Add("ParentModuleID", typeof(System.String));
            this.dtSource.Columns.Add("ModuleName", typeof(System.String));
            this.dtSource.Columns.Add("ModuleUri", typeof(System.String));
            this.dtSource.Columns.Add("OrderNo", typeof(System.Int32));
            this.dtSource.PrimaryKey = new System.Data.DataColumn[] { this.dtSource.Columns["ModuleID"] };

            this.presenter = new ModulePresenter<IModuleView>(this);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        protected global::iPower.Web.OutlookView.OutlookView tvMenuOutlook;
        /// <summary>
        /// 
        /// </summary>
        protected global::iPower.Web.TreeView.TreeView tvMenuTree;

        /// <summary>
        /// 获取或设置菜单风格类型。
        /// </summary>
        public EnumMenuType MenuType
        {
            get
            {
                object obj = this.ViewState["MenuType"];
                return obj == null ? EnumMenuType.Outlook : (EnumMenuType)obj;
            }
            set
            {
                this.ViewState["MenuType"] = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.IsPostBack) this.presenter.InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            this.Page.LoadComplete += new EventHandler(delegate(object sender, EventArgs e)
            {
                iPower.Platform.ModuleDefineCollection collection = this.MenuData;
                if (collection != null)
                {
                    this.BuilderModuleDefineDataSource(ref this.dtSource, collection);
                }

                if (this.dtSource != null && this.dtSource.Rows.Count > 0)
                {
                    iPower.Web.TreeView.TreeView treeView = null;
                    switch (this.MenuType)
                    {
                        case EnumMenuType.Outlook:
                            treeView = this.tvMenuOutlook;
                            break;
                        case EnumMenuType.TreeView:
                            treeView = this.tvMenuTree;
                            break;
                    }
                    if (treeView != null)
                    {
                        treeView.DataSource = this.dtSource.Copy();
                        treeView.IDField = "ModuleID";
                        treeView.PIDField = "ParentModuleID";
                        treeView.TitleField = "ModuleName";
                        treeView.HrefField = "ModuleUri";
                        treeView.OrderNoField = "OrderNo";

                        string currentFolderID = this.CurrentFolderID;
                        if (string.IsNullOrEmpty(currentFolderID))
                            currentFolderID = this.SecurityID;

                        treeView.Visible = true;
                        treeView.CurrentFolderValue = currentFolderID;
                        treeView.BuildTree();

                        iPower.Web.TreeView.TreeViewNode node = treeView.Items[currentFolderID];
                        if (node != null)
                        {
                            bool flag = false;
                            iPower.Web.TreeView.TreeViewNode p = node.Parent;
                            while (p != null)
                            {
                                p.Expand = flag = true;
                                p = p.Parent;
                            }
                            if (flag)
                                treeView.DataBind();
                        }
                    }
                }
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="collection"></param>
        private void BuilderModuleDefineDataSource(ref System.Data.DataTable dt, iPower.Platform.ModuleDefineCollection collection)
        {
            if (collection != null)
            {
                System.Data.DataRow dr = null;
                foreach (iPower.Platform.ModuleDefine d in collection)
                {
                    if (dt.Rows.Find(d.ModuleID) == null)
                    {
                        dr = dt.NewRow();
                        dr["ModuleID"] = d.ModuleID;
                        dr["ParentModuleID"] = (d.Parent == null) ? string.Empty : d.Parent.ModuleID;
                        dr["ModuleName"] = d.ModuleName;
                        dr["ModuleUri"] = d.ModuleUri;
                        dr["OrderNo"] = d.OrderNo;
                        dt.Rows.Add(dr);
                    }
                    if (d.Modules != null && d.Modules.Count > 0)
                    {
                        this.BuilderModuleDefineDataSource(ref dt, d.Modules);
                    }
                }
            }
        }

        /// <summary>
        /// 菜单类型枚举。
        /// </summary>
        public enum EnumMenuType
        {
            /// <summary>
            /// Outlook风格。
            /// </summary>
            Outlook = 0,
            /// <summary>
            /// 树形风格。
            /// </summary>
            TreeView = 1
        }
    }
    /// <summary>
    /// 底部版本信息控件。
    /// </summary>
    public class Footer : ModuleBaseControl, IModuleView
    {
        #region 成员变量，构造函数。
        private ModulePresenter<IModuleView> presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Footer()
        {
            this.presenter = new ModulePresenter<IModuleView>(this);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.IsPostBack) this.presenter.InitializeComponent();
        }
    }
    #endregion
}