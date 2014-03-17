//================================================================================
//  FileName: DSIEduRptAllowancePresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-24
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
    /// 按补助标准统计列表视图接口。
    /// </summary>
    public interface IDSIEduRptAllowanceListView : IModuleView
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
    /// 按补助标准统计行为类。
    /// </summary>
    public class DSIEduRptAllowancePresenter : ModulePresenter<IDSIEduRptAllowanceListView>
    {
        #region 成员变量，构造函数。
        private DSIStaffAppFormReqEntity staffAppFormReqEntity;
        private DSIProjectEntity projectEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIEduRptAllowancePresenter(IDSIEduRptAllowanceListView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.Edu_Rpt_Allowance_ModuleID;
            this.staffAppFormReqEntity = new DSIStaffAppFormReqEntity();
            this.projectEntity = new DSIProjectEntity();
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IDSIEduRptAllowanceListView listView = this.View as IDSIEduRptAllowanceListView;
                if (listView != null)
                {
                    int projectCount = 0, unitCount = 0, count = 0;
                    DataTable dtSource = this.staffAppFormReqEntity.EduRptAllowance(listView.Year, listView.ProjectID);
                    if (dtSource != null)
                    {
                        foreach (DataRow row in dtSource.Rows)
                        {
                            try
                            {
                                projectCount += int.Parse(string.Format("{0}", row["ProjectCount"]));
                            }
                            catch (Exception) { }
                            try
                            {
                                unitCount += int.Parse(string.Format("{0}", row["UnitCount"]));
                            }
                            catch (Exception) { }
                            try
                            {
                                count += int.Parse(string.Format("{0}", row["Count"]));
                            }
                            catch (Exception) { }
                        }
                    }
                    listView.ShowSummary(new object[] { projectCount, unitCount, count });
                    return dtSource;
                }
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            IDSIEduRptAllowanceListView listView = this.View as IDSIEduRptAllowanceListView;
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
            IDSIEduRptAllowanceListView listView = this.View as IDSIEduRptAllowanceListView;
            if (listView != null)
            {
                listView.BindProjects(this.projectEntity.BindAllProjects(listView.Year));
            }
        }
        #endregion
    }
}