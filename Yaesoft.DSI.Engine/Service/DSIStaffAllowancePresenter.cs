//================================================================================
//  FileName: DSIStaffAllowancePresenter.cs
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
    /// 教职工补助视图接口。
    /// </summary>
    public interface IDSIStaffAllowanceView : IModuleView
    {
        /// <summary>
        /// 错误消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
    /// <summary>
    /// 教职工补助行为类。
    /// </summary>
    public abstract class DSIStaffAllowancePresenter : ModulePresenter<IDSIStaffAllowanceView>
    {
        #region 成员变量，构造函数。
        private DSIStaffAppFormReqEntity staffAppFormReqEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIStaffAllowancePresenter(IDSIStaffAllowanceView view)
            : base(view)
        {
            this.staffAppFormReqEntity = new DSIStaffAppFormReqEntity();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public abstract DataTable ListDataSource { get; }

        #region 数据处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="projectId"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        protected DataTable SchoolListDataSource(string year, string projectId, string staffName)
        {
            DataTable dtSource = this.staffAppFormReqEntity.SchoolStaffAllowanceListDataSource(year, projectId, this.View.CurrentUserID, staffName);
            if (dtSource != null)
            {
                return this.ConvertListData(dtSource);
            }
            return dtSource;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="unitName"></param>
        /// <param name="projectId"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        protected DataTable EduListDataSource(string year, string unitName, string projectId, string staffName)
        {
            DataTable dtSource = this.staffAppFormReqEntity.EduStaffAllowanceListDataSource(year, unitName, projectId, staffName);
            if (dtSource != null)
            {
                return this.ConvertListData(dtSource);
            }
            return dtSource;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        protected DataTable EduRptAllowanceDetail(string unitId, string year)
        {
            DataTable dtSource = this.staffAppFormReqEntity.EduRptAllowanceDetail(unitId, year);
            if (dtSource != null)
            {
                return this.ConvertListData(dtSource);
            }
            return dtSource;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtSource"></param>
        /// <returns></returns>
        private DataTable ConvertListData(DataTable dtSource)
        {
            if (dtSource != null)
            {
                dtSource.Columns.Add("GenderName", typeof(string));
                dtSource.Columns.Add("HardCategoryName", typeof(string));
                dtSource.Columns.Add("HardBecauseName", typeof(string));
                dtSource.Columns.Add("TheidentityName", typeof(string));
                dtSource.Columns.Add("MaritalstatusName", typeof(string));
                foreach (DataRow row in dtSource.Rows)
                {
                    row["GenderName"] = this.GetEnumMemberName(typeof(EnumGender), int.Parse(string.Format("{0}", row["Gender"])));
                    row["HardCategoryName"] = this.GetEnumMemberName(typeof(EnumHardCategory), int.Parse(string.Format("{0}", row["HardCategory"])));
                    row["HardBecauseName"] = this.GetEnumMemberName(typeof(EnumHardBecause), int.Parse(string.Format("{0}", row["HardBecause"])));
                    row["TheidentityName"] = this.GetEnumMemberName(typeof(EnumTheidentity), int.Parse(string.Format("{0}", row["Theidentity"])));
                    row["MaritalstatusName"] = this.GetEnumMemberName(typeof(EnumMaritalStatus), int.Parse(string.Format("{0}", row["Maritalstatus"])));
                }
            }
            return dtSource;
        }
        #endregion
    }
}