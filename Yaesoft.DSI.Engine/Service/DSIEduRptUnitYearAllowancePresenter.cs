//================================================================================
//  FileName: DSIEduRptUnitYearAllowancePresenter.cs
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
    /// 按单位年度统计列表视图接口。
    /// </summary>
    public interface IDSIEduRptUnitYearAllowanceListView : IModuleView
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
        string UnitName { get; }
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
    /// 按单位年度统计行为类。
    /// </summary>
    public class DSIEduRptUnitYearAllowancePresenter : ModulePresenter<IDSIEduRptUnitYearAllowanceListView>
    {
        #region 成员变量，构造函数。
        private DSIStaffAppFormReqEntity staffAppFormReqEntity;
        private DSIProjectEntity projectEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIEduRptUnitYearAllowancePresenter(IDSIEduRptUnitYearAllowanceListView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.Edu_Rpt_UnitYearAllowance_ModuleID;
            this.staffAppFormReqEntity = new DSIStaffAppFormReqEntity();
            this.projectEntity = new DSIProjectEntity();
        }
        #endregion

        #region 数据处理。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            IDSIEduRptUnitYearAllowanceListView listView = this.View as IDSIEduRptUnitYearAllowanceListView;
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
            IDSIEduRptUnitYearAllowanceListView listView = this.View as IDSIEduRptUnitYearAllowanceListView;
            if (listView != null)
            {
                listView.BindProjects(this.projectEntity.BindAllProjects(listView.Year));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IDSIEduRptUnitYearAllowanceListView listView = this.View as IDSIEduRptUnitYearAllowanceListView;
                if (listView != null)
                {
                    int count = 0;
                    float money = 0;
                    DataTable dtSource = this.staffAppFormReqEntity.EduRptUnitYearAllowance(listView.Year, listView.ProjectID, listView.UnitName);
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
    }
}