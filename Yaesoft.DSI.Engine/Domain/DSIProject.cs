//================================================================================
//  FileName: DSIProject.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-10
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

using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.DSI.Engine.Domain
{
    /// <summary>
    /// 申报项目。
    /// </summary>
    [DbTable("tblDSIProject")]
    public class DSIProject
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DSIProject()
        {
            this.CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 获取或设置项目ID。
        /// </summary>
        [DbField("ProjectID", DbFieldUsage.PrimaryKey)]
        public string ProjectID { get; set; }
        /// <summary>
        /// 获取或设置项目名称。
        /// </summary>
        [DbField("ProjectName")]
        public string ProjectName { get; set; }
        /// <summary>
        /// 获取或设置申报开始时间。
        /// </summary>
        [DbField("StartTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 获取或设置申报结束时间。
        /// </summary>
        [DbField("EndTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 获取或设置是否在首页。
        /// </summary>
        [DbField("IsView")]
        public int IsView { get; set; }
        /// <summary>
        /// 获取或设置内容。
        /// </summary>
        [DbField("Content")]
        public string Content { get; set; }
        /// <summary>
        /// 获取或设置创建时间。
        /// </summary>
        [DbField("CreateTime")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 获取或设置创建者ID。
        /// </summary>
        [DbField("CreateUserID")]
        public string CreateUserID { get; set; }
        /// <summary>
        /// 获取或设置创建者名。
        /// </summary>
        [DbField("CreateUserName")]
        public string CreateUserName { get; set; }
        /// <summary>
        /// 获取是否在有效时间内。
        /// </summary>
        public bool IsActive
        {
            get
            {
                if (this.StartTime == null || this.EndTime == null) return false;
                DateTime now = DateTime.Now;

                return (now >= this.StartTime && now <= this.EndTime);
            }
        }
        /// <summary>
        /// 获取或设置附件集合。
        /// </summary>
        public List<DSIAttachment> Attachments { get; set; }
    }
}