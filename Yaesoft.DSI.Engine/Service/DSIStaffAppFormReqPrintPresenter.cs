//================================================================================
//  FileName: DSIStaffAppFormReqPrintPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-16
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
using System.Text;
using System.IO;

using System.Xml;
using System.Xml.Serialization;

using iPower;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDSIStaffAppFormReqPrintView : IModuleView
    {
        /// <summary>
        /// 获取职工ID。
        /// </summary>
        GUIDEx StaffID { get; }
        /// <summary>
        /// 获取项目ID。
        /// </summary>
        GUIDEx ProjectID { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class DSIStaffAppFormReqPrintPresenter : ModulePresenter<IDSIStaffAppFormReqPrintView>
    {
        #region 成员变量，构造函数。
        private DSIStaffAppFormReqEntity staffAppFormReqEntity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        public DSIStaffAppFormReqPrintPresenter(IDSIStaffAppFormReqPrintView view)
            : base(view)
        {
            this.staffAppFormReqEntity = new DSIStaffAppFormReqEntity();
        }
        #endregion

        #region 数据处理。
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private XmlDocument LoadStaffFormReqXml()
        {
            XmlDocument doc = null;

            DSIStaffAppFormReq data = new DSIStaffAppFormReq();
            data.StaffID = this.View.StaffID;
            data.ProjectID = this.View.ProjectID;
            if (this.staffAppFormReqEntity.LoadRecord(ref data))
            {
                data.StatusName = this.GetEnumMemberName(typeof(EnumReqAuditStatus), data.Status);
                if (data.Staff != null)
                {
                    data.Staff.GenderName = this.GetEnumMemberName(typeof(EnumGender), data.Staff.Gender);
                    data.Staff.HardBecauseName = this.GetEnumMemberName(typeof(EnumHardBecause), data.Staff.HardBecause);
                    data.Staff.HardCategoryName = this.GetEnumMemberName(typeof(EnumHardCategory), data.Staff.HardCategory);
                    data.Staff.TheidentityName = this.GetEnumMemberName(typeof(EnumTheidentity), data.Staff.Theidentity);
                    data.Staff.HouseTypeName = this.GetEnumMemberName(typeof(EnumHouseType), data.Staff.HouseType);
                    data.Staff.MaritalstatusName = this.GetEnumMemberName(typeof(EnumMaritalStatus), data.Staff.Maritalstatus);
                    data.Staff.PeopleName = new DSIPeopleEntity().LoadPeopleName(data.Staff.PeopleID);
                    data.Staff.PoliticalFaceName = this.GetEnumMemberName(typeof(EnumPoliticalFace), data.Staff.PoliticalFace);
                    data.Staff.HealthStatusName = this.GetEnumMemberName(typeof(EnumHealthStatus), data.Staff.HealthStatus);
                    data.Staff.SelfHelpName = this.GetEnumMemberName(typeof(EnumSelfHelp), data.Staff.SelfHelp);
                    data.Staff.UnitName = new DSIUnitEntity().LoadUnitName(data.Staff.UnitID);
                    if (data.Staff.FamilyMembers != null && data.Staff.FamilyMembers.Count > 0)
                    {
                        for (int i = 0; i < data.Staff.FamilyMembers.Count; i++)
                        {
                            data.Staff.FamilyMembers[i].GenderName = this.GetEnumMemberName(typeof(EnumGender), data.Staff.FamilyMembers[i].Gender);
                            data.Staff.FamilyMembers[i].HealthStatusName = this.GetEnumMemberName(typeof(EnumHealthStatus), data.Staff.FamilyMembers[i].HealthStatus);
                            data.Staff.FamilyMembers[i].PoliticalFaceName = this.GetEnumMemberName(typeof(EnumPoliticalFace), data.Staff.FamilyMembers[i].PoliticalFace);
                            data.Staff.FamilyMembers[i].RelationName = this.GetEnumMemberName(typeof(EnumRelation), data.Staff.FamilyMembers[i].Relation);
                            data.Staff.FamilyMembers[i].TheidentityName = this.GetEnumMemberName(typeof(EnumMemberTheidentity), data.Staff.FamilyMembers[i].Theidentity);
                        }
                    }
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    XmlSerializer serialzer = new XmlSerializer(typeof(DSIStaffAppFormReq));
                    serialzer.Serialize(ms, data);

                    ms.Position = 0;
                    doc = new XmlDocument();
                    doc.Load(ms);
                }

            }
            return doc;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string PrintContent()
        {
            XmlDocument doc = this.LoadStaffFormReqXml();
            if (doc == null) return null;
            string xsl = this.ModuleConfig.StaffAppFormReqPrintXsltPath;
            if (string.IsNullOrEmpty(xsl)) return doc.OuterXml;
            return iPower.Utility.XmlTools.XmlAndXsltToHtml(doc, xsl);
        }
        #endregion
    }
}