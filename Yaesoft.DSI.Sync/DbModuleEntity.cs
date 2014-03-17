//================================================================================
//  FileName: DbModuleEntity.cs
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
using iPower.Data.ORM;
namespace Yaesoft.DSI.Sync
{
    /// <summary>
    /// 
    /// </summary>
    internal class DbModuleEntity<T> : ORMDbEntity<T>
        where T : new()
    {
        #region 构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DbModuleEntity()
        {
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IDBAccess CreateDBAccess()
        {
            return new ModuleConfiguration().ModuleDefaultDatabase;
        }
    }
}
