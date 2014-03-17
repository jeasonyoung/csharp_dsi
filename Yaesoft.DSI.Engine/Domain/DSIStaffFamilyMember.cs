//================================================================================
// FileName: DSIStaffFamilyMember.cs
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

using System.Xml.Serialization;
	
using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.DSI.Engine.Domain
{
	///<summary>
    ///教职工救助申请表家庭成员映射类。
	///</summary>
	[Serializable]
    [DbTable("tblDSIStaffAppFormFamily")]
	public class DSIStaffFamilyMember
	{
		///<summary>
        ///获取或设置职工ID。
		///</summary>
        [XmlIgnore]
        [DbField("StaffID")]
        public GUIDEx StaffID { get; set; }
		///<summary>
        ///获取或设置成员ID。
		///</summary>
        [XmlIgnore]
        [DbField("MemberID", DbFieldUsage.PrimaryKey)]
        public GUIDEx MemberID { get; set; }
		///<summary>
        ///获取或设置姓名。
		///</summary>
        [DbField("MemberName")]
        public string MemberName { get; set; }
		///<summary>
        ///获取或设置关系(0:未知)。
		///</summary>
        [XmlIgnore]
        [DbField("Relation")]
        public int Relation { get; set; }
        /// <summary>
        /// 获取或设置关系名称。
        /// </summary>
        public string RelationName { get; set; }
		///<summary>
        ///获取或设置性别(0:未知，1：男，2:女)。
		///</summary>
        [XmlIgnore]
        [DbField("Gender")]
        public int Gender { get; set; }
        /// <summary>
        /// 获取或设置性别名称。
        /// </summary>
        public string GenderName { get; set; }
		///<summary>
        ///获取或设置政治面貌(0:未知)。
		///</summary>
        [XmlIgnore]
        [DbField("PoliticalFace")]
        public int PoliticalFace { get; set; }
        /// <summary>
        /// 获取或设置政治面貌名称。
        /// </summary>
        public string PoliticalFaceName { get; set; }
		///<summary>
        ///获取或设置身份证号。
		///</summary>
        [DbField("IDCard")]
        public string IDCard { get; set; }
		///<summary>
        ///获取或设置出生日期。
		///</summary>
        [DbField("Birthday", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime Birthday { get; set; }
		///<summary>
        ///获取或设置健康状况：1-良好，2-疾病（此项不填序号，填写具体疾病名称），3-残疾。。
		///</summary>
        [XmlIgnore]
        [DbField("HealthStatus")]
        public int HealthStatus { get; set; }
        /// <summary>
        /// 获取或设置健康状况名称。
        /// </summary>
        public string HealthStatusName { get; set; }
		///<summary>
        ///获取或设置月收入。
		///</summary>
        [DbField("Income")]
        public float Income { get; set; }
		///<summary>
        ///获取或设置身份（0:未知）。
		///</summary>
        [XmlIgnore]
        [DbField("MemberTheidentity")]
        public int Theidentity { get; set; }
        /// <summary>
        /// 获取或设置身份名称。
        /// </summary>
        public string TheidentityName { get; set; }
		///<summary>
        ///获取或设置工作单位或学校。
		///</summary>
        [DbField("UnitSchool")]
        public string UnitSchool { get; set; }
	}
}