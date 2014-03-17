//================================================================================
// FileName: DSIEduAuditResultPresenter.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
using iPower.Platform.Engine.DataSource;
namespace Yaesoft.DSI.Engine.Service
{
    ///<summary>
    /// 教育局审批申报补助视图接口。
    ///</summary>
    public interface IDSIEduAuditView : IDSIAuditView
    {

    }
    /// <summary>
    /// 教育局审批申报补助列表视图接口。
    /// </summary>
    public interface IDSIEduAuditListView : IDSIEduAuditView
    {
        /// <summary>
        /// 
        /// </summary>
        string Year { get; }
        // <summary>
        /// 获取项目名称。
        /// </summary>
        string ProjectID { get; }
        /// <summary>
        /// 获取所属单位名称。
        /// </summary>
        string UnitName { get; }
        /// <summary>
        /// 获取职工名称。
        /// </summary>
        string StaffName { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void BindProjectYears(IListControlsData data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void BindProjects(IListControlsData data);
    }
    /// <summary>
    /// 教育局审批申报补助编辑视图接口。
    /// </summary>
    public interface IDSIEduAuditEditView : IDSIEduAuditView, IDSIAuditEditView
    {
    }
    ///<summary>
    /// 教育局审批申报补助行为类。
    ///</summary>
    public class DSIEduAuditPresenter : DSIAuditPresenter
    {
        #region 成员变量，构造函数。
        private DSIProjectEntity projectEntity;
        ///<summary>
        ///构造函数。
        ///</summary>
        public DSIEduAuditPresenter(IDSIEduAuditView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.Edu_Audit_ModuleID;
            this.projectEntity = new DSIProjectEntity();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            IDSIEduAuditListView listView = this.View as IDSIEduAuditListView;
            if (listView != null)
            {
                listView.BindProjectYears(this.projectEntity.BindAllProjectYears);
                listView.BindProjects(this.projectEntity.BindAllProjects());
            }
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 列表数据
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IDSIEduAuditListView listView = this.View as IDSIEduAuditListView;
                if (listView != null)
                {
                    return this.EduAuditListDataSource(listView.Year, listView.UnitName, listView.ProjectID, listView.StaffName);
                }
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ProjectYearChanged()
        {
            IDSIEduAuditListView listView = this.View as IDSIEduAuditListView;
            if (listView != null)
            {
                listView.BindProjects(this.projectEntity.BindAllProjects(listView.Year));
            }
        }
        /// <summary>
        /// 终审。
        /// </summary>
        /// <param name="committeeAllowance"></param>
        /// <param name="leadershipAllowance"></param>
        /// <param name="finalAllowance"></param>
        /// <param name="auditStatus"></param>
        /// <returns></returns>
        public bool Audit(float committeeAllowance,float leadershipAllowance,float finalAllowance, int auditStatus)
        {
            IDSIEduAuditEditView editView = this.View as IDSIEduAuditEditView;
            if (editView != null)
            {
                if (auditStatus > (int)EnumReqAuditStatus.None && auditStatus < (int)EnumReqAuditStatus.Final)
                {
                    editView.ShowMessage("审核状态错误！");
                    return false;
                }
                DSIStaffAppFormReq data = new DSIStaffAppFormReq();
                data.StaffID = editView.StaffID;
                data.ProjectID = editView.ProjectID;
                data.CommitteeAllowance = committeeAllowance;
                data.LeadershipAllowance = leadershipAllowance;
                data.FinalAllowance = finalAllowance;
                data.Status = auditStatus;

                return this.EduAudit(data);
            }
            return false;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="auditStauts"></param>
        /// <returns></returns>
        protected override string ConvertColumnAuditName(int auditStauts)
        {
            if (auditStauts < (int)EnumReqAuditStatus.Primary) return string.Empty;
            if (auditStauts == (int)EnumReqAuditStatus.Primary) return "审批";
            if (auditStauts < (int)EnumReqAuditStatus.Payee) return "反审批";
            return string.Empty;
        }
        #endregion
    }
}