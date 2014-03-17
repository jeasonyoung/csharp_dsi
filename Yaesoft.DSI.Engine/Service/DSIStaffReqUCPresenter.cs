//================================================================================
//  FileName: DSIStaffReqUCPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-15
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

using iPower;
using iPower.Platform.Engine.DataSource;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;

namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 教职工申报信息视图。
    /// </summary>
    public interface IDSIStaffReqUCView : IModuleView
    {
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="data"></param>
        void LoadData(DSIStaffAppFormReq data);
        /// <summary>
        /// 保存数据。
        /// </summary>
        /// <param name="data"></param>
        bool SaveData(DSIStaffAppFormReq data);
        /// <summary>
        /// 消息事件。
        /// </summary>
        event ShowMessageHandler ShowMessageEvent;
        /// <summary>
        /// 错误消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
    /// <summary>
    /// 教职工申报信息行为类。
    /// </summary>
    public class DSIStaffReqUCPresenter : ModulePresenter<IDSIStaffReqUCView>
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIStaffReqUCPresenter(IDSIStaffReqUCView view)
            : base(view)
        {
            this.StaffAppFormReqEntity = new DSIStaffAppFormReqEntity();
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取教职工申报救助项目实体对象。
        /// </summary>
        internal DSIStaffAppFormReqEntity StaffAppFormReqEntity { get; private set; }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateEntityData(DSIStaffAppFormReq data)
        {
            if (data == null || string.IsNullOrEmpty(data.ProjectID) || string.IsNullOrEmpty(data.StaffID)) return false;
            DSIStaffAppFormReq source = new DSIStaffAppFormReq();
            source.ProjectID = data.ProjectID;
            source.StaffID = data.StaffID;
            if (this.StaffAppFormReqEntity.LoadRecord(ref source))
            {
                if (source.Status > (int)EnumReqAuditStatus.None)
                {
                    this.View.ShowMessage("该申请已进入审核阶段不允许修改！");
                    return false;
                }
                data.CreateTime = source.CreateTime;
                data.CreateUserID = source.CreateUserID;
                data.CreateUserName = source.CreateUserName;

                data.PrimaryAllowance = source.PrimaryAllowance;
                data.PrimaryAudit = source.PrimaryAudit;
                data.PrimaryAuditTime = source.PrimaryAuditTime;

                data.CommitteeAllowance = source.CommitteeAllowance;
                data.LeadershipAllowance = source.LeadershipAllowance;
                data.FinalAllowance = source.FinalAllowance;
                data.Payee = source.Payee;

                data.Status = (int)EnumReqAuditStatus.None;
            }
            return this.StaffAppFormReqEntity.UpdateRecord(data);
        }
        /// <summary>
        /// 批量删除。
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        public bool DeleteEntityData(StringCollection primaryValues)
        {
            if (primaryValues == null || primaryValues.Count == 0) return false;
            StringCollection prs = new StringCollection();
            for (int i = 0; i < primaryValues.Count; i++)
            {
                string[] strs = primaryValues[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (strs != null && strs.Length == 2)
                {
                    DSIStaffAppFormReq data = new DSIStaffAppFormReq();
                    data.StaffID = strs[0];
                    data.ProjectID = strs[1];
                    if (this.StaffAppFormReqEntity.LoadRecord(ref data))
                    {
                        if (data.Status != 0)
                        {
                            this.View.ShowMessage("不能删除，已审核！");
                            continue;
                        }
                        prs.Add(prs[i]);
                    }
                }
            }
            return this.StaffAppFormReqEntity.DeleteRecord(prs);
        }
        #endregion
    }
}