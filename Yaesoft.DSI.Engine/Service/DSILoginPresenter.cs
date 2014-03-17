//================================================================================
//  FileName: DSILoginPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-2-11
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
using System.Text;
using iPower.IRMP.SysMgr.Engine.Service;
namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 用户登录视图。
    /// </summary>
    public interface IDSILoginView : IModuleView, ILoginView
    {
    }
    /// <summary>
    /// 用户登录行为类。
    /// </summary>
    public class DSILoginPresenter : ModulePresenter<IDSILoginView>
    {
        #region 成员变量，构造函数。
        private SysMgrLoginPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSILoginPresenter(IDSILoginView view)
            : base(view)
        {
            this.presenter = new SysMgrLoginPresenter(this.View);
        }
        #endregion

        /// <summary>
        /// 登录。
        /// </summary>
        public void Login()
        {
            try
            {
                this.presenter.Login();
            }
            catch (Exception e)
            {
                this.View.ShowMessage(e.Message);
            }
        }
    }
}