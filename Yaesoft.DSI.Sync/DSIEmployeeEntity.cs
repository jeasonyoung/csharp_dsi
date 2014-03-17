//================================================================================
// FileName: DSIEmployeeEntity.cs
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
	///DSIEmployeeEntity实体类。
	///</summary>
	internal class DSIEmployeeEntity: DbModuleEntity<DSIEmployee>
    {
        #region 成员变量，构造函数。
        private SecurityRoleEmployeeEntity roleEmployeeEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="defaultRoleID">默认角色ID。</param>
        public DSIEmployeeEntity(string defaultRoleID)
            : base()
        {
            this.DefaultRoleID = defaultRoleID;
            this.roleEmployeeEntity = new SecurityRoleEmployeeEntity();
            this.roleEmployeeEntity.DbEntityDataChangeLogEvent += this.OnDbEntityDataChangeLogHandler;
        }
        #endregion

        /// <summary>
        /// 获取默认角色ID。
        /// </summary>
        protected string DefaultRoleID { get; private set; }

        #region 重载。
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="employeeCode">用户代码。</param>
        /// <returns></returns>
        public DSIEmployee LoadData(string employeeCode)
        {
            if (!string.IsNullOrEmpty(employeeCode))
            {
                DataTable dtSource = this.GetAllRecord(string.Format("EmployeeCode = '{0}'", employeeCode));
                if (dtSource != null && dtSource.Rows.Count > 0)
                    return this.Assignment(dtSource.Rows[0]);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool UpdateRecord(DSIEmployee entity)
        {
            bool result = base.UpdateRecord(entity);
            if (result && !string.IsNullOrEmpty(this.DefaultRoleID))
            {
                SecurityRoleEmployee data = new SecurityRoleEmployee();
                data.RoleID = this.DefaultRoleID;
                data.EmployeeID = entity.EmployeeID;
                data.EmployeeName = entity.EmployeeName;
                if (this.roleEmployeeEntity.UpdateRecord(data))
                {
                    this.OnDbEntityDataChangeLogHandler("插入教职工默认角色", data.ToString());
                }
            }
            return result;
        }
        #endregion
    }
}