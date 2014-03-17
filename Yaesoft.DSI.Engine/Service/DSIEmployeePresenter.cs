//================================================================================
// FileName: DSIEmployeePresenter.cs
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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
    /// IDSIEmployeeView�ӿڡ�
    ///</summary>
    public interface IDSIEmployeeView : IModuleView
    {
        /// <summary>
        /// ��ʾ��Ϣ��
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
        /// <summary>
        /// ��ȡ�û�����
        /// </summary>
        string EmployeeName { get; }
    }
    /// <summary>
    /// �б�ҳ��ӿ�
    /// </summary>
    public interface IDSIEmployeeListView : IDSIEmployeeView
    {

    }
    /// <summary>
    /// Pickerҳ��ӿ�
    /// </summary>
    public interface IDSIEmployeePickerView : IDSIEmployeeView
    {
        /// <summary>
        /// �û�ID
        /// </summary>
        GUIDEx EmployeeID { get; }
        /// <summary>
        /// ���ݰ�
        /// </summary>
        /// <param name="data"></param>
        void BindEmployees(IListControlsData data);
    }
    ///<summary>
    /// DSIEmployeePresenter��Ϊ�ࡣ
    ///</summary>
    public class DSIEmployeePresenter : ModulePresenter<IDSIEmployeeView>
    {
        #region ��Ա���������캯����
        DSIEmployeeEntity employeeEntity = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public DSIEmployeePresenter(IDSIEmployeeView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.Employee_ModuleID;
            this.employeeEntity = new DSIEmployeeEntity();
        }
        #endregion

        #region ���ݲ���������
        /// <summary>
        /// ��ȡ�б�����Դ��
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
        ///�༭ҳ��������ݡ�
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
        /// Picker����
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