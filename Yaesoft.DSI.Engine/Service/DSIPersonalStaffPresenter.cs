//================================================================================
//  FileName: DSIPersonalStaffPresenter.cs
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
using System.Text;

using iPower;
using iPower.Platform.Engine.Service;

using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 个人档案接口。
    /// </summary>
    public interface IDSIPersonalStaffView : IModuleView
    {
        /// <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
    /// <summary>
    ///  个人档案行为类。
    /// </summary>
    public class DSIPersonalStaffPresenter : ModulePresenter<IDSIPersonalStaffView>
    {
        #region 成员变量，构造函数。
        private DSIStaffInfoEntity staffInfoEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIPersonalStaffPresenter(IDSIPersonalStaffView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.PersonalStaff_ModuleID;
            this.staffInfoEntity = new DSIStaffInfoEntity();
            this.staffInfoEntity.DbEntityDataChangeLogEvent += this.CreateCommonLog;
        }
        #endregion

        /// <summary>
        /// 加载实体数据。
        /// </summary>
        /// <param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<DSIStaffInfo>> handler)
        {
            DSIStaffInfo data = this.staffInfoEntity.LoadDataByUserID(this.View.CurrentUserID);
            if (data != null)
            {
                handler(this, new EntityEventArgs<DSIStaffInfo>(data));
            }
        }
    }
}