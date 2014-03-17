//================================================================================
// FileName: DSIStaffInfo.cs
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
using System.Collections.Specialized;
using System.Text;

using System.Xml.Serialization;

using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.DSI.Engine.Domain
{
	///<summary>
    ///��ְ���������뵵����ӳ���ࡣ
	///</summary>
    [DbTable("tblDSIStaffAppForm")]
    public class DSIStaffInfo
    {
        ///<summary>
        ///��ȡ������ְ��ID��
        ///</summary>
        [XmlIgnore]
        [DbField("StaffID", DbFieldUsage.PrimaryKey)]
        public string StaffID { get; set; }
        ///<summary>
        ///��ȡ������ְ����š�
        ///</summary>
        [DbField("StaffCode")]
        public string StaffCode { get; set; }
        ///<summary>
        ///��ȡ�������������(1-�ͱ�����2-�ͱ���Ե����3-����������)��
        ///</summary>
        [XmlIgnore]
        [DbField("HardCategory")]
        public int HardCategory { get; set; }
        /// <summary>
        /// ��ȡ����������������ơ�
        /// </summary>
        public string HardCategoryName { get; set; }
        /// <summary>
        /// ��ȡ���������(1-��ְ��2-���ݣ�3-���ݣ�4-���ݣ�5-��ʱƸ��)��
        /// </summary>
        [XmlIgnore]
        [DbField("Theidentity")]
        public int Theidentity { get; set; }
        /// <summary>
        /// ��ȡ������������ơ�
        /// </summary>
        public string TheidentityName { get; set; }
        ///<summary>
        ///��ȡ������������
        ///</summary>
        [DbField("StaffName")]
        public string StaffName { get; set; }
        ///<summary>
        ///��ȡ�������Ա�
        ///</summary>
        [XmlIgnore]
        [DbField("Gender")]
        public int Gender { get; set; }
        /// <summary>
        /// ��ȡ�������Ա����ơ�
        /// </summary>
        public string GenderName { get; set; }
        ///<summary>
        ///��ȡ���������塣
        ///</summary>
        [XmlIgnore]
        [DbField("PeopleID")]
        public string PeopleID { get; set; }
        /// <summary>
        /// ��ȡ�������������ơ�
        /// </summary>
        public string PeopleName { get; set; }
        ///<summary>
        ///��ȡ������������ò��
        ///</summary>
        [XmlIgnore]
        [DbField("PoliticalFace")]
        public int PoliticalFace { get; set; }
        /// <summary>
        /// ��ȡ������������ò���ơ�
        /// </summary>
        public string PoliticalFaceName { get; set; }
        ///<summary>
        ///��ȡ�����ó������ڡ�
        ///</summary>
        [DbField("Birthday", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime Birthday { get; set; }
        ///<summary>
        ///��ȡ���������֤�š�
        ///</summary>
        [DbField("IDCard")]
        public string IDCard { get; set; }
        ///<summary>
        ///��ȡ�����ý���״��(1-���ã�2-������3-�м�)��
        ///</summary>
        [XmlIgnore]
        [DbField("HealthStatus")]
        public int HealthStatus { get; set; }
        /// <summary>
        /// ��ȡ�����ý���״�����ơ�
        /// </summary>
        public string HealthStatusName { get; set; }
        ///<summary>
        ///��ȡ�����òм����
        ///</summary>
        [DbField("Disability")]
        public string Disability { get; set; }
        ///<summary>
        ///��ȡ������ס������(0-���ⵥλ������1-�������ⷿ��2-�Թ�����3-����)��
        ///</summary>
        [XmlIgnore]
        [DbField("HouseType")]
        public int HouseType { get; set; }
        /// <summary>
        /// ��ȡ������ס���������ơ�
        /// </summary>
        public string HouseTypeName { get; set; }
        ///<summary>
        ///��ȡ�����ý��������
        ///</summary>
        [DbField("BuildArea")]
        public float BuildArea { get; set; }
        ///<summary>
        ///��ȡ�������������롣
        ///</summary>
        [DbField("ZipCode")]
        public string ZipCode { get; set; }
        ///<summary>
        ///��ȡ��������ϵ�绰��
        ///</summary>
        [DbField("Contact")]
        public string Contact { get; set; }
        ///<summary>
        ///��ȡ�����òμӹ���ʱ�䡣
        ///</summary>
        [DbField("TimeWorkStart", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime TimeWorkStart { get; set; }
        ///<summary>
        ///��ȡ�����û���״��(0��δ֪)��
        ///</summary>
        [XmlIgnore]
        [DbField("Maritalstatus")]
        public int Maritalstatus { get; set; }
        /// <summary>
        /// ��ȡ�����û���״�����ơ�
        /// </summary>
        public string MaritalstatusName { get; set; }
        ///<summary>
        ///��ȡ�����ù�����λ��
        ///</summary>
        [XmlIgnore]
        [DbField("UnitID")]
        public string UnitID { get; set; }
        /// <summary>
        /// ��ȡ�����ù�����λ���ơ�
        /// </summary>
        public string UnitName { get; set; }
        ///<summary>
        ///��ȡ�����ü�ͥסַ��
        ///</summary>
        [DbField("Address")]
        public string Address { get; set; }
        ///<summary>
        ///��ȡ�������Ƿ����Ծ�����(0:��,1:��;)��
        ///</summary>
        [XmlIgnore]
        [DbField("SelfHelp")]
        public int SelfHelp { get; set; }
        /// <summary>
        /// ��ȡ�������Ƿ����Ծ��������ơ�
        /// </summary>
        public string SelfHelpName { get; set; }
        ///<summary>
        ///��ȡ�����ñ����¾����롣
        ///</summary>
        [DbField("AvgIncome")]
        public float AvgIncome { get; set; }
        ///<summary>
        ///��ȡ�����ü�ͥ��������롣
        ///</summary>
        [DbField("FamilyIncome")]
        public float FamilyIncome { get; set; }
        ///<summary>
        ///��ȡ�����ü�ͥ�˿ڡ�
        ///</summary>
        [DbField("FamilyCount")]
        public int FamilyCount { get; set; }
        ///<summary>
        ///��ȡ�����ü�ͥ���˾����롣
        ///</summary>
        [DbField("FamilyAvgIncome")]
        public float FamilyAvgIncome { get; set; }
        ///<summary>
        ///��ȡ������������Ҫԭ��
        ///</summary>
        [XmlIgnore]
        [DbField("HardBecause")]
        public int HardBecause { get; set; }
        /// <summary>
        /// ��ȡ������������Ҫԭ�����ơ�
        /// </summary>
        public string HardBecauseName { get; set; }
        /// <summary>
        /// ��ȡ����������ԭ��������
        /// </summary>
        [DbField("HardBecauseDesc")]
        public string HardBecauseDesc { get; set; }
        ///<summary>
        ///��ȡ�����ô�����ID��
        ///</summary>
        [XmlIgnore]
        [DbField("CreateUserID")]
        public string CreateUserID { get; set; }
        ///<summary>
        ///��ȡ�����ô��������ơ�
        ///</summary>
        [DbField("CreateUserName")]
        public string CreateUserName { get; set; }
        ///<summary>
        ///��ȡ�����ô���ʱ�䡣
        ///</summary>
        [DbField("CreateTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ��ȡ�����ü�ͥ��Ա���ϡ�
        /// </summary>
        public List<DSIStaffFamilyMember> FamilyMembers { get; set; }
        /// <summary>
        /// ��ȡ�����ø������ϡ�
        /// </summary>
        public List<DSIAttachment> Attachments { get; set; }
    }
}