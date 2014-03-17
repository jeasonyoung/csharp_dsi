//================================================================================
//  FileName: DSIStaffAppFormReqPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-14
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
using iPower.Platform.Engine.Service;
using iPower.Platform.Engine.DataSource;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 教职工申报补助视图接口。
    /// </summary>
    public interface IDSIStaffAppFormReqView : IModuleView
    {
        /// <summary>
        /// 错误消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
    /// <summary>
    /// 教职工申报补助行为类。
    /// </summary>
    public abstract class DSIStaffAppFormReqPresenter : ModulePresenter<IDSIStaffAppFormReqView>
    {
        #region 成员变量，构造函数。
        private DSIStaffAppFormReqEntity staffAppFormReqEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIStaffAppFormReqPresenter(IDSIStaffAppFormReqView view)
            : base(view)
        {
            this.staffAppFormReqEntity = new DSIStaffAppFormReqEntity();
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentUserID"></param>
        /// <returns></returns>
        protected DSIStaffInfo LoadStaffByUserId(string currentUserID)
        {
            if (string.IsNullOrEmpty(currentUserID)) return null;
            return this.staffAppFormReqEntity.LoadStaffByUserID(currentUserID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public DSIStaffAppFormReq LoadStaffAppFormReq(string staffID,string projectID)
        {
            if (string.IsNullOrEmpty(staffID) || string.IsNullOrEmpty(projectID)) return null;
            DSIStaffAppFormReq data = new DSIStaffAppFormReq();
            data.StaffID = staffID;
            data.ProjectID = projectID;
            if (this.LoadStaffAppFormReq(ref data))
            {
                return data;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool LoadStaffAppFormReq(ref DSIStaffAppFormReq data)
        {
            if (string.IsNullOrEmpty(data.StaffID) || string.IsNullOrEmpty(data.ProjectID)) return false;
            return this.staffAppFormReqEntity.LoadRecord(ref data);
        }
        /// <summary>
        /// 个人申报列表数据。
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public DataTable PersonalListDataSource(string projectName)
        {
            return this.ConvertListDataSource(this.staffAppFormReqEntity.PersonalListDataSource(projectName, this.View.CurrentUserID));
        }
        /// <summary>
        /// 获取学校职工申请列表数据。
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public DataTable SchoolListDataSource(string projectName, string staffName)
        {
            return this.ConvertListDataSource(this.staffAppFormReqEntity.SchoolListDataSource(projectName, this.View.CurrentUserID, staffName));
        }
        /// <summary>
        /// 获取教育局职工申请列表数据。
        /// </summary>
        /// <param name="unitName"></param>
        /// <param name="projectName"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public DataTable EduListDataSource(string unitName, string projectName, string staffName)
        {
            return this.ConvertListDataSource(this.staffAppFormReqEntity.EduListDataSource(unitName, projectName, staffName));
        }
        /// <summary>
        /// 列表数据处理。
        /// </summary>
        /// <param name="dtSource"></param>
        /// <returns></returns>
        private DataTable ConvertListDataSource(DataTable dtSource)
        {
            if (dtSource != null)
            {
                dtSource.Columns.Add("GenderName", typeof(string));
                dtSource.Columns.Add("HardCategoryName", typeof(string));
                dtSource.Columns.Add("HardBecauseName", typeof(string));
                dtSource.Columns.Add("TheidentityName", typeof(string));
                dtSource.Columns.Add("MaritalstatusName", typeof(string));
                dtSource.Columns.Add("StatusName", typeof(string));
                foreach (DataRow row in dtSource.Rows)
                {
                    row["GenderName"] = this.GetEnumMemberName(typeof(EnumGender), int.Parse(string.Format("{0}",row["Gender"])));
                    row["HardCategoryName"] = this.GetEnumMemberName(typeof(EnumHardCategory), int.Parse(string.Format("{0}", row["HardCategory"])));
                    row["HardBecauseName"] = this.GetEnumMemberName(typeof(EnumHardBecause), int.Parse(string.Format("{0}", row["HardBecause"])));
                    row["TheidentityName"] = this.GetEnumMemberName(typeof(EnumTheidentity), int.Parse(string.Format("{0}", row["Theidentity"])));
                    row["MaritalstatusName"] = this.GetEnumMemberName(typeof(EnumMaritalStatus), int.Parse(string.Format("{0}", row["Maritalstatus"])));
                    row["StatusName"] = this.GetEnumMemberName(typeof(EnumReqAuditStatus), int.Parse(string.Format("{0}", row["Status"])));
                }
            }
            return dtSource;
        }
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="handler"></param>
        public abstract void LoadEntityData(EventHandler<EntityEventArgs<DSIStaffAppFormReq>> handler);
        /// <summary>
        /// 更新。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateEntityData(DSIStaffAppFormReq data)
        {
            if (data == null || string.IsNullOrEmpty(data.ProjectID) || string.IsNullOrEmpty(data.StaffID)) return false;
            DSIStaffAppFormReq source = new DSIStaffAppFormReq();
            source.ProjectID = data.ProjectID;
            source.StaffID = data.StaffID;
            if (this.staffAppFormReqEntity.LoadRecord(ref source))
            {
                if (data.Status > 0)
                {
                    this.View.ShowMessage("该申请已进入审核阶段不允许修改！");
                    return false;
                }
                data.CreateTime = source.CreateTime;
                data.CreateUserID = source.CreateUserID;
                data.CreateUserName = source.CreateUserName;
            }
            return this.staffAppFormReqEntity.UpdateRecord(data);
        }
        /// <summary>
        /// 批量删除。
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        public bool DeleteEntityData(StringCollection primaryValues)
        {
            if (primaryValues == null || primaryValues.Count == 0) return false;
            int count = 0;
            for (int i = 0; i < primaryValues.Count; i++)
            {
                string[] strs = primaryValues[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (strs != null && strs.Length == 2)
                {
                    DSIStaffAppFormReq data = new DSIStaffAppFormReq();
                    data.StaffID = strs[0];
                    data.ProjectID = strs[1];
                    if (this.staffAppFormReqEntity.LoadRecord(ref data))
                    {
                        if (data.Status != 0)
                        {
                            this.View.ShowMessage("不能删除，已审核！");
                            continue;
                        }
                        if (this.staffAppFormReqEntity.DeleteRecord(data)) { count++; }
                    }
                }
            }
            return count > 0;
        }
        /// <summary>
        /// 重新申请。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool StaffAppFormReReq(DSIStaffAppFormReq data)
        {
            if (data == null || string.IsNullOrEmpty(data.ProjectID) || string.IsNullOrEmpty(data.StaffID)) return false;
            DSIStaffAppFormReq source = new DSIStaffAppFormReq();
            source.ProjectID = data.ProjectID;
            source.StaffID = data.StaffID;
            if (this.staffAppFormReqEntity.LoadRecord(ref source))
            {
                if (data.Status > 0)
                {
                    this.View.ShowMessage("该申请已进入审核阶段不允许修改！");
                    return false;
                }
                return this.staffAppFormReqEntity.UpdateRecord(data);
            }
            return false;
        }
        #endregion
    }
}