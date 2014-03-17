//================================================================================
// FileName: DSIEmployeeUnitPresenter.cs
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
	/// IDSIEmployeeUnitView接口。
	///</summary>
	public interface IDSIEmployeeUnitView: IModuleView
	{
        /// <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// 列表界面接口
    /// </summary>
    public interface IDSIEmployeeUnitListView : IDSIEmployeeUnitView
    {
        /// <summary>
        /// 获取用户名。
        /// </summary>
        string EmployeeName { get; }
    }
    /// <summary>
    /// 编辑界面接口
    /// </summary>
    public interface IDSIEmployeeUnitEditView : IDSIEmployeeUnitView
    {
        /// <summary>
        /// 获取用户ID
        /// </summary>
        GUIDEx EmployeeID { get; }
        /// <summary>
        /// 绑定已授权单位。
        /// </summary>
        /// <param name="data"></param>
        void BindAuthorize(IListControlsData data);
        /// <summary>
        /// 绑定未授权单位。
        /// </summary>
        /// <param name="data"></param>
        void BindNonAuthorize(IListControlsData data);
    }
	///<summary>
	/// DSIEmployeeUnitPresenter行为类。
	///</summary>
	public class DSIEmployeeUnitPresenter: ModulePresenter<IDSIEmployeeUnitView>
	{
		#region 成员变量，构造函数。
        DSIEmployeeUnitEntity employeeUnitEntity = null;
        DSIEmployeeEntity employeeEntity = null;
		///<summary>
		///构造函数。
		///</summary>
        public DSIEmployeeUnitPresenter(IDSIEmployeeUnitView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.EmployeeUnit_ModuleID;

            this.employeeEntity = new DSIEmployeeEntity();
            this.employeeUnitEntity = new DSIEmployeeUnitEntity();
            this.employeeUnitEntity.DbEntityDataChangeLogEvent += this.CreateCommonLog;
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
                IDSIEmployeeUnitListView listView = this.View as IDSIEmployeeUnitListView;
                if (listView != null)
                {
                    return this.employeeUnitEntity.ListDataSource(listView.EmployeeName);
                }
                return null;
            }
        }
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<DSIEmployee>> handler)
        {
            IDSIEmployeeUnitEditView editView = this.View as IDSIEmployeeUnitEditView;
            if (editView != null && editView.EmployeeID.IsValid && handler != null)
            {
                DSIEmployee data = new DSIEmployee();
                data.EmployeeID = editView.EmployeeID;
                if (this.employeeEntity.LoadRecord(ref data))
                    handler(this, new EntityEventArgs<DSIEmployee>(data));
            }
        }
        /// <summary>
        /// 根据用户单位数据。
        /// </summary>
        /// <param name="unitIDs"></param>
        /// <returns></returns>
        public bool UpdateEntityData(string[] unitIDs)
        {
            bool result = false;
            IDSIEmployeeUnitEditView editView = this.View as IDSIEmployeeUnitEditView;
            if (editView != null && editView.EmployeeID.IsValid)
            {
                result = this.employeeUnitEntity.UpdateRecord(editView.EmployeeID, unitIDs);
            }
            return result;
        }
        /// <summary>
        /// 检索授权数据。
        /// </summary>
        public void QueryAuthorize()
        {
            IDSIEmployeeUnitEditView editView = this.View as IDSIEmployeeUnitEditView;
            if (editView != null && editView.EmployeeID.IsValid)
            {
                editView.BindAuthorize(this.employeeUnitEntity.BindAuthorize(editView.EmployeeID));
                editView.BindNonAuthorize(this.employeeUnitEntity.BindNonAuthorize(editView.EmployeeID));
            }
        }
        #endregion
	}
}