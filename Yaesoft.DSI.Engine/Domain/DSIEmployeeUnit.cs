//================================================================================
// FileName: DSIEmployeeUnit.cs
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
using System.Text;
	
using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.DSI.Engine.Domain
{
	///<summary>
	///tblDSIEmployeeUnitӳ���ࡣ
	///</summary>
	[DbTable("tblDSIEmployeeUnit")]
	public class DSIEmployeeUnit
	{
		///<summary>
		///��ȡ������EmployeeID��
		///</summary>
        [DbField("EmployeeID", DbFieldUsage.PrimaryKey)]
        public string EmployeeID { get; set; }
		///<summary>
		///��ȡ������UnitID��
		///</summary>
        [DbField("UnitID", DbFieldUsage.PrimaryKey)]
        public string UnitID { get; set; }
	}
}