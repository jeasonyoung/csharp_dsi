//================================================================================
//  FileName: DSISchoolStaffAllowancePresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-22
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
//================================================================================
//  FileName: DSISchoolStaffAllowancePresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-22
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

using Yaesoft.DSI.Engine.Persistence;
using iPower.Platform.Engine.DataSource;
namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 学校教职工补助视图。
    /// </summary>
    public interface IDSISchoolStaffAllowanceListView : IDSIStaffAllowanceView
    {
        /// <summary>
        /// 
        /// </summary>
        string Year { get; }
        /// <summary>
        /// 
        /// </summary>
        string ProjectID { get; }
        /// <summary>
        /// 
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
    /// 学校教职工补助行为类。
    /// </summary>
    public class DSISchoolStaffAllowancePresenter : DSIStaffAllowancePresenter
    {
        #region 成员变量，构造函数。
        private DSIProjectEntity projectEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSISchoolStaffAllowancePresenter(IDSISchoolStaffAllowanceListView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.School_Allowance_ModuleID;
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
            IDSISchoolStaffAllowanceListView listView = this.View as IDSISchoolStaffAllowanceListView;
            if (listView != null)
            {
                listView.BindProjectYears(this.projectEntity.BindAllProjectYears);
                listView.BindProjects(this.projectEntity.BindAllProjects());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ProjectYearChanged()
        {
            IDSISchoolStaffAllowanceListView listView = this.View as IDSISchoolStaffAllowanceListView;
            if (listView != null)
            {
                listView.BindProjects(this.projectEntity.BindAllProjects(listView.Year));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override DataTable ListDataSource
        {
            get
            {
                IDSISchoolStaffAllowanceListView listView = this.View as IDSISchoolStaffAllowanceListView;
                if (listView != null)
                {
                    return this.SchoolListDataSource(listView.Year, listView.ProjectID, listView.StaffName);
                }
                return null;
            }
        }
        #endregion
    }
}