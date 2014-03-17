//================================================================================
//  FileName: DSIEduStaffAppFormReqPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-15
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
    /// 申报全区教职工补助视图接口。
    /// </summary>
    public interface IDSIEduStaffAppFormReqView : IDSIStaffAppFormReqView
    {

    }
    /// <summary>
    /// 申报全区教职工补助视图列表接口。
    /// </summary>
    public interface IDSIEduStaffAppFormReqListView : IDSIEduStaffAppFormReqView
    {
        // <summary>
        /// 获取项目名称。
        /// </summary>
        string ProjectName { get; }
        /// <summary>
        /// 获取所属单位名称。
        /// </summary>
        string UnitName { get; }
        /// <summary>
        /// 获取职工名称。
        /// </summary>
        string StaffName { get; }
    }
    /// <summary>
    /// 申报全区教职工补助视图编辑接口。
    /// </summary>
    public interface IDSIEduStaffAppFormReqEditView : IDSIEduStaffAppFormReqView
    {
        /// <summary>
        /// 绑定项目。
        /// </summary>
        /// <param name="data"></param>
        void BindProjects(IListControlsData data);
        /// <summary>
        /// 设置选定项目。
        /// </summary>
        /// <param name="projectID"></param>
        void SetProject(string projectID);
        /// <summary>
        /// 设置选定职工。
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="staffName"></param>
        void SetStaff(string staffID, string staffName);
        /// <summary>
        /// 获取职工ID。
        /// </summary>
        GUIDEx StaffID { get; }
        /// <summary>
        /// 获取项目ID。
        /// </summary>
        GUIDEx ProjectID { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class DSIEduStaffAppFormReqPresenter : DSIStaffAppFormReqPresenter
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIEduStaffAppFormReqPresenter(IDSIEduStaffAppFormReqView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.Edu_StaffReq_ModuleID;
        }
        #endregion

        #region 数据处理。
        /// <summary>
        /// 获取列表数据。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IDSIEduStaffAppFormReqListView listView = this.View as IDSIEduStaffAppFormReqListView;
                if (listView != null)
                {
                    return this.EduListDataSource(listView.UnitName, listView.ProjectName, listView.StaffName);
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
            IDSIEduStaffAppFormReqEditView editView = this.View as IDSIEduStaffAppFormReqEditView;
            if (editView != null)
            {
                if (editView.ProjectID.IsValid)
                    editView.BindProjects(new DSIProjectEntity().BindAllProjects());
                else
                    editView.BindProjects(new DSIProjectEntity().BindProjects);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        public override void LoadEntityData(EventHandler<EntityEventArgs<DSIStaffAppFormReq>> handler)
        {
            IDSIEduStaffAppFormReqEditView editView = this.View as IDSIEduStaffAppFormReqEditView;
            if (editView != null && editView.ProjectID.IsValid && editView.StaffID.IsValid)
            {
                DSIStaffAppFormReq data = new DSIStaffAppFormReq();
                data.StaffID = editView.StaffID;
                data.ProjectID = editView.ProjectID;
                if (this.LoadStaffAppFormReq(ref data))
                {
                    editView.SetProject(data.ProjectID);
                    editView.SetStaff(data.Staff.StaffID, data.Staff.StaffName);
                    handler(this, new EntityEventArgs<DSIStaffAppFormReq>(data));
                }
            }
        }
        #endregion
    }
}