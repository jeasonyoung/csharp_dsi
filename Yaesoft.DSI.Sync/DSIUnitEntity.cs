//================================================================================
// FileName: DSIUnitEntity.cs
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
	///DSIUnitEntityʵ���ࡣ
	///</summary>
    internal class DSIUnitEntity : DbModuleEntity<DSIUnit>
    {
        #region ���ݲ�����
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DSIUnit> LoadAllRecords()
        {
            return this.LoadRecord(string.Empty);
        }
        /// <summary>
        /// �������ݡ�
        /// </summary>
        /// <param name="unitCode"></param>
        /// <returns></returns>
        public DSIUnit LoadData(string unitCode)
        {
            if (!string.IsNullOrEmpty(unitCode))
            {
                DataTable dtSource = this.GetAllRecord(string.Format("UnitCode = '{0}'", unitCode));
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    return this.Assignment(dtSource.Rows[0]);
                }
            }
            return null;
        }
        #endregion
    }
}