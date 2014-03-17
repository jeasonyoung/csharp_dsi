//================================================================================
//  FileName: DSIStaffAppFormReqEntity.cs
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
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.DSI.Engine.Domain;
namespace Yaesoft.DSI.Engine.Persistence
{
    /// <summary>
    /// 职工申报救助项目表实体操作类。
    /// </summary>
    internal class DSIStaffAppFormReqEntity : DbModuleEntity<DSIStaffAppFormReq>
    {
        #region 成员变量，构造函数。
        private DSIStaffInfoEntity staffInfoEntity;
        /// <summary>
        /// 
        /// </summary>
        public DSIStaffAppFormReqEntity()
        {
            this.staffInfoEntity = new DSIStaffInfoEntity();
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffID"></param>
        /// <returns></returns>
        public bool Exists(string staffID)
        {
            const string sql = "select count(*) from {0} where StaffID = '{1}'";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, staffID));
            if (obj == null) return false;
            return ((int)obj) > 0;
        }
        /// <summary>
        /// 查询职工在审核中的申报数目。
        /// </summary>
        /// <param name="staffID"></param>
        /// <returns></returns>
        public int LoadAuditingCount(string staffID)
        {
            const string sql = "select count(*) from {0} where StaffID = '{1}' and (Status > {2} and Status < {3})";
            if (string.IsNullOrEmpty(staffID)) return 0;
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, staffID, (int)EnumReqAuditStatus.None, (int)EnumReqAuditStatus.Final));
            return (obj == null) ? 0 : (int)obj;
        }
        /// <summary>
        /// 获取职工申请列表数据。
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="currrentUserID"></param>
        /// <returns></returns>
        public DataTable PersonalListDataSource(string projectName, string currrentUserID)
        {
            const string sql = "exec spDSIPersonalStaffAppFormReqListView '{0}','{1}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, projectName, currrentUserID)).Tables[0];
        }
        /// <summary>
        /// 获取学校职工申请列表数据。
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="currrentUserID"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public DataTable SchoolListDataSource(string projectName, string currrentUserID,string staffName)
        {
            const string sql = "exec spDSISchoolStaffAppFormReqListView '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, projectName, currrentUserID, staffName)).Tables[0];
        }
        /// <summary>
        /// 获取公示职工列表数据。
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="staffName"></param>
        /// <param name="currrentUserID"></param>
        /// <returns></returns>
        public DataTable PublicityStaffRequestDataSource(string projectName, string staffName, string currrentUserID)
        {
            const string sql = "exec spDSIPublicityStaffRequestListView '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, projectName, staffName, currrentUserID)).Tables[0];
        }
        /// <summary>
        /// 获取教育局职工申请列表数据。
        /// </summary>
        /// <param name="unitName"></param>
        /// <param name="projectName"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public DataTable EduListDataSource(string unitName, string projectName, string staffName)
        {
            const string sql = "exec spDSIEduStaffAppFormReqListView '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, unitName, projectName,staffName)).Tables[0];
        }
        /// <summary>
        /// 获取学校职工申请初审列表数据
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="currrentUserID"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public DataTable SchoolAuditListDataSource(string projectName, string currrentUserID, string staffName)
        {
            const string sql = "exec  spDSISchoolAuditListView '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, projectName, currrentUserID, staffName)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="unitName"></param>
        /// <param name="projectName"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public DataTable EduAuditListDataSource(string year,string unitName, string projectName, string staffName)
        {
            const string sql = "exec spDSIEduAuditListView '{0}','{1}','{2}','{3}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, year, unitName, projectName, staffName)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        public DataTable StaffAllowanceListDataSource(string staffId)
        {
            const string sql = "exec spDSIStaffAllowance '{0}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, staffId)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="projectId"></param>
        /// <param name="currrentUserID"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public DataTable SchoolStaffAllowanceListDataSource(string year, string projectId, string currrentUserID, string staffName)
        {
            const string sql = "exec spDSISchoolStaffAllowance '{0}','{1}','{2}','{3}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, year, projectId, currrentUserID, staffName)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="unitName"></param>
        /// <param name="projectId"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public DataTable EduStaffAllowanceListDataSource(string year, string unitName, string projectId, string staffName)
        {
            const string sql = "exec spDSIEduStaffAllowance '{0}','{1}','{2}','{3}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, year, unitName, projectId, staffName)).Tables[0];
        }
        #endregion

        #region 补助统计。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="projectID"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public DataTable SchoolRptAllowance(string year, string projectID, string currentUserId)
        {
            const string sql = "exec spDSISchoolRptAllowance '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, year, projectID, currentUserId)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="projectId"></param>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public DataTable EduRptUnitYearAllowance(string year,string projectId, string unitName)
        {
            const string sql = "exec spDSIEduRptUnitYearAllowanceList '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, year, projectId, unitName)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable EduRptAllowanceDetail(string unitId, string year)
        {
            const string sql = "exec spDSIRptAllowanceDetail '{0}','{1}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, unitId, year)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public DataTable EduRptYearAllowance(string year, string projectId)
        {
            const string sql = "spDSIEduRptYearAllowance '{0}','{1}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, year, projectId)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public DataTable EduRptProjectAllowance(string year, string projectId)
        {
            const string sql = "exec spDSIEduRptProjectAllowance '{0}','{1}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, year, projectId)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable EduRptTimeAllowance(string projectName, DateTime startTime, DateTime endTime)
        {
            startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0);
            endTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, 23, 59, 59);

            const string sql = "spDSIEduRptTimeAllowance '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, projectName, startTime, endTime)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable EduRptAllowance(string year, string projectId)
        {
            const string sql = "exec spDSIEduRptAllowance '{0}','{1}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, year, projectId)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="projectId"></param>
        /// <param name="unitName"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public DataTable EduRptStaffAllowance(string year,string projectId, string unitName, string staffName)
        {
            const string sql = "exec spDSIEduRptStaffAllowance '{0}','{1}','{2}','{3}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, year, projectId, unitName, staffName)).Tables[0];
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentUserID"></param>
        /// <returns></returns>
        public DSIStaffInfo LoadStaffByUserID(string currentUserID)
        {
            if (string.IsNullOrEmpty(currentUserID)) return null;
            return this.staffInfoEntity.LoadDataByUserID(currentUserID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool LoadRecord(ref DSIStaffAppFormReq entity)
        {
            bool result = base.LoadRecord(ref entity);
            DSIStaffInfo data = new DSIStaffInfo();
            data.StaffID = entity.StaffID;
            if (this.staffInfoEntity.LoadRecord(ref data))
            {
                entity.Staff = data;
            }
            if (result) return result;
            return entity.Staff != null;
        }
        /// <summary>
        /// 学校审核申报。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SchoolAudit(DSIStaffAppFormReq data)
        {
            if (data == null || string.IsNullOrEmpty(data.StaffID) || string.IsNullOrEmpty(data.ProjectID)) return false;
            DSIStaffAppFormReq source = new DSIStaffAppFormReq();
            source.StaffID = data.StaffID;
            source.ProjectID = data.ProjectID;
            if (base.LoadRecord(ref source))
            {
                source.PrimaryAllowance = data.PrimaryAllowance;
                source.PrimaryAudit = data.PrimaryAudit;
                source.PrimaryAuditTime = DateTime.Now;
                if ((source.Status = data.Status) < 0)
                {
                    source.PrimaryAllowance = 0;
                    source.PrimaryAudit = string.Empty;
                }
                return this.UpdateRecord(source);
            }
            return false;
        }
        /// <summary>
        /// 教育局审核申报。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool EduAudit(DSIStaffAppFormReq data)
        {
            if (data == null || string.IsNullOrEmpty(data.StaffID) || string.IsNullOrEmpty(data.ProjectID)) return false;
            DSIStaffAppFormReq source = new DSIStaffAppFormReq();
            source.StaffID = data.StaffID;
            source.ProjectID = data.ProjectID;
            if (base.LoadRecord(ref source))
            {
                source.CommitteeAllowance = data.CommitteeAllowance;
                source.LeadershipAllowance = data.LeadershipAllowance;
                source.FinalAllowance = data.FinalAllowance;
                if ((source.Status = data.Status) < 0)
                {
                    source.CommitteeAllowance = source.LeadershipAllowance = source.FinalAllowance = 0;
                }
                return this.UpdateRecord(source);
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        protected override bool DeleteRecord(string[] primaryValues)
        {
            bool result = true;
            if (primaryValues != null && primaryValues.Length > 0)
            {
                for (int i = 0; i < primaryValues.Length; i++)
                {
                    string[] strs = primaryValues[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    if (strs != null && strs.Length == 2)
                    {
                        NameValueCollection nv = new NameValueCollection();
                        nv.Add("StaffID", strs[0]);
                        nv.Add("ProjectID", strs[1]);

                        result &= base.DeleteRecord(nv);
                    }
                }
            }
            return result;
        }
        #endregion
    }
}