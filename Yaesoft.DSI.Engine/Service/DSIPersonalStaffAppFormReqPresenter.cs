//================================================================================
//  FileName: DSIStaffAppFormReqPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-12
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
    /// 职工申请补助视图接口。
    /// </summary>
    public interface IDSIPersonalStaffAppFormReqView : IDSIStaffAppFormReqView
    {
    }
    /// <summary>
    /// 职工申请补助列表视图接口。
    /// </summary>
    public interface IDSIPersonalStaffAppFormReqListView : IDSIPersonalStaffAppFormReqView
    {
        /// <summary>
        /// 获取项目名称。
        /// </summary>
        string ProjectName { get; }
    }
    /// <summary>
    /// 职工申请补助列表视图接口。
    /// </summary>
    public interface IDSIPersonalStaffAppFormReqEditView : IDSIPersonalStaffAppFormReqView
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
        /// 获取职工ID。
        /// </summary>
        GUIDEx StaffID { get; }
        /// <summary>
        /// 获取项目ID。
        /// </summary>
        GUIDEx ProjectID { get; }
    }
    /// <summary>
    ///  职工申请补助行为类。
    /// </summary>
    public class DSIPersonalStaffAppFormReqPresenter : DSIStaffAppFormReqPresenter
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIPersonalStaffAppFormReqPresenter(IDSIPersonalStaffAppFormReqView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.PersonalStaffReq_ModuleID;
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            IDSIPersonalStaffAppFormReqEditView editView = this.View as IDSIPersonalStaffAppFormReqEditView;
            if (editView != null)
            {
                if (editView.ProjectID.IsValid)
                    editView.BindProjects(new DSIProjectEntity().BindAllProjects());
                else
                    editView.BindProjects(new DSIProjectEntity().BindProjects);
            }
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IDSIPersonalStaffAppFormReqListView listView = this.View as IDSIPersonalStaffAppFormReqListView;
                if (listView != null)
                {
                    return this.PersonalListDataSource(listView.ProjectName);
                }
                return null;
            }
        }
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="handler"></param>
        public override void LoadEntityData(EventHandler<EntityEventArgs<DSIStaffAppFormReq>> handler)
        {
            IDSIPersonalStaffAppFormReqEditView editView = this.View as IDSIPersonalStaffAppFormReqEditView;
            if (editView != null)
            {
                DSIStaffAppFormReq data = new DSIStaffAppFormReq();
                if (editView.ProjectID.IsValid && editView.StaffID.IsValid)
                {
                    data.StaffID = editView.StaffID;
                    data.ProjectID = editView.ProjectID;
                    
                    if (this.LoadStaffAppFormReq(ref data))
                    {
                        editView.SetProject(data.ProjectID);
                        handler(this, new EntityEventArgs<DSIStaffAppFormReq>(data));
                        return;
                    }
                }
                data.Staff = this.LoadStaffByUserId(editView.CurrentUserID);
                handler(this, new EntityEventArgs<DSIStaffAppFormReq>(data));
            }
        }
        #endregion
    }
}