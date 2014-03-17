//================================================================================
//  FileName: DSIStaffAppFormReq.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-12
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
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
    /// <summary>
    /// 职工申报救助项目表映射类。
    /// </summary>
    [XmlRoot("StaffAppFormReq")]
    [DbTable("tblDSIStaffAppFormReq")]
    public class DSIStaffAppFormReq
    {
        /// <summary>
        /// 获取或设置职工ID。
        /// </summary>
        [XmlIgnore]
        [DbField("StaffID", DbFieldUsage.PrimaryKey)]
        public string StaffID { get; set; }
        /// <summary>
        /// 获取或设置项目ID。
        /// </summary>
        [XmlIgnore]
        [DbField("ProjectID", DbFieldUsage.PrimaryKey)]
        public string ProjectID { get; set; }
        /// <summary>
        /// 获取或设置拟申报补助金额。
        /// </summary>
        [DbField("PrimaryAllowance")]
        public float PrimaryAllowance { get; set; }
        /// <summary>
        /// 获取或设置初审审核人。
        /// </summary>
        [DbField("PrimaryAudit")]
        public string PrimaryAudit { get; set; }
        /// <summary>
        /// 获取或设置审核时间。
        /// </summary>
        [DbField("PrimaryAuditTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime? PrimaryAuditTime { get; set; }
        /// <summary>
        /// 获取或设置委员会拟补助金额。
        /// </summary>
        [DbField("CommitteeAllowance")]
        public float CommitteeAllowance { get; set; }
        /// <summary>
        /// 获取或设置主管领导拟补助金额。
        /// </summary>
        [DbField("LeadershipAllowance")]
        public float LeadershipAllowance { get; set; }
        /// <summary>
        /// 获取或设置总负责人拟补助金额。
        /// </summary>
        [DbField("FinalAllowance")]
        public float FinalAllowance { get; set; }
        /// <summary>
        /// 获取或设置领取人签名。
        /// </summary>
        [DbField("Payee")]
        public string Payee { get; set; }
        /// <summary>
        /// 获取或设置申请人ID。
        /// </summary>
        [XmlIgnore]
        [DbField("CreateUserID")]
        public string CreateUserID { get; set; }
        /// <summary>
        /// 获取或设置申请人名称。
        /// </summary>
        [XmlIgnore]
        [DbField("CreateUserName")]
        public string CreateUserName { get; set; }
        /// <summary>
        /// 获取或设置申请时间。
        /// </summary>
        [XmlIgnore]
        [DbField("CreateTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 获取或设置申报状态。
        /// </summary>
        [XmlIgnore]
        [DbField("Status")]
        public int Status { get; set; }
        /// <summary>
        /// 获取或设置申报状态名称。
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// 获取或设置教职工对象。
        /// </summary>
        public DSIStaffInfo Staff { get; set; }
    }
}