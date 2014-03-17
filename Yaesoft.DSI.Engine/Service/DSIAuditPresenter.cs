//================================================================================
//  FileName: DSIStaffAppFormReqAuditPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-18
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
    /// 审批申报补助视图接口。
    /// </summary>
    public interface IDSIAuditView : IModuleView
    {
        /// <summary>
        /// 错误消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
    /// <summary>
    /// 审批申报补助编辑视图接口。
    /// </summary>
    public interface IDSIAuditEditView : IDSIAuditView
    {
        /// <summary>
        /// 获取教职工ID。
        /// </summary>
        GUIDEx StaffID { get; }
        /// <summary>
        /// 获取项目ID。
        /// </summary>
        GUIDEx ProjectID { get; }
    }
    /// <summary>
    /// 教职工申报补助审批行为类。
    /// </summary>
    public abstract class DSIAuditPresenter : ModulePresenter<IDSIAuditView>
    {
        #region 成员变量，构造函数。
        private DSIStaffAppFormReqEntity staffAppFormReqEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIAuditPresenter(IDSIAuditView view)
            : base(view)
        {
            this.staffAppFormReqEntity = new DSIStaffAppFormReqEntity();
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 获取学校教职工申报列表数据。
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public DataTable SchoolAuditListDataSource(string projectName, string staffName)
        {
            return this.ConvertListDataSource(this.staffAppFormReqEntity.SchoolAuditListDataSource(projectName, this.View.CurrentUserID, staffName));
        }
        /// <summary>
        /// 获取教育局教职工申报列表数据。
        /// </summary>
        /// <param name="year"></param>
        /// <param name="unitName"></param>
        /// <param name="projectID"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public DataTable EduAuditListDataSource(string year, string unitName, string projectID, string staffName)
        {
            return this.ConvertListDataSource(this.staffAppFormReqEntity.EduAuditListDataSource(year, unitName, projectID, staffName));
        }
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<DSIStaffAppFormReq>> handler)
        {
            IDSIAuditEditView editView = this.View as IDSIAuditEditView;
            if (editView != null && !string.IsNullOrEmpty(editView.StaffID) && !string.IsNullOrEmpty(editView.ProjectID))
            {
                DSIStaffAppFormReq data = new DSIStaffAppFormReq();
                data.StaffID = editView.StaffID;
                data.ProjectID = editView.ProjectID;
                if (this.staffAppFormReqEntity.LoadRecord(ref data))
                    handler(this, new EntityEventArgs<DSIStaffAppFormReq>(data));
            }
        }
         /// <summary>
        /// 学校审核申报。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected bool SchoolAudit(DSIStaffAppFormReq data)
        {
            if (data == null) return false;
            return this.staffAppFormReqEntity.SchoolAudit(data);
        }
        /// <summary>
        /// 教育局审核申报。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected bool EduAudit(DSIStaffAppFormReq data)
        {
            if (data == null) return false;
            return this.staffAppFormReqEntity.EduAudit(data);
        }
        #endregion

        #region 辅助函数。
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
                dtSource.Columns.Add("AuditName", typeof(string));
                foreach (DataRow row in dtSource.Rows)
                {
                    row["GenderName"] = this.GetEnumMemberName(typeof(EnumGender), int.Parse(string.Format("{0}", row["Gender"])));
                    row["HardCategoryName"] = this.GetEnumMemberName(typeof(EnumHardCategory), int.Parse(string.Format("{0}", row["HardCategory"])));
                    row["HardBecauseName"] = this.GetEnumMemberName(typeof(EnumHardBecause), int.Parse(string.Format("{0}", row["HardBecause"])));
                    row["TheidentityName"] = this.GetEnumMemberName(typeof(EnumTheidentity), int.Parse(string.Format("{0}", row["Theidentity"])));
                    row["MaritalstatusName"] = this.GetEnumMemberName(typeof(EnumTheidentity), int.Parse(string.Format("{0}", row["Maritalstatus"])));
                    row["StatusName"] = this.GetEnumMemberName(typeof(EnumReqAuditStatus), int.Parse(string.Format("{0}", row["Status"])));
                    row["AuditName"] = this.ConvertColumnAuditName(int.Parse(string.Format("{0}", row["Status"])));
                }
            }
            return dtSource;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="auditStauts"></param>
        /// <returns></returns>
        protected abstract string ConvertColumnAuditName(int auditStauts);
        #endregion
    }
}