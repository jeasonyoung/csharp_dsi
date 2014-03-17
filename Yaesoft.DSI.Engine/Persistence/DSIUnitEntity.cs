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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
	
using iPower;
using iPower.IRMP.Org;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.DSI.Engine.Domain;
namespace Yaesoft.DSI.Engine.Persistence
{
	///<summary>
	///DSIUnitEntityʵ���ࡣ
	///</summary>
    internal class DSIUnitEntity : DbModuleEntity<DSIUnit>
    {
        private static Hashtable cache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        public string LoadUnitName(string unitID)
        {
            if (string.IsNullOrEmpty(unitID)) return null;
            DSIUnit data = new DSIUnit();
            data.UnitID = unitID;
            if (this.LoadRecord(ref data))
            {
                return data.UnitName;
            }
            return null;
        }
        /// <summary>
        /// ��ȡ�б�����Դ��
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string unitName)
        {
            return this.GetAllRecord(string.Format(string.Format("UnitName like '%{0}%' ", unitName)), "UnitCode");
        }
        /// <summary>
        /// ����Ȩ��λ���ݡ�
        /// </summary>
        public IListControlsData BindUnitByAuthorize(GUIDEx employeeID)
        {
            if (employeeID.IsValid)
                return this.BindData(string.Format("UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = '{0}')", employeeID));
            return null;
        }
        /// <summary>
        /// ��δ��Ȩ��λ���ݡ�
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public IListControlsData BindUnitByNonAuthorize(GUIDEx employeeID)
        {
            if (employeeID.IsValid)
                return this.BindData(string.Format("UnitID not in (select UnitID from tblDSIEmployeeUnit where EmployeeID = '{0}')", employeeID));
            return null;
        }
        /// <summary>
        /// ��ȫ����λ���ݡ�
        /// </summary>
        public IListControlsData BindAllUnit
        {
            get
            {
                return this.BindData(string.Empty);
            }
        }
        /// <summary>
        /// �����ݡ�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private IListControlsData BindData(string where)
        {
            return new ListControlsDataSource("UnitName", "UnitID", this.GetAllRecord(where, "UnitName"));
        }
        /// <summary>
        /// ��ȡ�������ݡ�
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public OrgDepartmentCollection GetAllDepartment(string departmentID)
        {
            DataTable dtSource = null;
            if (string.IsNullOrEmpty(departmentID))
                dtSource = this.GetAllRecord();
            else
            {
                dtSource = this.GetAllRecord(string.Format("UnitID = '{0}'", departmentID));
                if (dtSource != null && dtSource.Rows.Count == 0)
                    dtSource = this.GetAllRecord(string.Format("UnitName like '%{0}%'", departmentID));
            }
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                OrgDepartmentCollection collection = new OrgDepartmentCollection();
                foreach (DataRow row in dtSource.Rows)
                {
                    OrgDepartment data = new OrgDepartment();
                    data.DepartmentID = Convert.ToString(row["UnitID"]);
                    data.DepartmentName = Convert.ToString(row["UnitName"]);
                    data.Order = 0;
                    collection.Add(data);
                }
                return collection;
            }
            return null;
        }
        /// <summary>
        /// ��ȡ�ֹܲ�����Ϣ��
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public OrgDepartmentCollection GetSubCharge(string employeeID)
        {
            OrgDepartmentCollection collection = new OrgDepartmentCollection();
            DataTable dtSource = this.GetAllRecord(string.Format("UnitID in (select UnitID from tblDSIEmployeeUnit where EmployeeID = '{0}')", employeeID));
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    OrgDepartment data = new OrgDepartment();
                    data.DepartmentID = Convert.ToString(row["UnitID"]);
                    data.DepartmentName = Convert.ToString(row["UnitName"]);
                    data.Order = 0;
                    collection.Add(data);
                }
            }
            return collection;
        }
    }
}