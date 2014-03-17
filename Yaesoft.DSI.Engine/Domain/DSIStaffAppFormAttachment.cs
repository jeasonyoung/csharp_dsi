//================================================================================
//  FileName: DSIStaffAppFormAttachment.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-8
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
    /// 档案附件关联。
    /// </summary>
    [DbTable("tblDSIStaffAppFormAttachment")]
    public class DSIStaffAppFormAttachment
    {
        /// <summary>
        /// 
        /// </summary>
        public DSIStaffAppFormAttachment()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="attachId"></param>
        public DSIStaffAppFormAttachment(string staffID, string attachId)
            : this()
        {
            this.StaffID = staffID;
            this.AttachID = attachId;
        }

        /// <summary>
        /// 获取或设置职工ID。
        /// </summary>
        [DbField("StaffID", DbFieldUsage.PrimaryKey)]
        public string StaffID { get; set; }
        /// <summary>
        /// 获取设置附件ID。
        /// </summary>
        [DbField("AttachID", DbFieldUsage.PrimaryKey)]
        public string AttachID { get; set; }
    }
}