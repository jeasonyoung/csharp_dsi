//================================================================================
//  FileName: DSIStaffAppFormAttachmentEntity.cs
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
    /// 职工档案附件操作实体。
    /// </summary>
    internal class DSIStaffAppFormAttachmentEntity : DbModuleEntity<DSIStaffAppFormAttachment>
    {
        #region 成员变量，构造函数。
        private DSIAttachmentEntity attachmentEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DSIStaffAppFormAttachmentEntity()
        {
            this.attachmentEntity = new DSIAttachmentEntity();
        }
        #endregion

        /// <summary>
        /// 加载附件。
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        public List<DSIAttachment> LoadAttachments(string staffId)
        {
            const string sql = "select * from vwDSIStaffAppFormAttachment where StaffID = '{0}' order by AttachCreate desc";
            DataTable dtSource = this.DatabaseAccess.ExecuteDataset(string.Format(sql, staffId)).Tables[0];

            if (dtSource != null) return this.attachmentEntity.ConvertDataSource(dtSource);
            return null;
        }
        /// <summary>
        /// 更新附件。
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="attachments"></param>
        /// <param name="delAttachments"></param>
        /// <returns></returns>
        public bool UpdateRecord(string staffID, List<DSIAttachment> attachments, StringCollection delAttachments)
        {
            if (string.IsNullOrEmpty(staffID)) return false;
            if (delAttachments != null && delAttachments.Count > 0)
            {
                string[] ids = new string[delAttachments.Count];
                delAttachments.CopyTo(ids, 0);
                this.DeleteRecord(string.Format("StaffID = '{0}' and (AttachID in '{1}')", staffID, string.Join("','", ids)));
            }
            if (attachments != null && attachments.Count > 0)
            {
                foreach (DSIAttachment attach in attachments)
                {
                    if (this.attachmentEntity.UpdateRecord(attach))
                    {
                        this.UpdateRecord(new DSIStaffAppFormAttachment(staffID, attach.ID));
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 删除数据。
        /// </summary>
        /// <param name="primaryValues">职工ID集合。</param>
        /// <returns></returns>
        public bool DeleteRecordByStaffID(string[] primaryValues)
        {
            return this.DeleteRecord(string.Format("StaffID in ('{0}')", string.Join("','", primaryValues)));
        }
    }
}