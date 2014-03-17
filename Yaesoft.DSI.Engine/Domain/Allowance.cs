//================================================================================
//  FileName: Allowance.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-22
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

namespace Yaesoft.DSI.Engine.Domain
{
    /// <summary>
    /// 教职工补助信息。
    /// </summary>
    [Serializable]
    public class Allowance
    {
        /// <summary>
        /// 获取或设置项目名称。
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 获取或设置所属单位。
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 获取或设置教职工姓名。
        /// </summary>
        public string StaffName { get; set; }
        /// <summary>
        /// 获取或设置性别。
        /// </summary>
        public string GenderName { get; set; }
        /// <summary>
        /// 获取或设置年龄。
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 获取或设置身份证。
        /// </summary>
        public string IDCard { get; set; }
        /// <summary>
        /// 获取或设置补助。
        /// </summary>
        public double Money { get; set; }
        /// <summary>
        /// 获取或设置时间。
        /// </summary>
        public DateTime? Time { get; set; }
    }
}