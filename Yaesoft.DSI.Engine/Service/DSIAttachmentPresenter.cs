//================================================================================
//  FileName: DSIAttachmentPresenter.cs
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
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 附件管理视图。
    /// </summary>
    public interface IDSIAttachmentView<T> : IModuleView
    {
        /// <summary>
        /// 获取或设置上传附件。
        /// </summary>
        DSIAttachment UploadAttachment { get; set; }
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="attachId"></param>
        void LoadData(string attachId);
        /// <summary>
        /// 保存数据。
        /// </summary>
        /// <param name="data"></param>
        void SaveData(T data);
        /// <summary>
        /// 消息事件。
        /// </summary>
        event ShowMessageHandler ShowMessageEvent;
        /// <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);
    }
    /// <summary>
    /// 附件管理行为类。
    /// </summary>
    public class DSIAttachmentPresenter<T>: ModulePresenter<IDSIAttachmentView<T>>
    {
        #region 成员变量，构造函数。
        private static DSIAttachmentEntity attachmentEntity = new DSIAttachmentEntity();
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DSIAttachmentPresenter(IDSIAttachmentView<T> view)
            : base(view)
        {
        }
        #endregion

        /// <summary>
        /// 加载附件对象。
        /// </summary>
        /// <param name="attachId"></param>
        /// <returns></returns>
        public DSIAttachment LoadAttachment(string attachId)
        {
            if (string.IsNullOrEmpty(attachId)) return null;
            DSIAttachment data = new DSIAttachment();
            data.ID = attachId;
            if (attachmentEntity.LoadRecord(ref data))
            {
                return data;
            }
            return null;
        }
        /// <summary>
        /// 更新附件数据。
        /// </summary>
        /// <param name="data"></param>
        public void UpdateAttachment(DSIAttachment data)
        {
            if (data == null || string.IsNullOrEmpty(data.ID)) return;
            attachmentEntity.UpdateRecord(data);
        }
        /// <summary>
        /// 下载附件。
        /// </summary>
        /// <param name="attachId"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static byte[] Download(string attachId, out string name, out string contentType)
        {
            return attachmentEntity.Download(attachId, out name, out contentType);
        }
    }
}