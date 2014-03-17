//================================================================================
//  FileName: DSISchoolRptAllowancePresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-23
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
using System.Data;
using System.Collections.Generic;
using System.Text;

using Yaesoft.DSI.Engine.Persistence;
using iPower.Platform.Engine.DataSource;
namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDSISchoolRptAllowanceListView : IModuleView
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
        /// <param name="data"></param>
        void BindProjectYears(IListControlsData data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void BindProjects(IListControlsData data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="summarys"></param>
        void ShowSummary(object[] summarys);
    }
    /// <summary>
    /// 
    /// </summary>
    public class DSISchoolRptAllowancePresenter : ModulePresenter<IDSISchoolRptAllowanceListView>
    {
        #region 成员变量，构造函数。
        private DSIStaffAppFormReqEntity staffAppFormReqEntity;
        private DSIProjectEntity projectEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSISchoolRptAllowancePresenter(IDSISchoolRptAllowanceListView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.School_Rpt_Allowance_ModuleID;
            this.staffAppFormReqEntity = new DSIStaffAppFormReqEntity();
            this.projectEntity = new DSIProjectEntity();
        }
        #endregion

        #region 数据列表。
        /// <summary>
        /// 
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IDSISchoolRptAllowanceListView listView = this.View as IDSISchoolRptAllowanceListView;
                if (listView != null)
                {
                    int count = 0;
                    float money = 0;
                    DataTable dtSource = this.staffAppFormReqEntity.SchoolRptAllowance(listView.Year, listView.ProjectID, listView.CurrentUserID);
                    if (dtSource != null)
                    {
                        foreach (DataRow row in dtSource.Rows)
                        {
                            try
                            {
                                count += int.Parse(string.Format("{0}", row["Count"]));
                            }
                            catch (Exception) { }
                            try
                            {
                                money += int.Parse(string.Format("{0}", row["Money"]));
                            }
                            catch (Exception) { }
                        }
                    }
                    listView.ShowSummary(new object[] { count, money });
                    return dtSource;
                }
                return null;
            }
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            IDSISchoolRptAllowanceListView listView = this.View as IDSISchoolRptAllowanceListView;
            if (listView != null)
            {
                listView.BindProjectYears(this.projectEntity.BindAllProjectYears);
                listView.BindProjects(this.projectEntity.BindAllProjects());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        public void ProjectYearChanged()
        {
            IDSISchoolRptAllowanceListView listView = this.View as IDSISchoolRptAllowanceListView;
            if (listView != null)
            {
                listView.BindProjects(this.projectEntity.BindAllProjects(listView.Year));
            }
        }
        #endregion
    }
}