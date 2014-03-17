//================================================================================
// FileName: DSIStaffInfoPresenter.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
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
	///<summary>
	/// IDSIStaffInfoView接口。
	///</summary>
    public interface IDSIEduStaffInfoView : IModuleView
	{
        /// <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// 教育局困难教职工档案列表界面接口。
    /// </summary>
    public interface IDSIEduStaffInfoListView : IDSIEduStaffInfoView
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
    /// 困难教职工档案编辑界面接口。
    /// </summary>
    public interface IDSIEduStaffInfoEditView : IDSIEduStaffInfoView
    {
        /// <summary>
        /// 获取教职工ID。
        /// </summary>
        GUIDEx StaffID { get; }
    }	
	///<summary>
	/// DSIStaffInfoPresenter行为类。
	///</summary>
    public class DSIEduStaffInfoPresenter : ModulePresenter<IDSIEduStaffInfoView>
	{
		#region 成员变量，构造函数。
        private DSIStaffInfoEntity staffInfoEntity;
		///<summary>
		///构造函数。
		///</summary>
        public DSIEduStaffInfoPresenter(IDSIEduStaffInfoView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.Edu_StaffInfo_ModuleID;

            this.staffInfoEntity = new DSIStaffInfoEntity();
            this.staffInfoEntity.DbEntityDataChangeLogEvent += this.CreateCommonLog;
        }
		#endregion

        #region 数据操作函数。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IDSIEduStaffInfoListView listView = this.View as IDSIEduStaffInfoListView;
                if (listView != null)
                {
                    DataTable dtSource = this.staffInfoEntity.EduListDataSource(listView.UnitName, listView.StaffCodeNameCard);
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
                            row["GenderName"] = this.GetEnumMemberName(typeof(EnumGender), int.Parse(string.Format("{0}",row["Gender"])));
                            row["HardCategoryName"] = this.GetEnumMemberName(typeof(EnumHardCategory), int.Parse(string.Format("{0}", row["HardCategory"])));
                            row["HealthStatusName"] = this.GetEnumMemberName(typeof(EnumHealthStatus), int.Parse(string.Format("{0}", row["HealthStatus"])));
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
            IDSIEduStaffInfoEditView editView = this.View as IDSIEduStaffInfoEditView;
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