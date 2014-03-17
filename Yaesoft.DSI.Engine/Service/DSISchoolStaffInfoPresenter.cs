//================================================================================
//  FileName: DSISchoolStaffInfoPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-9
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
using System.Collections.Specialized;
using System.Collections.Generic;
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
    /// 
    /// </summary>
    public interface IDSISchoolStaffInfoView : IModuleView
    {
        // <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IDSISchoolStaffInfoListView : IDSISchoolStaffInfoView
    {
        /// <summary>
        /// 
        /// </summary>
        string UnitName { get; }
        /// <summary>
        /// 获取教职工编号/姓名/身份证号。
        /// </summary>
        string StaffCodeNameCard { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IDSISchoolStaffInfoEditView : IDSISchoolStaffInfoView
    {
        /// <summary>
        /// 获取教职工ID。
        /// </summary>
        GUIDEx StaffID { get; }
    }	
    /// <summary>
    /// 学校教职工档案行为类。
    /// </summary>
    public class DSISchoolStaffInfoPresenter : ModulePresenter<IDSISchoolStaffInfoView>
    {
        #region 成员变量，构造函数。
        private DSIStaffInfoEntity staffInfoEntity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        public DSISchoolStaffInfoPresenter(IDSISchoolStaffInfoView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.School_StaffInfo_ModuleID;
            this.staffInfoEntity = new DSIStaffInfoEntity();
            this.staffInfoEntity.DbEntityDataChangeLogEvent += this.CreateCommonLog;
        }
        #endregion

        #region 数据操作函数。
        /// <summary>
        /// 列表数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IDSISchoolStaffInfoListView listView = this.View as IDSISchoolStaffInfoListView;
                if (listView != null)
                {
                    DataTable dtSource = this.staffInfoEntity.SchoolListDataSource(listView.CurrentUserID, listView.UnitName, listView.StaffCodeNameCard);
                    if (dtSource != null && dtSource.Rows.Count > 0)
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
                            row["HardCategoryName"] = this.GetEnumMemberName(typeof(EnumHardCategory), int.Parse(string.Format("{0}",row["HardCategory"])));
                            row["HealthStatusName"] = this.GetEnumMemberName(typeof(EnumHealthStatus), int.Parse(string.Format("{0}",row["HealthStatus"])));
                            row["HardBecauseName"] = this.GetEnumMemberName(typeof(EnumHardBecause), int.Parse(string.Format("{0}", row["HardBecause"])));
                            row["TheidentityName"] = this.GetEnumMemberName(typeof(EnumTheidentity), int.Parse(string.Format("{0}", row["Theidentity"])));
                            row["MaritalstatusName"] = this.GetEnumMemberName(typeof(EnumMaritalStatus), int.Parse(string.Format("{0}", row["Maritalstatus"])));
                        }
                        return dtSource;
                    }
                }
                return null;
            }
        }
        ///<summary>
        ///编辑页面加载数据。
        ///</summary>
        ///<param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<DSIStaffInfo>> handler)
        {
            IDSISchoolStaffInfoEditView editView = this.View as IDSISchoolStaffInfoEditView;
            if (editView != null && editView.StaffID.IsValid)
            {
                DSIStaffInfo data = new DSIStaffInfo();
                data.StaffID = editView.StaffID;
                if (this.staffInfoEntity.LoadRecord(ref data))
                {
                    //教职工信息。
                    handler(this, new EntityEventArgs<DSIStaffInfo>(data));
                }
            }
        }
        /// <summary>
        /// 批量删除教职工信息。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteEntityData(StringCollection priCollection)
        {
            try
            {
                return this.staffInfoEntity.DeleteRecord(priCollection);
            }
            catch (Exception e)
            {
                this.View.ShowMessage(e.Message);
            }
            return false;
        }
        #endregion
    }
}