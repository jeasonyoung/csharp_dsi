using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Data;

using iPower;
using iPower.IRMP.Security.Engine.Domain;
using iPower.Platform.Engine.Service;

using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
using iPower.Platform.Engine.DataSource;
namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 设置基层工会管理员视图。
    /// </summary>
    public interface IDSIEduSetBaseAdminView : IModuleView
    {
    }
    /// <summary>
    /// 设置基层工会管理员列表视图。
    /// </summary>
    public interface IDSIEduSetBaseAdminListView : IDSIEduSetBaseAdminView
    {
        /// <summary>
        /// 获取单位名称。
        /// </summary>
        string UnitName { get; }
        /// <summary>
        /// 获取用户姓名。
        /// </summary>
        string EmployeeName { get; }
    }
    /// <summary>
    /// 设置基层工会管理员编辑视图。
    /// </summary>
    public interface IDSIEduSetBaseAdminEditView : IDSIEduSetBaseAdminView
    {
        /// <summary>
        /// 绑定单位数据。
        /// </summary>
        /// <param name="data"></param>
        void BindUnits(IListControlsData data);
    }
    /// <summary>
    /// 设置基层工会管理员行为类。
    /// </summary>
    public class DSIEduSetBaseAdminPresenter : ModulePresenter<IDSIEduSetBaseAdminView>
    {
        #region 成员变量，构造函数。
        private DSIRoleEmployeeEntity roleEmployeeEntity;
        private DSIUnitEntity unitEntity;
        private DSIEmployeeUnitEntity employeeUnitEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIEduSetBaseAdminPresenter(IDSIEduSetBaseAdminView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.SetBaseAdmin_ModuleID;
            this.roleEmployeeEntity = new DSIRoleEmployeeEntity();
            this.unitEntity = new DSIUnitEntity();
            this.employeeUnitEntity = new DSIEmployeeUnitEntity();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            IDSIEduSetBaseAdminEditView editView = this.View as IDSIEduSetBaseAdminEditView;
            if (editView != null)
            {
                editView.BindUnits(this.unitEntity.BindAllUnit);
            }
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
                IDSIEduSetBaseAdminListView listView = this.View as IDSIEduSetBaseAdminListView;
                if (listView != null)
                {
                    return this.roleEmployeeEntity.ListDataSource(listView.UnitName, listView.EmployeeName);
                }
                return null;
            }
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 检索用户数据。
        /// </summary>
        /// <param name="unitId">基层单位ID。</param>
        /// <param name="employeeName">用户姓名</param>
        /// <returns></returns>
        public IListControlsData SearchEmployees(string unitId, string employeeName)
        {
            return this.employeeUnitEntity.SearchEmployees(unitId, employeeName);
        }
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public bool UpdateEntityData(string employeeId, string employeeName)
        {
            SecurityRoleEmployee data = new SecurityRoleEmployee();
            //data.RoleID = this.ModuleConfig.BaseAdminRoleID;
            data.EmployeeID = employeeId;
            data.EmployeeName = employeeName;

            return this.roleEmployeeEntity.UpdateRecord(data);
        }
         /// <summary>
        /// 批量删除。
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        public bool DeleteEntityData(StringCollection primaryValues)
        {
            return this.roleEmployeeEntity.DeleteRecord(primaryValues);
        }
        #endregion
    }
}