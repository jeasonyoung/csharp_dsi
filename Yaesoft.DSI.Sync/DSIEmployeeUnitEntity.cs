//================================================================================
// FileName: DSIEmployeeUnitEntity.cs
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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
	///DSIEmployeeUnitEntityʵ���ࡣ
	///</summary>
    internal class DSIEmployeeUnitEntity : DbModuleEntity<DSIEmployeeUnit>
    {
        #region ���ء�
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