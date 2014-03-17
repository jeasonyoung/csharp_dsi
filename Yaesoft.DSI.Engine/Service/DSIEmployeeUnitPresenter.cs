//================================================================================
// FileName: DSIEmployeeUnitPresenter.cs
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
	/// IDSIEmployeeUnitView�ӿڡ�
	///</summary>
	public interface IDSIEmployeeUnitView: IModuleView
	{
        /// <summary>
        /// ��ʾ��Ϣ��
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// �б����ӿ�
    /// </summary>
    public interface IDSIEmployeeUnitListView : IDSIEmployeeUnitView
    {
        /// <summary>
        /// ��ȡ�û�����
        /// </summary>
        string EmployeeName { get; }
    }
    /// <summary>
    /// �༭����ӿ�
    /// </summary>
    public interface IDSIEmployeeUnitEditView : IDSIEmployeeUnitView
    {
        /// <summary>
        /// ��ȡ�û�ID
        /// </summary>
        GUIDEx EmployeeID { get; }
        /// <summary>
        /// ������Ȩ��λ��
        /// </summary>
        /// <param name="data"></param>
        void BindAuthorize(IListControlsData data);
        /// <summary>
        /// ��δ��Ȩ��λ��
        /// </summary>
        /// <param name="data"></param>
        void BindNonAuthorize(IListControlsData data);
    }
	///<summary>
	/// DSIEmployeeUnitPresenter��Ϊ�ࡣ
	///</summary>
	public class DSIEmployeeUnitPresenter: ModulePresenter<IDSIEmployeeUnitView>
	{
		#region ��Ա���������캯����
        DSIEmployeeUnitEntity employeeUnitEntity = null;
        DSIEmployeeEntity employeeEntity = null;
		///<summary>
		///���캯����
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

        #region ���ݲ�����
        /// <summary>
        /// ��ȡ�б�����Դ��
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
        /// �������ݡ�
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
        /// �����û���λ���ݡ�
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
        /// ������Ȩ���ݡ�
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