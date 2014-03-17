//================================================================================
//  FileName: DSIPublicityStaffRequestPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-2-13
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
    /// 公示职工申报视图。
    /// </summary>
    public interface IDSIPublicityStaffRequestListView : IModuleView
    {
        /// <summary>
        /// 获取项目名称。
        /// </summary>
        string ProjectName { get; }
        /// <summary>
        /// 获取职工名称。
        /// </summary>
        string StaffName { get; }
    }
    /// <summary>
    /// 公示职工申报行为类。
    /// </summary>
    public class DSIPublicityStaffRequestPresenter : ModulePresenter<IDSIPublicityStaffRequestListView>
    {
        #region 成员变量，构造函数。
        private DSIStaffAppFormReqEntity staffAppFormReqEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIPublicityStaffRequestPresenter(IDSIPublicityStaffRequestListView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.PublicityStaffRequest_ModuleID;
            this.staffAppFormReqEntity = new DSIStaffAppFormReqEntity();
        }
        #endregion

        /// <summary>
        /// 获取数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IDSIPublicityStaffRequestListView listView = this.View as IDSIPublicityStaffRequestListView;
                if (listView != null)
                {
                    DataTable dtSource = this.staffAppFormReqEntity.PublicityStaffRequestDataSource(listView.ProjectName, listView.StaffName, listView.CurrentUserID);
                    if (dtSource != null)
                    {
                        dtSource.Columns.Add("GenderName", typeof(string));
                        dtSource.Columns.Add("HardCategoryName", typeof(string));
                        dtSource.Columns.Add("HardBecauseName", typeof(string));
                        dtSource.Columns.Add("TheidentityName", typeof(string));
                        dtSource.Columns.Add("MaritalstatusName", typeof(string));
                        dtSource.Columns.Add("StatusName", typeof(string));
                        foreach (DataRow row in dtSource.Rows)
                        {
                            row["GenderName"] = this.GetEnumMemberName(typeof(EnumGender), int.Parse(string.Format("{0}", row["Gender"])));
                            row["HardCategoryName"] = this.GetEnumMemberName(typeof(EnumHardCategory), int.Parse(string.Format("{0}", row["HardCategory"])));
                            row["HardBecauseName"] = this.GetEnumMemberName(typeof(EnumHardBecause), int.Parse(string.Format("{0}", row["HardBecause"])));
                            row["TheidentityName"] = this.GetEnumMemberName(typeof(EnumTheidentity), int.Parse(string.Format("{0}", row["Theidentity"])));
                            row["MaritalstatusName"] = this.GetEnumMemberName(typeof(EnumMaritalStatus), int.Parse(string.Format("{0}", row["Maritalstatus"])));
                            row["StatusName"] = this.GetEnumMemberName(typeof(EnumReqAuditStatus), int.Parse(string.Format("{0}", row["Status"])));
                        }
                    }
                    return dtSource;
                }
                return null;
            }
        }
    }
}