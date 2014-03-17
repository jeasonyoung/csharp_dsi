//================================================================================
// FileName: DSIStaffFamilyMemberEntity.cs
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
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.DSI.Engine.Domain;
namespace Yaesoft.DSI.Engine.Persistence
{
	///<summary>
	///DSIStaffFamilyMemberEntity实体类。
	///</summary>
	internal class DSIStaffFamilyMemberEntity: DbModuleEntity<DSIStaffFamilyMember>
	{
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="staffID"></param>
        /// <returns></returns>
        public List<DSIStaffFamilyMember> LoadData(GUIDEx staffID)
        {
            return this.LoadRecord(string.Format("StaffID = '{0}' ", staffID));
        }     
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateRecord(GUIDEx staffID, List<DSIStaffFamilyMember>  data)
        {
            bool result = false;
            if (staffID.IsValid)
            {
                //清除数据。
                this.DeleteRecord(string.Format("StaffID = '{0}'", staffID));
                result = true;
                if (data != null && data.Count > 0)
                {
                    foreach (DSIStaffFamilyMember m in data)
                    {
                        if (m.MemberID.IsValid && !string.IsNullOrEmpty(m.MemberName))
                        {
                            m.StaffID = staffID;
                            result = this.UpdateRecord(m);
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 删除数据。
        /// </summary>
        /// <param name="primaryValues">职工ID集合。</param>
        /// <returns></returns>
        public bool DeleteRecordByStaffID(string[] primaryValues)
        {
            return this.DeleteRecord(string.Format("StaffID in ('{0}')", string.Join("','", primaryValues)));
        }
	}
}