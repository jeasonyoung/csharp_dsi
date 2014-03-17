//================================================================================
//  FileName: DSIProjectAttachmentEntity.cs
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
using System.Collections.Specialized;
using System.Text;
using System.Data;

using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.DSI.Engine.Domain;
namespace Yaesoft.DSI.Engine.Persistence
{
    /// <summary>
    /// 申报项目附件实例。
    /// </summary>
    internal class DSIProjectAttachmentEntity :DbModuleEntity<DSIProjectAttachment>
    {
        #region 成员变量，构造函数。
        private DSIAttachmentEntity attachmentEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DSIProjectAttachmentEntity()
        {
            this.attachmentEntity = new DSIAttachmentEntity();
        }
        #endregion

        /// <summary>
        /// 加载附件。
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<DSIAttachment> LoadAttachments(string projectId)
        {
            if (string.IsNullOrEmpty(projectId)) return null;
            const string sql = "select * from vwDSIProjectAttachment where ProjectID = '{0}' order by AttachCreate desc";
            DataTable dtSource = this.DatabaseAccess.ExecuteDataset(string.Format(sql, projectId)).Tables[0];
            if (dtSource != null) return this.attachmentEntity.ConvertDataSource(dtSource);
            return null;
        }
        /// <summary>
        /// 更新附件。
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="attachments"></param>
        /// <param name="delAttachments"></param>
        /// <returns></returns>
        public bool UpdateRecord(string projectId, List<DSIAttachment> attachments, StringCollection delAttachments)
        {
            if (string.IsNullOrEmpty(projectId)) return false;
            if (delAttachments != null && delAttachments.Count > 0)
            {
                string[] ids = new string[delAttachments.Count];
                delAttachments.CopyTo(ids, 0);
                this.DeleteRecord(string.Format("ProjectID = '{0}' and (AttachID in '{1}')", projectId, string.Join("','", ids)));
            }
            if (attachments != null && attachments.Count > 0)
            {
                foreach (DSIAttachment attach in attachments)
                {
                    if (this.attachmentEntity.UpdateRecord(attach))
                    {
                        this.UpdateRecord(new DSIProjectAttachment(projectId, attach.ID));
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 删除数据。
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        public bool DeleteRecordByProjectID(string[] primaryValues)
        {
            return this.DeleteRecord(string.Format("ProjectID in ('{0}')", string.Join("','", primaryValues)));
        }
    }
}