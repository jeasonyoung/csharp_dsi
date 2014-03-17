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
using iPower.Platform;
using iPower.IRMP.Org;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.DSI.Engine.Domain;
namespace Yaesoft.DSI.Engine.Persistence
{
    ///<summary>
    ///DSIEmployeeEntity实体类。
    ///</summary>
    internal class DSIEmployeeEntity : DbModuleEntity<DSIEmployee>
    {
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string employeeName)
        {
            return this.GetAllRecord(string.Format("EmployeeName like '%{0}%' or EmployeeCode like '%{0}%'", employeeName), "EmployeeName");
        }
        /// <summary>
        /// 绑定Picker数据源。
        /// </summary>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public IListControlsData BindPicker(string employeeName)
        {
            DataTable dtSource = this.ListDataSource(employeeName);
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    row["EmployeeName"] = string.Format("{0}[{1}]", row["EmployeeName"], row["EmployeeCode"]);
                }
            }
            return new ListControlsDataSource("EmployeeName", "EmployeeID", dtSource);
        }
        /// <summary>
        /// 加载数据数据。
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public new DSIEmployee LoadRecord(string employeeCode)
        {
            DataTable dtSource = this.GetAllRecord(string.Format("EmployeeCode = '{0}'", employeeCode));
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                return this.Assignment(dtSource.Rows[0]);
            }
            return null;
        }
        /// <summary>
        /// 获取用户数据。
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public OrgEmployeeCollection GetAllEmployee(string employeeID)
        {
            DataTable dtSource = null;
            if (string.IsNullOrEmpty(employeeID))
                dtSource = this.GetAllRecord();
            else
            {
                dtSource = this.GetAllRecord(string.Format("EmployeeID = '{0}'", employeeID));
                if (dtSource != null && dtSource.Rows.Count == 0)
                    dtSource = this.GetAllRecord(string.Format("EmployeeName like '%{0}%' or EmployeeCode like '%{0}%'", employeeID));
            }
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                OrgEmployeeCollection collection = new OrgEmployeeCollection();
                DSIEmployeeUnitEntity employeeUnitEntity = new DSIEmployeeUnitEntity();
                foreach (DataRow row in dtSource.Rows)
                {
                    OrgEmployee data = new OrgEmployee();
                    data.EmployeeID = Convert.ToString(row["EmployeeID"]);
                    data.EmployeeName = Convert.ToString(row["EmployeeName"]);
                    data.EmployeeSign = Convert.ToString(row["EmployeeCode"]);
                    data.DepartmentID = employeeUnitEntity.GetDepartmentID(data.EmployeeID);
                    data.Order = 0;
                    collection.Add(data);
                }
                return collection;
            }
            return null;
        }
    }
}