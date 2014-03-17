//================================================================================
// FileName: DSIPeople.cs
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
	///tblDSIPeopleӳ���ࡣ
	///</summary>
    [DbTable("tblDSIPeople")]
    public class DSIPeople
    {
        ///<summary>
        ///��ȡ������PeopleID��
        ///</summary>
        [DbField("PeopleID", DbFieldUsage.PrimaryKey)]
        public GUIDEx PeopleID { get; set; }
        ///<summary>
        ///��ȡ������PeopleCode��
        ///</summary>
        [DbField("PeopleCode")]
        public int PeopleCode { get; set; }
        ///<summary>
        ///��ȡ������PeopleName��
        ///</summary>
        [DbField("PeopleName")]
        public string PeopleName { get; set; }
    }
}