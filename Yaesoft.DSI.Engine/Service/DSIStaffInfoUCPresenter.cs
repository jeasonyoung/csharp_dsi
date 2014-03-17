//================================================================================
//  FileName: DSIStaffInfoUCPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-15
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
using System.Collections.Specialized;
using System.Text;

using iPower;
using iPower.Platform.Engine.DataSource;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;

namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDSIStaffInfoUCView : IModuleView
    {
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="data"></param>
        void LoadData(DSIStaffInfo data);
        /// <summary>
        /// 保存数据。
        /// </summary>
        /// <param name="data"></param>
        bool SaveData(DSIStaffInfo data);
        /// <summary>
        /// 消息事件。
        /// </summary>
        event ShowMessageHandler ShowMessageEvent;
    }
    /// <summary>
    /// 
    /// </summary>
    public class DSIStaffInfoUCPresenter : ModulePresenter<IDSIStaffInfoUCView>
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIStaffInfoUCPresenter(IDSIStaffInfoUCView view)
            : base(view)
        {
        }
        #endregion
    }
}