//================================================================================
// FileName: DSIEmployeeUnitEntity.cs
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
using System.Text;
using System.Data;

using iPower;
namespace Yaesoft.DSI.Sync
{
	///<summary>
	///DSIEmployeeUnitEntity实体类。
	///</summary>
    internal class DSIEmployeeUnitEntity : DbModuleEntity<DSIEmployeeUnit>
    {
        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool UpdateRecord(DSIEmployeeUnit entity)
        {
            if (this.LoadRecord(ref entity)) return false;
            return base.UpdateRecord(entity);
        }
        #endregion
    }
}