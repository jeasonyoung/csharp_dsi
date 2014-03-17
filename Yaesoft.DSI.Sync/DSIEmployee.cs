//================================================================================
// FileName: DSIEmployee.cs
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
using System.Text;
	
using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.DSI.Sync
{
	///<summary>
	///tblDSIEmployee映射类。
	///</summary>
	[DbTable("tblDSIEmployee")]
	internal class DSIEmployee
	{
		#region 属性。
		///<summary>
		///获取或设置EmployeeID。
		///</summary>
        [DbField("EmployeeID", DbFieldUsage.PrimaryKey)]
        public string EmployeeID { get; set; }
		///<summary>
		///获取或设置EmployeeCode。
		///</summary>
        [DbField("EmployeeCode")]
        public string EmployeeCode { get; set; }
		///<summary>
		///获取或设置EmployeeName。
		///</summary>
        [DbField("EmployeeName")]
        public string EmployeeName { get; set; }	
		#endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("教师ID:{0},教师代码:{1},教师名称:{2}", this.EmployeeID, this.EmployeeCode, this.EmployeeName);
        }
        #endregion
    }
}