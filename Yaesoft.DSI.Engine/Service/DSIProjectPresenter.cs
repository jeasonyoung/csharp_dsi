//================================================================================
//  FileName: DSIProjectPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-11
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
    /// 申请项目视图接口。
    /// </summary>
    public interface IDSIProjectView : IModuleView
    {
        /// <summary>
        /// 错误消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
    /// <summary>
    /// 申请项目列表接口。
    /// </summary>
    public interface IDSIProjectListView : IDSIProjectView
    {
        /// <summary>
        /// 项目名称。
        /// </summary>
        string ProjectName { get; }
    }
    /// <summary>
    /// 申请项目编辑接口。
    /// </summary>
    public interface IDSIProjectEditView : IDSIProjectView
    {
        /// <summary>
        /// 获取项目ID。
        /// </summary>
        GUIDEx ProjectID { get; }
    }
    /// <summary>
    /// 申请项目行为类。
    /// </summary>
    public class DSIProjectPresenter : ModulePresenter<IDSIProjectView>
    {
        #region 成员变量，构造函数。
        private DSIProjectEntity projectEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIProjectPresenter(IDSIProjectView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.Edu_Project_ModuleID;
            this.projectEntity = new DSIProjectEntity();
        }
        #endregion

        #region 列表数据。
        /// <summary>
        /// 列表数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IDSIProjectListView listView = this.View as IDSIProjectListView;
                if (listView != null)
                {
                    DataTable dtSource = this.projectEntity.ListDataSource(listView.ProjectName);
                    if (dtSource != null)
                    {
                        dtSource.Columns.Add("IsViewName", typeof(string));
                        foreach (DataRow row in dtSource.Rows)
                        {
                            try
                            {
                                int v = int.Parse(string.Format("{0}", row["IsView"]));
                                row["IsViewName"] = (v == 1 ? "是" : "否");
                            }
                            catch (Exception) { }
                        }
                    }
                    return dtSource;
                }
                return null;
            }
        }
        #endregion

        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<DSIProject>> handler)
        {
            IDSIProjectEditView editView = this.View as IDSIProjectEditView;
            if (editView != null && editView.ProjectID.IsValid)
            {
                DSIProject data = new DSIProject();
                data.ProjectID = editView.ProjectID;
                if (this.projectEntity.LoadRecord(ref data))
                    handler(this, new EntityEventArgs<DSIProject>(data));
            }
        }
        /// <summary>
        /// 更新。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateEntityData(DSIProject data, StringCollection delAttachments)
        {
            return this.projectEntity.UpdateRecord(data, delAttachments);
        }
        /// <summary>
        /// 批量删除。
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        public bool DeleteEntityData(StringCollection primaryValues)
        {
            return this.projectEntity.DeleteRecord(primaryValues);
        }
    }
}