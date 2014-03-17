//================================================================================
//  FileName: DSIStaffFamilyPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/22
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
using System.Data;
using iPower;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 教职工家庭成员视图。
    /// </summary>
    public interface IDSIStaffFamilyView : IModuleView
    {
        /// <summary>
        /// 获取或设置教职工家庭成员数据源。
        /// </summary>
        List<DSIStaffFamilyMember> FamilyMemberDataSource { get; set; }
        /// <summary>
        /// 消息事件。
        /// </summary>
        event ShowMessageHandler ShowMessageEvent;
        /// <summary>
        /// 显示提示信息。
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);
    }
    /// <summary>
    /// 教职工家庭成员行为类。
    /// </summary>
    public class DSIStaffFamilyPresenter : ModulePresenter<IDSIStaffFamilyView>
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIStaffFamilyPresenter(IDSIStaffFamilyView view)
            : base(view)
        {

        }
        #endregion
    }
}
