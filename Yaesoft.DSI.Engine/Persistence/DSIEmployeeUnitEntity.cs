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
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.DSI.Engine.Domain;
namespace Yaesoft.DSI.Engine.Persistence
{
	///<summary>
	///DSIEmployeeUnitEntityʵ���ࡣ
	///</summary>
    internal class DSIEmployeeUnitEntity : DbModuleEntity<DSIEmployeeUnit>
    {
        #region ��Ա���������캯����
        private DSIUnitEntity unitEntity;
        ///<summary>
        ///���캯��
        ///</summary>
        public DSIEmployeeUnitEntity()
        {
            this.unitEntity = new DSIUnitEntity();
        }
        #endregion

        #region ���ݴ���
        /// <summary>
        /// ��ȡ�б�����Դ��
        /// </summary>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string employeeName)
        {
            const string sql = "exec spDSIEmployeeUnitListView '{0}'";
            DataTable dtSource = this.DatabaseAccess.ExecuteDataset(string.Format(sql, employeeName)).Tables[0];
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                DataTable dtResult = dtSource.Clone();
                GUIDEx employeeID = GUIDEx.Null, oldEmployeeID = GUIDEx.Null;
                string strEmployeeName = string.Empty, strEmployeeCode = string.Empty, strUnitName = string.Empty;
                foreach (DataRow row in dtSource.Rows)
                {
                    employeeID = new GUIDEx(row["EmployeeID"]);
                    if (employeeID != oldEmployeeID && oldEmployeeID.IsValid)
                    {
                        DataRow dr = dtResult.NewRow();
                        dr["EmployeeID"] = oldEmployeeID;
                        dr["EmployeeCode"] = strEmployeeCode;
                        dr["EmployeeName"] = strEmployeeName;
                        dr["UnitName"] = strUnitName.Length > 0 ? strUnitName.Substring(1) : strUnitName;
                        dtResult.Rows.Add(dr);
                        strUnitName = string.Empty;
                    }
                    strEmployeeCode = Convert.ToString(row["EmployeeCode"]);
                    strEmployeeName = Convert.ToString(row["EmployeeName"]);
                    strUnitName += string.Format(",{0}", row["UnitName"]);
                    oldEmployeeID = employeeID;
                }

                if (oldEmployeeID.IsValid)
                {
                    DataRow dr = dtResult.NewRow();
                    dr["EmployeeID"] = oldEmployeeID;
                    dr["EmployeeCode"] = strEmployeeCode;
                    dr["EmployeeName"] = strEmployeeName;
                    dr["UnitName"] = strUnitName.Length > 0 ? strUnitName.Substring(1) : strUnitName;
                    dtResult.Rows.Add(dr);
                }

                return dtResult;
            }
            return null;
        }
        /// <summary>
        /// ���û���Ȩ�ĵ�λ���ݡ�
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public IListControlsData BindAuthorize(GUIDEx employeeID)
        {
            return this.unitEntity.BindUnitByAuthorize(employeeID);
        }
        /// <summary>
        /// ���û�δ��Ȩ�ĵ�λ���ݡ�
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public IListControlsData BindNonAuthorize(GUIDEx employeeID)
        {
            return this.unitEntity.BindUnitByNonAuthorize(employeeID);
        }
        /// <summary>
        /// �����û����ݡ�
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public IListControlsData SearchEmployees(string unitId, string employeeName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select a.employeeId,b.employeeName + '[' + b.EmployeeCode + ']' as employeeName ");
            sb.Append(" from tblDSIEmployeeUnit a ");
            sb.Append(" inner join tblDSIEmployee b on b.employeeId = a.employeeId ");
            sb.Append(" where ");
            if (!string.IsNullOrEmpty(unitId))
            {
                sb.AppendFormat(" a.unitId = '{0}' and ", unitId);
            }
            sb.AppendFormat(" b.employeeName like '%{0}%' ", employeeName);
            sb.Append(" order by a.unitId,b.employeeName ");
            return new ListControlsDataSource("employeeName", "employeeId", this.DatabaseAccess.ExecuteDataset(sb.ToString()).Tables[0]);
        }
        /// <summary>
        /// �������ݡ�
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="unitIDs"></param>
        /// <returns></returns>
        public bool UpdateRecord(GUIDEx employeeID, string[] unitIDs)
        {
            bool result = false;
            if (employeeID.IsValid)
            {
                result = this.DeleteRecord(string.Format("EmployeeID= '{0}' ", employeeID));
                if (unitIDs != null && unitIDs.Length > 0)
                {
                    foreach (string unitID in unitIDs)
                    {
                        DSIEmployeeUnit data = new DSIEmployeeUnit();
                        data.UnitID = unitID;
                        data.EmployeeID = employeeID;
                        result = this.UpdateRecord(data);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// ����һ������ID��
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public GUIDEx GetDepartmentID(GUIDEx employeeID)
        {
            if (employeeID.IsValid)
            {
               DataTable dtSource =  this.GetAllRecord(string.Format("EmployeeID = '{0}'", employeeID));
               if (dtSource != null && dtSource.Rows.Count > 0)
               {
                   DSIEmployeeUnit data = this.Assignment(dtSource.Rows[0]);
                   if (data != null)
                       return data.UnitID;
               }
            }
            return GUIDEx.Null;
        }
        #endregion
    }
}