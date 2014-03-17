//================================================================================
//  FileName: DSIEduRptTimeAllowancePresenter.cs
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
namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 按时间段统计列表视图接口。
    /// </summary>
    public interface IDSIEduRptTimeAllowanceListView : IModuleView
    {
        /// <summary>
        /// 
        /// </summary>
        string ProjectName { get; }
        /// <summary>
        /// 
        /// </summary>
        DateTime StartTime { get; }
        /// <summary>
        /// 
        /// </summary>
        DateTime EndTime { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="summarys"></param>
        void ShowSummary(object[] summarys);
    }
    /// <summary>
    /// 按时间段统计行为类。
    /// </summary>
    public class DSIEduRptTimeAllowancePresenter : ModulePresenter<IDSIEduRptTimeAllowanceListView>
    {
        #region 成员变量，构造函数。
        private DSIStaffAppFormReqEntity staffAppFormReqEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIEduRptTimeAllowancePresenter(IDSIEduRptTimeAllowanceListView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.Edu_Rpt_TimeAllowance_ModuleID;
            this.staffAppFormReqEntity = new DSIStaffAppFormReqEntity();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IDSIEduRptTimeAllowanceListView listView = this.View as IDSIEduRptTimeAllowanceListView;
                if (listView != null)
                {
                    int projectCount = 0, unitCount = 0, count = 0;
                    float money = 0;
                    DataTable dtSource = this.staffAppFormReqEntity.EduRptTimeAllowance(listView.ProjectName, listView.StartTime, listView.EndTime);
                    if (dtSource != null)
                    {
                        projectCount = dtSource.Rows.Count;
                        foreach (DataRow row in dtSource.Rows)
                        {
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
                            try
                            {
                                money += int.Parse(string.Format("{0}", row["Money"]));
                            }
                            catch (Exception) { }
                        }
                    }
                    listView.ShowSummary(new object[] { projectCount, unitCount, count, money });
                    return dtSource;
                }
                return null;
            }
        }
    }
}