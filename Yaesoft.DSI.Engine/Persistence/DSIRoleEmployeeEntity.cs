using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Data;
using iPower.IRMP.Security.Engine.Domain;
namespace Yaesoft.DSI.Engine.Persistence
{
    /// <summary>
    /// 角色用户实体类。
    /// </summary>
    internal class DSIRoleEmployeeEntity : DbModuleEntity<SecurityRoleEmployee>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitName"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string unitName, string employeeName)
        {
            const string sql = @"select c.UnitName, a.EmployeeID,a.EmployeeName
                                from tblSecurityRoleEmployee a
                                inner join tblDSIEmployeeUnit b on b.EmployeeID = a.EmployeeID
                                inner join tblDSIUnit c  on c.UnitID = b.UnitID
                                where  a.RoleID = '{0}' and c.UnitName like '%{1}%' and a.EmployeeName like '%{2}%'
                                order by c.UnitName,a.EmployeeName";

            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, this.ModuleConfig.BaseAdminRoleID, unitName, employeeName)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool UpdateRecord(SecurityRoleEmployee entity)
        {
            if (entity == null) return false;
            entity.RoleID = this.ModuleConfig.BaseAdminRoleID;
            return base.UpdateRecord(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        public override bool DeleteRecord(StringCollection primaryValues)
        {
            if (primaryValues == null || primaryValues.Count == 0) return false;
            string[] values = new string[primaryValues.Count];
            primaryValues.CopyTo(values, 0);
            return base.DeleteRecord(string.Format("RoleID = '{0}' and (EmployeeID in ('{1}'))", this.ModuleConfig.BaseAdminRoleID, string.Join("','", values)));
        }
    }
}