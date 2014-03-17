//================================================================================
// FileName: DSIStaffFamilyMember.cs
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

using System.Xml.Serialization;
	
using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.DSI.Engine.Domain
{
	///<summary>
    ///��ְ������������ͥ��Աӳ���ࡣ
	///</summary>
	[Serializable]
    [DbTable("tblDSIStaffAppFormFamily")]
	public class DSIStaffFamilyMember
	{
		///<summary>
        ///��ȡ������ְ��ID��
		///</summary>
        [XmlIgnore]
        [DbField("StaffID")]
        public GUIDEx StaffID { get; set; }
		///<summary>
        ///��ȡ�����ó�ԱID��
		///</summary>
        [XmlIgnore]
        [DbField("MemberID", DbFieldUsage.PrimaryKey)]
        public GUIDEx MemberID { get; set; }
		///<summary>
        ///��ȡ������������
		///</summary>
        [DbField("MemberName")]
        public string MemberName { get; set; }
		///<summary>
        ///��ȡ�����ù�ϵ(0:δ֪)��
		///</summary>
        [XmlIgnore]
        [DbField("Relation")]
        public int Relation { get; set; }
        /// <summary>
        /// ��ȡ�����ù�ϵ���ơ�
        /// </summary>
        public string RelationName { get; set; }
		///<summary>
        ///��ȡ�������Ա�(0:δ֪��1���У�2:Ů)��
		///</summary>
        [XmlIgnore]
        [DbField("Gender")]
        public int Gender { get; set; }
        /// <summary>
        /// ��ȡ�������Ա����ơ�
        /// </summary>
        public string GenderName { get; set; }
		///<summary>
        ///��ȡ������������ò(0:δ֪)��
		///</summary>
        [XmlIgnore]
        [DbField("PoliticalFace")]
        public int PoliticalFace { get; set; }
        /// <summary>
        /// ��ȡ������������ò���ơ�
        /// </summary>
        public string PoliticalFaceName { get; set; }
		///<summary>
        ///��ȡ���������֤�š�
		///</summary>
        [DbField("IDCard")]
        public string IDCard { get; set; }
		///<summary>
        ///��ȡ�����ó������ڡ�
		///</summary>
        [DbField("Birthday", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime Birthday { get; set; }
		///<summary>
        ///��ȡ�����ý���״����1-���ã�2-�������������ţ���д���弲�����ƣ���3-�м�����
		///</summary>
        [XmlIgnore]
        [DbField("HealthStatus")]
        public int HealthStatus { get; set; }
        /// <summary>
        /// ��ȡ�����ý���״�����ơ�
        /// </summary>
        public string HealthStatusName { get; set; }
		///<summary>
        ///��ȡ�����������롣
		///</summary>
        [DbField("Income")]
        public float Income { get; set; }
		///<summary>
        ///��ȡ��������ݣ�0:δ֪����
		///</summary>
        [XmlIgnore]
        [DbField("MemberTheidentity")]
        public int Theidentity { get; set; }
        /// <summary>
        /// ��ȡ������������ơ�
        /// </summary>
        public string TheidentityName { get; set; }
		///<summary>
        ///��ȡ�����ù�����λ��ѧУ��
		///</summary>
        [DbField("UnitSchool")]
        public string UnitSchool { get; set; }
	}
}