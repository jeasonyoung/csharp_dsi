using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;

using iPower;
namespace Yaesoft.DSI.Sync
{
    /// <summary>
    /// 
    /// </summary>
    internal class SecurityRoleEmployeeEntity : DbModuleEntity<SecurityRoleEmployee>
    {
        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool UpdateRecord(SecurityRoleEmployee entity)
        {
            const string sql = "select count(*) from {0} where EmployeeID = '{1}'";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, entity.EmployeeID));
            if (obj == null || ((int)obj) == 0)
                return base.UpdateRecord(entity);
            return false;
        }
        #endregion
    }
}