//================================================================================
// FileName: DSIEmployeeUnit.cs
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
namespace Yaesoft.DSI.Engine.Domain
{
	///<summary>
	///tblDSIEmployeeUnit映射类。
	///</summary>
	[DbTable("tblDSIEmployeeUnit")]
	public class DSIEmployeeUnit
	{
		///<summary>
		///获取或设置EmployeeID。
		///</summary>
        [DbField("EmployeeID", DbFieldUsage.PrimaryKey)]
        public string EmployeeID { get; set; }
		///<summary>
		///获取或设置UnitID。
		///</summary>
        [DbField("UnitID", DbFieldUsage.PrimaryKey)]
        public string UnitID { get; set; }
	}
}