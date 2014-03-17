//================================================================================
//  FileName: Attachment.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-4
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
    /// 附件管理。
    /// </summary>
    [Serializable]
    [DbTable("tblDSIAttachment")]
    public class DSIAttachment
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DSIAttachment()
        {
            this.Create = DateTime.Now;
            this.Size = 0;
        }

        /// <summary>
        /// 获取或设置附件ID。
        /// </summary>
        [DbField("AttachID", DbFieldUsage.PrimaryKey)]
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置附件名称。
        /// </summary>
        [DbField("AttachName")]
        public string Name { get; set; }
        /// <summary>
        /// 获取附件后缀名。
        /// </summary>
        [XmlIgnore]
        public string Ext
        {
            get
            {
                if (string.IsNullOrEmpty(this.Name)) return string.Empty;
                return System.IO.Path.GetExtension(this.Name);
            }
        }
        /// <summary>
        /// 获取或设置内容类型
        /// </summary>
        [DbField("ContentType")]
        public string ContentType { get; set; }
        /// <summary>
        /// 获取或设置附件大小(MB)。
        /// </summary>
        [DbField("AttachSize")]
        public float Size { get; set; }
        /// <summary>
        /// 获取或设置附件路径。
        /// </summary>
        [XmlIgnore]
        [DbField("AttachPath")]
        public string Path { get; set; }
        /// <summary>
        /// 获取或设置创建时间。
        /// </summary>
        [DbField("AttachCreate", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime? Create { get; set; }
        /// <summary>
        /// 获取或设置附件数据。
        /// </summary>
        [XmlIgnore]
        public byte[] Raw { get; set; }
    }
}