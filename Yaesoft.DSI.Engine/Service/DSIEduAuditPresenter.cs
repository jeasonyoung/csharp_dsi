//================================================================================
// FileName: DSIEduAuditResultPresenter.cs
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
using System.Text;
using System.Data;

using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
using iPower.Platform.Engine.DataSource;
namespace Yaesoft.DSI.Engine.Service
{
    ///<summary>
    /// �����������걨������ͼ�ӿڡ�
    ///</summary>
    public interface IDSIEduAuditView : IDSIAuditView
    {

    }
    /// <summary>
    /// �����������걨�����б���ͼ�ӿڡ�
    /// </summary>
    public interface IDSIEduAuditListView : IDSIEduAuditView
    {
        /// <summary>
        /// 
        /// </summary>
        string Year { get; }
        // <summary>
        /// ��ȡ��Ŀ���ơ�
        /// </summary>
        string ProjectID { get; }
        /// <summary>
        /// ��ȡ������λ���ơ�
        /// </summary>
        string UnitName { get; }
        /// <summary>
        /// ��ȡְ�����ơ�
        /// </summary>
        string StaffName { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void BindProjectYears(IListControlsData data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void BindProjects(IListControlsData data);
    }
    /// <summary>
    /// �����������걨�����༭��ͼ�ӿڡ�
    /// </summary>
    public interface IDSIEduAuditEditView : IDSIEduAuditView, IDSIAuditEditView
    {
    }
    ///<summary>
    /// �����������걨������Ϊ�ࡣ
    ///</summary>
    public class DSIEduAuditPresenter : DSIAuditPresenter
    {
        #region ��Ա���������캯����
        private DSIProjectEntity projectEntity;
        ///<summary>
        ///���캯����
        ///</summary>
        public DSIEduAuditPresenter(IDSIEduAuditView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.Edu_Audit_ModuleID;
            this.projectEntity = new DSIProjectEntity();
        }
        #endregion

        #region ���ء�
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            IDSIEduAuditListView listView = this.View as IDSIEduAuditListView;
            if (listView != null)
            {
                listView.BindProjectYears(this.projectEntity.BindAllProjectYears);
                listView.BindProjects(this.projectEntity.BindAllProjects());
            }
        }
        #endregion

        #region ���ݲ�����
        /// <summary>
        /// �б�����
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IDSIEduAuditListView listView = this.View as IDSIEduAuditListView;
                if (listView != null)
                {
                    return this.EduAuditListDataSource(listView.Year, listView.UnitName, listView.ProjectID, listView.StaffName);
                }
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ProjectYearChanged()
        {
            IDSIEduAuditListView listView = this.View as IDSIEduAuditListView;
            if (listView != null)
            {
                listView.BindProjects(this.projectEntity.BindAllProjects(listView.Year));
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="committeeAllowance"></param>
        /// <param name="leadershipAllowance"></param>
        /// <param name="finalAllowance"></param>
        /// <param name="auditStatus"></param>
        /// <returns></returns>
        public bool Audit(float committeeAllowance,float leadershipAllowance,float finalAllowance, int auditStatus)
        {
            IDSIEduAuditEditView editView = this.View as IDSIEduAuditEditView;
            if (editView != null)
            {
                if (auditStatus > (int)EnumReqAuditStatus.None && auditStatus < (int)EnumReqAuditStatus.Final)
                {
                    editView.ShowMessage("���״̬����");
                    return false;
                }
                DSIStaffAppFormReq data = new DSIStaffAppFormReq();
                data.StaffID = editView.StaffID;
                data.ProjectID = editView.ProjectID;
                data.CommitteeAllowance = committeeAllowance;
                data.LeadershipAllowance = leadershipAllowance;
                data.FinalAllowance = finalAllowance;
                data.Status = auditStatus;

                return this.EduAudit(data);
            }
            return false;
        }
        #endregion

        #region ���ء�
        /// <summary>
        /// 
        /// </summary>
        /// <param name="auditStauts"></param>
        /// <returns></returns>
        protected override string ConvertColumnAuditName(int auditStauts)
        {
            if (auditStauts < (int)EnumReqAuditStatus.Primary) return string.Empty;
            if (auditStauts == (int)EnumReqAuditStatus.Primary) return "����";
            if (auditStauts < (int)EnumReqAuditStatus.Payee) return "������";
            return string.Empty;
        }
        #endregion
    }
}