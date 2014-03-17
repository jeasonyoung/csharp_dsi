//================================================================================
// FileName: DSIUnitPresenter.cs
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
	/// IDSIUnitView接口。
	///</summary>
	public interface IDSIUnitView: IModuleView
	{
        /// <summary>
        /// 单位名称
        /// </summary>
        string Unitname { get; }
        /// <summary>
        /// 错误消息
        /// </summary>
        /// <param name="Msg"></param>
        void ShowMessage(string Msg);
	}
    /// <summary>
    /// 列表界面接口
    /// </summary>
    public interface IDSIUnitListView : IDSIUnitView
    {
 
    }		
	///<summary>
	/// DSIUnitPresenter行为类。
	///</summary>
	public class DSIUnitPresenter: ModulePresenter<IDSIUnitView>
	{
		#region 成员变量，构造函数。
        private DSIUnitEntity dsiUnitEntity;
		///<summary>
		///构造函数。
		///</summary>
		public DSIUnitPresenter(IDSIUnitView view)
		: base(view)
		{
            this.dsiUnitEntity = new DSIUnitEntity();
            this.View.SecurityID = ModuleConstants.Unit_ModuleID;
		}
		#endregion

        #region 列表数据
        /// <summary>
        /// 列表数据源
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