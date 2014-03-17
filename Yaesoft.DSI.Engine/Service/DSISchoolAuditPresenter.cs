//================================================================================
//  FileName: DSISchoolAuditPresenter.cs
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
using System.Text;
using System.Data;

using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 学校审批申报补助视图接口。
    /// </summary>
    public interface IDSISchoolAuditView : IDSIAuditView
    {
    }
    /// <summary>
    /// 学校审批申报补助列表视图接口。
    /// </summary>
    public interface IDSISchoolAuditListView : IDSISchoolAuditView
    {
        // <summary>
        /// 获取项目名称。
        /// </summary>
        string ProjectName { get; }
        /// <summary>
        /// 获取职工名称。
        /// </summary>
        string StaffName { get; }
    }
    /// <summary>
    /// 学校审批申报补助编辑视图接口。
    /// </summary>
    public interface IDSISchoolAuditEditView : IDSISchoolAuditView, IDSIAuditEditView
    {
    }
    /// <summary>
    /// 学校审核教职工申报补助审批行为类。
    /// </summary>
    public class DSISchoolAuditPresenter : DSIAuditPresenter
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSISchoolAuditPresenter(IDSISchoolAuditView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.School_Audit_ModuleID;
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
                IDSISchoolAuditListView listView = this.View as IDSISchoolAuditListView;
                if (listView != null)
                {
                    return this.SchoolAuditListDataSource(listView.ProjectName, listView.StaffName);
                }
                return null;
            }
        }
        /// <summary>
        /// 初级审核。
        /// </summary>
        /// <param name="primaryAllowance"></param>
        /// <param name="auditStatus"></param>
        /// <returns></returns>
        public bool Audit(float primaryAllowance, int auditStatus)
        {
            IDSISchoolAuditEditView editView = this.View as IDSISchoolAuditEditView;
            if (editView != null)
            {
                if (auditStatus > (int)EnumReqAuditStatus.Primary)
                {
                    editView.ShowMessage("审核状态错误！");
                    return false;
                }
                DSIStaffAppFormReq data = new DSIStaffAppFormReq();
                data.StaffID = editView.StaffID;
                data.ProjectID = editView.ProjectID;
                data.PrimaryAllowance = primaryAllowance;
                data.PrimaryAudit = editView.CurrentUserName;
                data.PrimaryAuditTime = DateTime.Now;
                data.Status = auditStatus;

                return this.SchoolAudit(data);
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
            if (auditStauts < (int)EnumReqAuditStatus.None) return string.Empty;
            if (auditStauts == (int)EnumReqAuditStatus.None) return "审批";
            if (auditStauts < (int)EnumReqAuditStatus.Final) return "反审批";
            return string.Empty;
        }
        #endregion
    }
}