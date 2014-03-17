//================================================================================
//  FileName: DSIEduRptStaffAllowancePresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-25
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
    /// 教育局按个人统计列表接口。
    /// </summary>
    public interface IDSIEduRptStaffAllowanceListView : IModuleView
    {
        /// <summary>
        /// 
        /// </summary>
        string UnitName { get; }
        /// <summary>
        /// 
        /// </summary>
        string StaffName { get; }
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
    /// 教育局按个人统计行为类。
    /// </summary>
    public class DSIEduRptStaffAllowancePresenter : ModulePresenter<IDSIEduRptStaffAllowanceListView>
    {
        #region 成员变量，构造函数。
        private DSIStaffAppFormReqEntity staffAppFormReqEntity;
        private DSIProjectEntity projectEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIEduRptStaffAllowancePresenter(IDSIEduRptStaffAllowanceListView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.Edu_Rpt_Staff_ModuleID;
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
                IDSIEduRptStaffAllowanceListView listView = this.View as IDSIEduRptStaffAllowanceListView;
                if (listView != null)
                {
                    int projectCount = 0;
                    float money = 0;
                    DataTable dtSource = this.staffAppFormReqEntity.EduRptStaffAllowance(listView.Year, listView.ProjectID, listView.UnitName, listView.StaffName);
                    if (dtSource != null)
                    {
                        dtSource.Columns.Add("GenderName", typeof(string));
                        dtSource.Columns.Add("HardCategoryName", typeof(string));
                        dtSource.Columns.Add("HealthStatusName", typeof(string));
                        dtSource.Columns.Add("HardBecauseName", typeof(string));
                        dtSource.Columns.Add("TheidentityName", typeof(string));
                        dtSource.Columns.Add("MaritalstatusName", typeof(string));
                        foreach (DataRow row in dtSource.Rows)
                        {
                            row["GenderName"] = this.GetEnumMemberName(typeof(EnumGender), int.Parse(string.Format("{0}", row["Gender"])));
                            row["HardCategoryName"] = this.GetEnumMemberName(typeof(EnumHardCategory), int.Parse(string.Format("{0}", row["HardCategory"])));
                           // row["HealthStatusName"] = this.GetEnumMemberName(typeof(EnumHealthStatus), int.Parse(string.Format("{0}", row["HealthStatus"])));
                            row["HardBecauseName"] = this.GetEnumMemberName(typeof(EnumHardBecause), int.Parse(string.Format("{0}", row["HardBecause"])));
                            row["TheidentityName"] = this.GetEnumMemberName(typeof(EnumTheidentity), int.Parse(string.Format("{0}", row["Theidentity"])));
                            row["MaritalstatusName"] = this.GetEnumMemberName(typeof(EnumMaritalStatus), int.Parse(string.Format("{0}", row["Maritalstatus"])));
                            try
                            {
                                projectCount += int.Parse(string.Format("{0}", row["ProjectCount"]));
                                money += int.Parse(string.Format("{0}", row["Money"]));
                            }
                            catch (Exception) { }
                        }
                    }
                    listView.ShowSummary(new object[] { projectCount, money });
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
            IDSIEduRptStaffAllowanceListView listView = this.View as IDSIEduRptStaffAllowanceListView;
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
            IDSIEduRptStaffAllowanceListView listView = this.View as IDSIEduRptStaffAllowanceListView;
            if (listView != null)
            {
                listView.BindProjects(this.projectEntity.BindAllProjects(listView.Year));
            }
        }
        #endregion
    }
}