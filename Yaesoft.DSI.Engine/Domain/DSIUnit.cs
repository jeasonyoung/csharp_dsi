//================================================================================
// FileName: DSIUnit.cs
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
	///tblDSIUnitӳ���ࡣ
	///</summary>
	[DbTable("tblDSIUnit")]
	public class DSIUnit
	{
		///<summary>
		///��ȡ������UnitID��
		///</summary>
        [DbField("UnitID", DbFieldUsage.PrimaryKey)]
        public string UnitID { get; set; }
		///<summary>
		///��ȡ������UnitName��
		///</summary>
        [DbField("UnitName")]
        public string UnitName { get; set; }
	}
}