//================================================================================
// FileName: DSIStaffInfo.cs
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
using System.Collections.Specialized;
using System.Text;

using System.Xml.Serialization;

using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.DSI.Engine.Domain
{
	///<summary>
    ///教职工救助申请档案表映射类。
	///</summary>
    [DbTable("tblDSIStaffAppForm")]
    public class DSIStaffInfo
    {
        ///<summary>
        ///获取或设置职工ID。
        ///</summary>
        [XmlIgnore]
        [DbField("StaffID", DbFieldUsage.PrimaryKey)]
        public string StaffID { get; set; }
        ///<summary>
        ///获取或设置职工编号。
        ///</summary>
        [DbField("StaffCode")]
        public string StaffCode { get; set; }
        ///<summary>
        ///获取或设置困难类别(1-低保户，2-低保边缘户，3-意外致困户)。
        ///</summary>
        [XmlIgnore]
        [DbField("HardCategory")]
        public int HardCategory { get; set; }
        /// <summary>
        /// 获取或设置困难类别名称。
        /// </summary>
        public string HardCategoryName { get; set; }
        /// <summary>
        /// 获取或设置身份(1-在职，2-退休，3-离休，4-病休，5-临时聘用)。
        /// </summary>
        [XmlIgnore]
        [DbField("Theidentity")]
        public int Theidentity { get; set; }
        /// <summary>
        /// 获取或设置身份名称。
        /// </summary>
        public string TheidentityName { get; set; }
        ///<summary>
        ///获取或设置姓名。
        ///</summary>
        [DbField("StaffName")]
        public string StaffName { get; set; }
        ///<summary>
        ///获取或设置性别。
        ///</summary>
        [XmlIgnore]
        [DbField("Gender")]
        public int Gender { get; set; }
        /// <summary>
        /// 获取或设置性别名称。
        /// </summary>
        public string GenderName { get; set; }
        ///<summary>
        ///获取或设置民族。
        ///</summary>
        [XmlIgnore]
        [DbField("PeopleID")]
        public string PeopleID { get; set; }
        /// <summary>
        /// 获取或设置民族名称。
        /// </summary>
        public string PeopleName { get; set; }
        ///<summary>
        ///获取或设置政治面貌。
        ///</summary>
        [XmlIgnore]
        [DbField("PoliticalFace")]
        public int PoliticalFace { get; set; }
        /// <summary>
        /// 获取或设置政治面貌名称。
        /// </summary>
        public string PoliticalFaceName { get; set; }
        ///<summary>
        ///获取或设置出生日期。
        ///</summary>
        [DbField("Birthday", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime Birthday { get; set; }
        ///<summary>
        ///获取或设置身份证号。
        ///</summary>
        [DbField("IDCard")]
        public string IDCard { get; set; }
        ///<summary>
        ///获取或设置健康状况(1-良好，2-疾病，3-残疾)。
        ///</summary>
        [XmlIgnore]
        [DbField("HealthStatus")]
        public int HealthStatus { get; set; }
        /// <summary>
        /// 获取或设置健康状况名称。
        /// </summary>
        public string HealthStatusName { get; set; }
        ///<summary>
        ///获取或设置残疾类别。
        ///</summary>
        [DbField("Disability")]
        public string Disability { get; set; }
        ///<summary>
        ///获取或设置住房类型(0-承租单位公房，1-政府廉租房，2-自购房，3-其他)。
        ///</summary>
        [XmlIgnore]
        [DbField("HouseType")]
        public int HouseType { get; set; }
        /// <summary>
        /// 获取或设置住房类型名称。
        /// </summary>
        public string HouseTypeName { get; set; }
        ///<summary>
        ///获取或设置建筑面积。
        ///</summary>
        [DbField("BuildArea")]
        public float BuildArea { get; set; }
        ///<summary>
        ///获取或设置邮政编码。
        ///</summary>
        [DbField("ZipCode")]
        public string ZipCode { get; set; }
        ///<summary>
        ///获取或设置联系电话。
        ///</summary>
        [DbField("Contact")]
        public string Contact { get; set; }
        ///<summary>
        ///获取或设置参加工作时间。
        ///</summary>
        [DbField("TimeWorkStart", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime TimeWorkStart { get; set; }
        ///<summary>
        ///获取或设置婚姻状况(0：未知)。
        ///</summary>
        [XmlIgnore]
        [DbField("Maritalstatus")]
        public int Maritalstatus { get; set; }
        /// <summary>
        /// 获取或设置婚姻状况名称。
        /// </summary>
        public string MaritalstatusName { get; set; }
        ///<summary>
        ///获取或设置工作单位。
        ///</summary>
        [XmlIgnore]
        [DbField("UnitID")]
        public string UnitID { get; set; }
        /// <summary>
        /// 获取或设置工作单位名称。
        /// </summary>
        public string UnitName { get; set; }
        ///<summary>
        ///获取或设置家庭住址。
        ///</summary>
        [DbField("Address")]
        public string Address { get; set; }
        ///<summary>
        ///获取或设置是否有自救能力(0:否,1:是;)。
        ///</summary>
        [XmlIgnore]
        [DbField("SelfHelp")]
        public int SelfHelp { get; set; }
        /// <summary>
        /// 获取或设置是否有自救能力名称。
        /// </summary>
        public string SelfHelpName { get; set; }
        ///<summary>
        ///获取或设置本人月均收入。
        ///</summary>
        [DbField("AvgIncome")]
        public float AvgIncome { get; set; }
        ///<summary>
        ///获取或设置家庭年度总收入。
        ///</summary>
        [DbField("FamilyIncome")]
        public float FamilyIncome { get; set; }
        ///<summary>
        ///获取或设置家庭人口。
        ///</summary>
        [DbField("FamilyCount")]
        public int FamilyCount { get; set; }
        ///<summary>
        ///获取或设置家庭月人均收入。
        ///</summary>
        [DbField("FamilyAvgIncome")]
        public float FamilyAvgIncome { get; set; }
        ///<summary>
        ///获取或设置致困主要原因。
        ///</summary>
        [XmlIgnore]
        [DbField("HardBecause")]
        public int HardBecause { get; set; }
        /// <summary>
        /// 获取或设置致困主要原因名称。
        /// </summary>
        public string HardBecauseName { get; set; }
        /// <summary>
        /// 获取或设置致困原因描述。
        /// </summary>
        [DbField("HardBecauseDesc")]
        public string HardBecauseDesc { get; set; }
        ///<summary>
        ///获取或设置创建者ID。
        ///</summary>
        [XmlIgnore]
        [DbField("CreateUserID")]
        public string CreateUserID { get; set; }
        ///<summary>
        ///获取或设置创建者名称。
        ///</summary>
        [DbField("CreateUserName")]
        public string CreateUserName { get; set; }
        ///<summary>
        ///获取或设置创建时间。
        ///</summary>
        [DbField("CreateTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 获取或设置家庭成员集合。
        /// </summary>
        public List<DSIStaffFamilyMember> FamilyMembers { get; set; }
        /// <summary>
        /// 获取或设置附件集合。
        /// </summary>
        public List<DSIAttachment> Attachments { get; set; }
    }
}