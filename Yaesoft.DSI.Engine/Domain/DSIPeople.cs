//================================================================================
// FileName: DSIPeople.cs
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
	///tblDSIPeople映射类。
	///</summary>
    [DbTable("tblDSIPeople")]
    public class DSIPeople
    {
        ///<summary>
        ///获取或设置PeopleID。
        ///</summary>
        [DbField("PeopleID", DbFieldUsage.PrimaryKey)]
        public GUIDEx PeopleID { get; set; }
        ///<summary>
        ///获取或设置PeopleCode。
        ///</summary>
        [DbField("PeopleCode")]
        public int PeopleCode { get; set; }
        ///<summary>
        ///获取或设置PeopleName。
        ///</summary>
        [DbField("PeopleName")]
        public string PeopleName { get; set; }
    }
}