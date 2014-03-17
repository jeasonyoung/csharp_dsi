//================================================================================
// FileName: DSIEmployeeEntity.cs
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
	///DSIEmployeeEntityʵ���ࡣ
	///</summary>
	internal class DSIEmployeeEntity: DbModuleEntity<DSIEmployee>
    {
        #region ��Ա���������캯����
        private SecurityRoleEmployeeEntity roleEmployeeEntity;
        /// <summary>
        /// ���캯����
        /// </summary>
        /// <param name="defaultRoleID">Ĭ�Ͻ�ɫID��</param>
        public DSIEmployeeEntity(string defaultRoleID)
            : base()
        {
            this.DefaultRoleID = defaultRoleID;
            this.roleEmployeeEntity = new SecurityRoleEmployeeEntity();
            this.roleEmployeeEntity.DbEntityDataChangeLogEvent += this.OnDbEntityDataChangeLogHandler;
        }
        #endregion

        /// <summary>
        /// ��ȡĬ�Ͻ�ɫID��
        /// </summary>
        protected string DefaultRoleID { get; private set; }

        #region ���ء�
        /// <summary>
        /// �������ݡ�
        /// </summary>
        /// <param name="employeeCode">�û����롣</param>
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
                    this.OnDbEntityDataChangeLogHandler("�����ְ��Ĭ�Ͻ�ɫ", data.ToString());
                }
            }
            return result;
        }
        #endregion
    }
}