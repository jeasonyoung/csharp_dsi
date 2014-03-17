//================================================================================
// FileName: DSIStaffInfoEntity.cs
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
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.DSI.Engine.Domain;
namespace Yaesoft.DSI.Engine.Persistence
{
	///<summary>
	///DSIStaffInfoEntityʵ���ࡣ
	///</summary>
	internal class DSIStaffInfoEntity: DbModuleEntity<DSIStaffInfo>
	{
		#region ��Ա���������캯����
        private DSIStaffFamilyMemberEntity familyMemberEntity;
        private DSIStaffAppFormAttachmentEntity attachmentEntity;
		///<summary>
		///���캯��
		///</summary>
		public DSIStaffInfoEntity()
		{
            this.familyMemberEntity = new DSIStaffFamilyMemberEntity();
            this.attachmentEntity = new DSIStaffAppFormAttachmentEntity();
		}
		#endregion

        #region ���ء�
        /// <summary>
        /// ����ְ��������Ϣ��
        /// </summary>
        /// <param name="createUserId">�����û�ID</param>
        /// <returns></returns>
        public DSIStaffInfo LoadDataByUserID(string createUserId)
        {
            string sql = "select top 1 StaffID from " + this.TableName + " where CreateUserID = '{0}' order by CreateTime desc";
            if (string.IsNullOrEmpty(createUserId)) return null;
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, createUserId));
            if (obj == null) return null;
            DSIStaffInfo data = new DSIStaffInfo();
            data.StaffID = new GUIDEx(obj);
            if (this.LoadRecord(ref data)) return data;
            return null;
        }
        /// <summary>
        /// �������ݡ�
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool LoadRecord(ref DSIStaffInfo entity)
        {
            bool result = false;
            if (result = base.LoadRecord(ref entity))
            {
                entity.FamilyMembers = this.familyMemberEntity.LoadData(entity.StaffID);
                entity.Attachments = this.attachmentEntity.LoadAttachments(entity.StaffID);
            }
            return result;
        }
        /// <summary>
        /// �������ݡ�
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="delAttachments"></param>
        /// <returns></returns>
        public bool UpdateRecord(DSIStaffInfo entity, StringCollection delAttachments)
        {
            if (entity == null) return false;
            this.familyMemberEntity.UpdateRecord(entity.StaffID, entity.FamilyMembers);
            this.attachmentEntity.UpdateRecord(entity.StaffID, entity.Attachments, delAttachments);
            return this.UpdateRecord(entity);
        }
        /// <summary>
        /// ɾ�����ݡ�
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        protected override bool DeleteRecord(string[] primaryValues)
        {
            if (primaryValues == null || primaryValues.Length == 0) return false;
            DSIStaffAppFormReqEntity reqEntity = new DSIStaffAppFormReqEntity();
            for (int i = 0; i < primaryValues.Length; i++)
            {
                if (reqEntity.Exists(primaryValues[i]))
                {
                    throw new Exception("��ְ�����������걨��Ŀ������������ɾ����");
                }
            }

            this.familyMemberEntity.DeleteRecordByStaffID(primaryValues);
            this.attachmentEntity.DeleteRecordByStaffID(primaryValues);
            return base.DeleteRecord(primaryValues);
        }
        #endregion
        
        #region ���ݲ�����
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitID"></param>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public IListControlsData BindStaffs(string unitID, string staffName)
        {
            StringBuilder where = new StringBuilder();
            if (!string.IsNullOrEmpty(unitID))
            {
                where.AppendFormat("UnitID = '{0}' ", unitID);
            }
            if (!string.IsNullOrEmpty(staffName))
            {
                if (where.Length > 0) where.Append(" and ");
                where.AppendFormat("StaffName like '%{0}%' ", staffName);
            }
            DataTable dtSource = this.GetAllRecord(where.ToString());
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    row["StaffName"] = string.Format("{0}[��������ʱ��:{1:yyyy-MM-dd},{2}]", row["StaffName"], row["CreateTime"], row["CreateUserName"]);
                }
            }
            return new ListControlsDataSource("StaffName", "StaffID", dtSource);
        }
        /// <summary>
        /// ѧУ��ְ�������б�
        /// </summary>
        /// <param name="currentEmployeeId"></param>
        /// <param name="unitName"></param>
        /// <param name="staffCodeNameCard"></param>
        /// <returns></returns>
        public DataTable SchoolListDataSource(GUIDEx currentEmployeeId,string unitName, string staffCodeNameCard)
        {
            const string sql = "exec spDSISchoolStaffInfoListView '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, unitName, staffCodeNameCard, currentEmployeeId)).Tables[0];
        }
        /// <summary>
        /// �����ֽ�ְ�������б�
        /// </summary>
        /// <param name="unitName"></param>
        /// <param name="staffCodeNameCard"></param>
        /// <returns></returns>
        public DataTable EduListDataSource(string unitName, string staffCodeNameCard)
        {
            const string sql = "exec spDSIEduStaffInfoListView '{0}','{1}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, unitName, staffCodeNameCard)).Tables[0];
        }
        #endregion
    }
}