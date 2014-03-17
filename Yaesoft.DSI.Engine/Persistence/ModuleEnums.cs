//================================================================================
//  FileName: ModuleEnums.cs
//  Desc:枚举类文件。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/1
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

namespace Yaesoft.DSI.Engine.Persistence
{
    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum EnumGender
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown=0x00,
        /// <summary>
        /// 男。
        /// </summary>
        Male = 0x01,
        /// <summary>
        /// 女。
        /// </summary>
        Female = 0x02
    }
    /// <summary>
    ///政治面貌枚举 
    /// </summary>
    public enum EnumPoliticalFace
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0x01,
        /// <summary>
        /// 中共党员。
        /// </summary>
        CpcMember=0x02,
        /// <summary>
        /// 共青团员。
        /// </summary>
        YouthLeague=0x03,
        /// <summary>
        /// 群众。
        /// </summary>
        People=0x04,
        /// <summary>
        /// 民主党派。
        /// </summary>
        Democracy=0x05,
        /// <summary>
        /// 其他。
        /// </summary>
        Other=0x06
    }
    /// <summary>
    /// 健康状况枚举
    /// </summary>
    public enum EnumHealthStatus
    {
        /// <summary>
        /// 良好。
        /// </summary>
        Good = 0x01,
        /// <summary>
        /// 疾病。
        /// </summary>
        Disease = 0x02,
        /// <summary>
        /// 残疾。
        /// </summary>
        Disability = 0x03
    }
    /// <summary>
    /// 住房类型枚举。
    /// </summary>
    public enum EnumHouseType
    {
        /// <summary>
        /// 承租单位公房。
        /// </summary>
        RentUnitHouse = 0x01,
        /// <summary>
        /// 政府廉租房。
        /// </summary>
        LowCostHouse = 0x02,
        /// <summary>
        /// 自购房。
        /// </summary>
        SelfHouse = 0x03,
        /// <summary>
        /// 其他。
        /// </summary>
        Other = 0x04
    }
    /// <summary>
    /// 婚姻状况。
    /// </summary>
    public enum EnumMaritalStatus
    {
        /// <summary>
        ///  已婚。
        /// </summary>
        Married=0x01,
        /// <summary>
        /// 未婚。
        /// </summary>
        Unmarried=0x02,
        /// <summary>
        /// 离异。
        /// </summary>
        Divorced=0x03,
        /// <summary>
        /// 丧偶。
        /// </summary>
        Widowed=0x04
    }
    /// <summary>
    /// 致困主要原因
    /// </summary>
    public enum EnumHardBecause
    {
        /// <summary>
        /// 因天灾人祸致困造成损失3-5万。
        /// </summary>
        Disaster3_5 = 0x01,
        /// <summary>
        /// 因天灾人祸致困造成损失5-10万。
        /// </summary>
        Disaster5_10 = 0x02,
        /// <summary>
        /// 因天灾人祸致困造成损失10万以上。
        /// </summary>
        Disaster10_ = 0x03,
        /// <summary>
        /// 因病致困年度自付金额1万元以上。
        /// </summary>
        Disease = 0x04,
        /// <summary>
        /// 其他特殊情况致家庭负债3-5万。
        /// </summary>
        Other3_5 = 0x05,
        /// <summary>
        /// 其他特殊情况致家庭负债5-10万。
        /// </summary>
        Other5_10 = 0x06,
        /// <summary>
        /// 其他特殊情况致家庭负债10万以上。
        /// </summary>
        Other10_ = 0x07,
        /// <summary>
        /// 子女读大学。
        /// </summary>
        Children = 0x08
    }
    /// <summary>
    /// 困难类别
    /// </summary>
    public enum EnumHardCategory
    {
        /// <summary>
        /// 因天灾人祸致困。
        /// </summary>
        Disaster = 0x01,
        /// <summary>
        /// 因病致困。
        /// </summary>
        Disease = 0x02,
        /// <summary>
        /// 其他特殊情况。
        /// </summary>
        Other = 0x03
    }
    /// <summary>
    /// 是否有自救能力
    /// </summary>
    public enum EnumSelfHelp
    {
        /// <summary>
        /// 否
        /// </summary>
        SelfHelpNo=0x00,
        /// <summary>
        /// 是
        /// </summary>
        SelfHelpYes=0x01
    }
    /// <summary>
    /// 成员关系
    /// </summary>                
    public enum EnumRelation
    {
        /// <summary>
        /// 父亲
        /// </summary>
        Father=0x01,
        /// <summary>
        /// 母亲
        /// </summary>
        Mother=0x02,
        /// <summary>
        /// 丈夫
        /// </summary>
        Husband=0x03,
        /// <summary>
        /// 妻子
        /// </summary>
        Wife=0x04,
        /// <summary>
        /// 儿子
        /// </summary>
        Son=0x05,
        /// <summary>
        /// 女儿
        /// </summary>
        Daughter=0x06,
        /// <summary>
        /// 其他
        /// </summary>
        Other=0x07
    }
    /// <summary>
    /// 身份。
    /// </summary>
    public enum EnumTheidentity
    {
        /// <summary>
        /// 在职
        /// </summary>
        InService = 0x01,
        /// <summary>
        /// 退休
        /// </summary>
        Retirement = 0x02,
        /// <summary>
        /// 离休
        /// </summary>
        Retired = 0x03,
        /// <summary>
        /// 病休
        /// </summary>
        Illness = 0x04,
        /// <summary>
        /// 临时聘用
        /// </summary>
        Temporary = 0x05
    }
    /// <summary>
    /// 家庭成员身份
    /// </summary>
    public enum EnumMemberTheidentity
    {
        /// <summary>
        /// 在岗
        /// </summary>
        ThePost = 0x01,
        /// <summary>
        /// 下(待)岗
        /// </summary>
        LaidOff = 0x02,
        /// <summary>
        /// 失(无)业
        /// </summary>
        Unemployment = 0x03,
        /// <summary>
        /// 退休
        /// </summary>
        Retirement = 0x04,
        /// <summary>
        /// 内退
        /// </summary>
        InRetirement = 0x05,
        /// <summary>
        /// 农民工
        /// </summary>
        Farmer = 0x06,
        /// <summary>
        /// 研究生
        /// </summary>
        Graduate=0x07,
        /// <summary>
        /// 大学生
        /// </summary>
        Unstudent=0x08,
        /// <summary>
        ///  中职中技
        /// </summary>
        Secondary=0x09,
        /// <summary>
        /// 高中
        /// </summary>
        HSchool=0x10,
        /// <summary>
        /// 初中
        /// </summary>
        School=0x11,
        /// <summary>
        /// 小学
        /// </summary>
        Prischool=0x12
    }
    /// <summary>
    /// 教职工申报补助审批状态。
    /// </summary>
    [Serializable]
    public enum EnumReqAuditStatus : int
    {
        /// <summary>
        /// 申请。
        /// </summary>
        None = 0,
        /// <summary>
        /// 初审通过。
        /// </summary>
        Primary = 1,
        /// <summary>
        /// 初审未通过。
        /// </summary>
        NonPrimary = -1,
        /// <summary>
        /// 终审通过。
        /// </summary>
        Final = 2,
        /// <summary>
        /// 终审未过。
        /// </summary>
        NonFinal = -2,
        /// <summary>
        /// 已领款。
        /// </summary>
        Payee = 3
    }

}