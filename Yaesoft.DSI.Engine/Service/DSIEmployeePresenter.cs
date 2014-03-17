//================================================================================
// FileName: DSIEmployeePresenter.cs
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
    /// IDSIEmployeeView接口。
    ///</summary>
    public interface IDSIEmployeeView : IModuleView
    {
        /// <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
        /// <summary>
        /// 获取用户名。
        /// </summary>
        string EmployeeName { get; }
    }
    /// <summary>
    /// 列表页面接口
    /// </summary>
    public interface IDSIEmployeeListView : IDSIEmployeeView
    {

    }
    /// <summary>
    /// Picker页面接口
    /// </summary>
    public interface IDSIEmployeePickerView : IDSIEmployeeView
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        GUIDEx EmployeeID { get; }
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="data"></param>
        void BindEmployees(IListControlsData data);
    }
    ///<summary>
    /// DSIEmployeePresenter行为类。
    ///</summary>
    public class DSIEmployeePresenter : ModulePresenter<IDSIEmployeeView>
    {
        #region 成员变量，构造函数。
        DSIEmployeeEntity employeeEntity = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public DSIEmployeePresenter(IDSIEmployeeView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.Employee_ModuleID;
            this.employeeEntity = new DSIEmployeeEntity();
        }
        #endregion

        #region 数据操作函数。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        public DataTable ListDataScuore
        {
            get
            {
                IDSIEmployeeListView listView = this.View as IDSIEmployeeListView;
                if (listView != null)
                {
                    return this.employeeEntity.ListDataSource(listView.EmployeeName);
                }
                return null;
            }

        }
        ///<summary>
        ///编辑页面加载数据。
        ///</summary>
        ///<param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<DSIEmployee>> handler)
        {
            IDSIEmployeePickerView pickerView = this.View as IDSIEmployeePickerView;
            if (pickerView != null && pickerView.EmployeeID.IsValid)
            {
                DSIEmployee data = new DSIEmployee();
                data.EmployeeID = pickerView.EmployeeID;
                if (this.employeeEntity.LoadRecord(ref data))
                {
                    handler(this, new EntityEventArgs<DSIEmployee>(data));
                }
            }
        }
        /// <summary>
        /// Picker搜索
        /// </summary>
        public void PickerSearch()
        {
            IDSIEmployeePickerView pickerView = this.View as IDSIEmployeePickerView;
            if (pickerView != null)
            {
                pickerView.BindEmployees(this.employeeEntity.BindPicker(pickerView.EmployeeName));
            }

        }
        #endregion
    }
}