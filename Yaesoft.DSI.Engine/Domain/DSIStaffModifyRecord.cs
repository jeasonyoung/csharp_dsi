//================================================================================
//  FileName: DSIStaffModifyRecord.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-5
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
    /// 档案修改记录表
    /// </summary>
    [DbTable("tblDSIStaffAppFormModifyRecord")]
    public class DSIStaffModifyRecord : iPower.Paging.ReqPaging
    {
        /// <summary>
        /// 获取或设置记录ID。
        /// </summary>
        [DbField("RecordID", DbFieldUsage.PrimaryKey)]
        public string RecordID { get; set; }
        /// <summary>
        /// 获取或设置档案ID。
        /// </summary>
        [DbField("StaffID")]
        public string StaffID { get; set; }
        /// <summary>
        /// 获取或设置档案修改内容。
        /// </summary>
        [DbField("Content")]
        public string Content { get; set; }
        /// <summary>
        /// 获取或设置创建时间。
        /// </summary>
        [DbField("CreateTime")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 获取或设置创建用户ID。
        /// </summary>
        [DbField("CreateUserId")]
        public string CreateUserId { get; set; }
        /// <summary>
        /// 获取或设置创建用户名。
        /// </summary>
        [DbField("CreateUserName")]
        public string CreateUserName { get; set; }
    }
}