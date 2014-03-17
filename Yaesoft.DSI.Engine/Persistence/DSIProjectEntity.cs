//================================================================================
//  FileName: DSIProjectEntity.cs
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
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.DSI.Engine.Domain;
namespace Yaesoft.DSI.Engine.Persistence
{
    /// <summary>
    /// 申报项目实体。
    /// </summary>
    internal class DSIProjectEntity : DbModuleEntity<DSIProject>
    {
        #region 成员变量，构造函数。
        private DSIProjectAttachmentEntity projectAttachmentEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public DSIProjectEntity()
        {
            this.projectAttachmentEntity = new DSIProjectAttachmentEntity();
        }
        #endregion

        #region 列表数据。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string projectName)
        {
            return this.GetAllRecord(string.Format("ProjectName like '%{0}%'", projectName), "CreateTime desc");
        }
        #endregion

        #region 数据绑定。
        /// <summary>
        /// 绑定有效时间内的申报项目。
        /// </summary>
        /// <returns></returns>
        public IListControlsData BindProjects
        {
            get
            {
                return new ListControlsDataSource("ProjectName", "ProjectID", this.GetAllRecord("(getdate() between startTime and EndTime)", "CreateTime desc"));
            }
        }
        /// <summary>
        /// 绑定全部申报项目年度。
        /// </summary>
        public IListControlsData BindAllProjectYears
        {
            get
            {
                const string sql = "select convert(nvarchar(4),StartTime,121) as [Year] from tblDSIProject group by convert(nvarchar(4),StartTime,121)";
                return new ListControlsDataSource("Year", "Year", this.DatabaseAccess.ExecuteDataset(sql).Tables[0]);
            }
        }
        /// <summary>
        ///  绑定全部申报项目。
        /// </summary>
        /// <returns></returns>
        public IListControlsData BindAllProjects()
        {
            return this.BindAllProjects(null);
        }
        /// <summary>
        /// 绑定全部申报项目。
        /// </summary>
        public IListControlsData BindAllProjects(string year)
        {
            StringBuilder where = new StringBuilder();
            if (!string.IsNullOrEmpty(year))
            {
                where.AppendFormat("convert(nvarchar(4),StartTime,121) = '{0}'", year);
            }
            return new ListControlsDataSource("ProjectName", "ProjectID", this.GetAllRecord(where.ToString(), "CreateTime desc,ProjectName"));
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="top"></param>
        /// <param name="isView"></param>
        /// <returns></returns>
        public List<DSIProject> LoadProjects(int top, bool isView)
        {
            List<DSIProject> list = new List<DSIProject>();
            if (top > 0)
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("select top {0}  * ", top);
                sql.AppendFormat("from {0} ", this.TableName);
                if (isView) sql.Append(" where IsView = 1 ");
                sql.Append(" order by startTime desc ");
                DataTable dtSource = this.DatabaseAccess.ExecuteDataset(sql.ToString()).Tables[0];
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    foreach (DataRow row in dtSource.Rows)
                    {
                        DSIProject data = new DSIProject();
                        data.ProjectID = string.Format("{0}", row["ProjectID"]);
                        if (this.LoadRecord(ref data))
                        {
                            list.Add(data);
                        }
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool LoadRecord(ref DSIProject entity)
        {
            bool result = false;
            if (result = base.LoadRecord(ref entity))
            {
                entity.Attachments = this.projectAttachmentEntity.LoadAttachments(entity.ProjectID);
            }
            return result;
        }
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="delAttachments"></param>
        /// <returns></returns>
        public bool UpdateRecord(DSIProject entity, StringCollection delAttachments)
        {
            if (entity == null) return false;
            this.projectAttachmentEntity.UpdateRecord(entity.ProjectID, entity.Attachments, delAttachments);
            return this.UpdateRecord(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool UpdateRecord(DSIProject entity)
        {
            if (entity == null) return false;
            DateTime? startTime = entity.StartTime, endTime = entity.EndTime;
            if (startTime != null && startTime.HasValue)
            {
                entity.StartTime = new DateTime(startTime.Value.Year, startTime.Value.Month, startTime.Value.Day, 0, 0, 0);
            }
            if (endTime != null && endTime.HasValue)
            {
                entity.EndTime = new DateTime(endTime.Value.Year, endTime.Value.Month, endTime.Value.Day, 23, 59, 59);
            }
            return base.UpdateRecord(entity);
        }
        /// <summary>
        /// 删除数据。
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        public override bool DeleteRecord(StringCollection primaryValues)
        {
            if (primaryValues == null || primaryValues.Count == 0) return false;
            string[] array = new string[primaryValues.Count];
            primaryValues.CopyTo(array, 0);
            return this.DeleteRecord(array);
        }
        /// <summary>
        /// 删除数据。
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        protected override bool DeleteRecord(string[] primaryValues)
        {
            if (primaryValues == null || primaryValues.Length == 0) return false;
            this.projectAttachmentEntity.DeleteRecordByProjectID(primaryValues);
            return base.DeleteRecord(primaryValues);
        }
        #endregion
    }
}