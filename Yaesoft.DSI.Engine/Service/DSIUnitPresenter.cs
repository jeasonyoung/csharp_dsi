//================================================================================
// FileName: DSIUnitPresenter.cs
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
	/// IDSIUnitView�ӿڡ�
	///</summary>
	public interface IDSIUnitView: IModuleView
	{
        /// <summary>
        /// ��λ����
        /// </summary>
        string Unitname { get; }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="Msg"></param>
        void ShowMessage(string Msg);
	}
    /// <summary>
    /// �б����ӿ�
    /// </summary>
    public interface IDSIUnitListView : IDSIUnitView
    {
 
    }		
	///<summary>
	/// DSIUnitPresenter��Ϊ�ࡣ
	///</summary>
	public class DSIUnitPresenter: ModulePresenter<IDSIUnitView>
	{
		#region ��Ա���������캯����
        private DSIUnitEntity dsiUnitEntity;
		///<summary>
		///���캯����
		///</summary>
		public DSIUnitPresenter(IDSIUnitView view)
		: base(view)
		{
            this.dsiUnitEntity = new DSIUnitEntity();
            this.View.SecurityID = ModuleConstants.Unit_ModuleID;
		}
		#endregion

        #region �б�����
        /// <summary>
        /// �б�����Դ
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IDSIUnitListView listView = this.View as IDSIUnitListView;
                if (listView != null)
                {
                    return this.dsiUnitEntity.ListDataSource(listView.Unitname);
                }
                return null;
            }
        }
        #endregion
    }
}