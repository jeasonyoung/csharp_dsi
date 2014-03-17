//================================================================================
//  FileName: DSIProjectAttachment.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-11
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
    /// 申报项目附件。
    /// </summary>
    [DbTable("tblDSIProjectAttachment")]
    public class DSIProjectAttachment
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DSIProjectAttachment() { }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="attachId"></param>
        public DSIProjectAttachment(GUIDEx projectId, GUIDEx attachId)
        {
            this.ProjectID = projectId;
            this.AttachID = attachId;
        }
        /// <summary>
        /// 获取或设置申报项目ID。
        /// </summary>
        [DbField("ProjectID", DbFieldUsage.PrimaryKey)]
        public string ProjectID { get; set; }
        /// <summary>
        /// 获取或设置附件ID。
        /// </summary>
        [DbField("AttachID", DbFieldUsage.PrimaryKey)]
        public string AttachID { get; set; }
    }
}