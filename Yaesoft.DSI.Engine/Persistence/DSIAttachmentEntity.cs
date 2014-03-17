//================================================================================
//  FileName: DSIAttachmentEntity.cs
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
using System.IO;
using System.Data;
using iPower;
using iPower.FileStorage;
using Yaesoft.DSI.Engine.Domain;
namespace Yaesoft.DSI.Engine.Persistence
{
    /// <summary>
    /// 附件管理实体类。
    /// </summary>
    internal class DSIAttachmentEntity : DbModuleEntity<DSIAttachment>
    {
        #region 成员变量，构造函数。
        private IFileStorageFactory factory;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DSIAttachmentEntity()
        {
            this.factory = this.ModuleConfig.FileStorageFacotry;
        }
        #endregion
                
        /// <summary>
        /// 下载附件。
        /// </summary>
        /// <param name="attachId"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public byte[] Download(string attachId, out string name, out string contentType)
        {
            name = contentType = null;
            if (string.IsNullOrEmpty(attachId)) throw new ArgumentNullException("attachId", "附件ID为空！");
            DSIAttachment data = new DSIAttachment();
            data.ID = attachId;
            if (this.LoadRecord(ref data))
            {
                name = data.Name;
                contentType = data.ContentType;
                return this.factory.Download(data.Path);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool UpdateRecord(DSIAttachment entity)
        {
            int len = 0;
            if (entity.Raw != null && (len = entity.Raw.Length) > 0)
            {
                entity.Size = (len / (float)1024 / (float)1024);//MB。
                entity.Path = string.Format("{0:yyyy-MM-dd}\\{1}{2}", entity.Create, entity.ID, Path.GetExtension(entity.Name));
                if (!this.factory.Upload(entity.Path, 0, entity.Raw)) throw new IOException("上传附件保存失败！");
            }
            return base.UpdateRecord(entity);
        }
    }
}