//================================================================================
//  FileName: ModuleConstants.cs
//  Desc:
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
    /// 模块常量。
    /// </summary>
    public static class ModuleConstants
    {
        #region 教职工。
        /// <summary>
        /// 个人档案模块ID。
        /// </summary>
        public const string PersonalStaff_ModuleID = "PB020000000000000000000000000101";
        /// <summary>
        /// 个人申报模块ID。
        /// </summary>
        public const string PersonalStaffReq_ModuleID = "PB020000000000000000000000000201";
        /// <summary>
        /// 公示职工申报模块ID。
        /// </summary>
        public const string PublicityStaffRequest_ModuleID = "PB020000000000000000000000000301";
        #endregion

        #region 学校工会。
        /// <summary>
        /// 学校教职工档案模块ID。
        /// </summary>
        public const string School_StaffInfo_ModuleID = "PB020000000000000000000000000102";
        /// <summary>
        /// 学校申报职工补助模块ID。
        /// </summary>
        public const string School_StaffReq_ModuleID = "PB020000000000000000000000000202";
        /// <summary>
        /// 审核学校申报职工补助模块ID。
        /// </summary>
        public const string School_Audit_ModuleID = "PB020000000000000000000000000302";
        /// <summary>
        /// 查看个人补助模块ID。
        /// </summary>
        public const string School_Allowance_ModuleID = "PB020000000000000000000000000402";
        /// <summary>
        /// 补助汇总模块ID。
        /// </summary>
        public const string School_Rpt_Allowance_ModuleID = "PB020000000000000000000000000502";
        #endregion

        #region 教育局工会。
        /// <summary>
        /// 教育局教职工档案模块ID。
        /// </summary>
        public const string Edu_StaffInfo_ModuleID = "PB020000000000000000000000000103";
        /// <summary>
        /// 教育局申报项目模块ID。
        /// </summary>
        public const string Edu_Project_ModuleID = "PB020000000000000000000000000203";
        /// <summary>
        /// 教育局职工申报项目补助模块ID。
        /// </summary>
        public const string Edu_StaffReq_ModuleID = "PB020000000000000000000000000303";
        /// <summary>
        /// 审核教育局职工申报项目补助模块ID。
        /// </summary>
        public const string Edu_Audit_ModuleID = "PB020000000000000000000000000403";
        /// <summary>
        /// 查询个人补助模块ID。
        /// </summary>
        public const string Edu_Allowance_ModuleID = "PB020000000000000000000000000503";
        /// <summary>
        /// 按单位年度统计模块ID。
        /// </summary>
        public const string Edu_Rpt_UnitYearAllowance_ModuleID = "PB020000000000000000000000010603";
        /// <summary>
        /// 按年度单位统计模块ID。
        /// </summary>
        public const string Edu_Rpt_YearAllowance_ModuleID = "PB020000000000000000000000020603";
        /// <summary>
        /// 按申报项目统计模块ID。
        /// </summary>
        public const string Edu_Rpt_ProjectAllowance_ModuleID = "PB020000000000000000000000030603";
        /// <summary>
        /// 按时间段统计模块ID。
        /// </summary>
        public const string Edu_Rpt_TimeAllowance_ModuleID = "PB020000000000000000000000040603";
        /// <summary>
        /// 按补助标准统计模块ID。
        /// </summary>
        public const string Edu_Rpt_Allowance_ModuleID = "PB020000000000000000000000050603";
        /// <summary>
        /// 按个人统计模块ID。
        /// </summary>
        public const string Edu_Rpt_Staff_ModuleID = "PB020000000000000000000000060603";
        #endregion

        #region 系统设置。
        /// <summary>
        /// 用户模块ID。
        /// </summary>
        public const string Employee_ModuleID = "PB000000000000000000000000000210";
        /// <summary>
        /// 单位模块ID。
        /// </summary>
        public const string Unit_ModuleID = "PB000000000000000000000000000310";
        /// <summary>
        /// 用户单位对应模块ID。
        /// </summary>
        public const string EmployeeUnit_ModuleID = "PB000000000000000000000000000410";
        /// <summary>
        /// 设置基层工会管理员模块ID。
        /// </summary>
        public const string SetBaseAdmin_ModuleID = "PB000000000000000000000000000510";
        #endregion
    }
}