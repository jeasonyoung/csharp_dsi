//================================================================================
//  FileName: ModuleConfiguration.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/4
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

using iPower.Data;
using iPower.Data.DataAccess;
using iPower.Configuration;
using iPower.WinService.Jobs;
namespace Yaesoft.DSI.Sync
{
    /// <summary>
    /// 模块配置键名。
    /// </summary>
    internal class ModuleConfigurationKeys : JobConfigurationKey
    {
        /// <summary>
        /// 
        /// </summary>
        public const string TeaUserRoleIDKey = "TeaUserRoleID";
    }
    /// <summary>
    /// 模块配置类。
    /// </summary>
    public class ModuleConfiguration : JobConfiguration
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ModuleConfiguration()
            : base("DSISyncService")
        {
        }
        #endregion

        /// <summary>
        /// 获取教职工角色ID。
        /// </summary>
        public string TeaUserRoleID { get { return this[ModuleConfigurationKeys.TeaUserRoleIDKey]; } }

        #region 数据库连接。
        /// <summary>
        /// 默认数据连接。
        /// </summary>
        public IDBAccess ModuleDefaultDatabase
        {
            get
            {
                ConnectionStringConfiguration conn = this.DefaultDataConnectionString;
                if (conn == null)
                    return null;
                return DatabaseFactory.Instance(conn);
            }
        }
        #endregion
    }
}