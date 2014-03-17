//================================================================================
//  FileName: DSIStaffPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-15
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

using iPower;
using iPower.Platform.Engine.DataSource;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 教职工信息视图。
    /// </summary>
    public interface IDSIStaffView : IModuleView
    {
        /// <summary>
        /// 显示提示信息。
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);
    }
    /// <summary>
    /// 教职工信息用户视图。
    /// </summary>
    public interface IDSIStaffUCView : IDSIStaffView
    {
        /// <summary>
        /// 获取调用模块的视图对象。
        /// </summary>
        IModuleView ParentModuleView { get; }
        /// <summary>
        /// 获取或设置职工ID。
        /// </summary>
        GUIDEx StaffID { get; set; }
        /// <summary>
        /// 绑定困难类别。
        /// </summary>
        /// <param name="data"></param>
        void BindHardCategory(IListControlsData data);
        /// <summary>
        /// 绑定身份。
        /// </summary>
        /// <param name="data"></param>
        void BindTheidentity(IListControlsData data);
        /// <summary>
        /// 绑定民族。
        /// </summary>
        /// <param name="data"></param>
        void BindPeople(IListControlsData data);
        /// <summary>
        /// 绑定性别。
        /// </summary>
        /// <param name="data"></param>
        void BindGender(IListControlsData data);
        /// <summary>
        /// 绑定政治面貌。
        /// </summary>
        /// <param name="data"></param>
        void BindPoliticalFace(IListControlsData data);
        /// <summary>
        /// 绑定健康状况。
        /// </summary>
        /// <param name="data"></param>
        void BindHealthStatus(IListControlsData data);
        /// <summary>
        /// 绑定住房类型。
        /// </summary>
        /// <param name="data"></param>
        void BindHouseType(IListControlsData data);
        /// <summary>
        /// 绑定婚姻状况。
        /// </summary>
        /// <param name="data"></param>
        void BindMaritalstatus(IListControlsData data);
        /// <summary>
        /// 绑定工作单位。
        /// </summary>
        /// <param name="data"></param>
        void BindUnit(IListControlsData data);
        /// <summary>
        /// 绑定是否有一定自救能力。
        /// </summary>
        /// <param name="data"></param>
        void BindSelfHelp(IListControlsData data);
        /// <summary>
        /// 绑定致困主要原因。
        /// </summary>
        /// <param name="data"></param>
        void BindHardBecause(IListControlsData data);
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="data"></param>
        void LoadData(DSIStaffInfo data);
        /// <summary>
        /// 保存数据。
        /// </summary>
        /// <param name="data"></param>
        bool SaveData(DSIStaffInfo data);
        /// <summary>
        /// 消息事件。
        /// </summary>
        event ShowMessageHandler ShowMessageEvent;
    }
    /// <summary>
    /// 教职工选择接口。
    /// </summary>
    public interface IDSIStaffPickerView : IDSIStaffView
    {
        /// <summary>
        /// 绑定所属单位数据。
        /// </summary>
        /// <param name="data"></param>
        void BindUnits(IListControlsData data);
        /// <summary>
        /// 是否全部单位。
        /// </summary>
        bool IsAllUnit { get; }
        /// <summary>
        /// 绑定显示结果。
        /// </summary>
        /// <param name="data"></param>
        void DisplayStaffs(IListControlsData data);
    }
    /// <summary>
    /// 教职工信息用户控件行为类。
    /// </summary>
    public class DSIStaffUCPresenter : ModulePresenter<IDSIStaffView>
    {
        #region 成员变量，构造函数。
        private DSIStaffInfoEntity staffInfoEntity;
        private DSIPeopleEntity peopleEntity;
        private DbModuleEntity<DSIStaffModifyRecord> staffModifyRecordEntity;
        private DSIStaffAppFormReqEntity staffAppFormReqEntity;
        private DSIUnitEntity unitEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIStaffUCPresenter(IDSIStaffView view)
            : base(view)
        {
            this.staffInfoEntity = new DSIStaffInfoEntity();
            this.staffInfoEntity.DbEntityDataChangeLogEvent += this.CreateCommonLog;
            this.peopleEntity = new DSIPeopleEntity();
            this.staffModifyRecordEntity = new DbModuleEntity<DSIStaffModifyRecord>();
            this.staffAppFormReqEntity = new DSIStaffAppFormReqEntity();
            this.unitEntity = new DSIUnitEntity();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            IDSIStaffUCView ucView = this.View as IDSIStaffUCView;
            if (ucView != null)
            {
                ucView.BindHardCategory(this.EnumDataSource(typeof(EnumHardCategory)));
                ucView.BindTheidentity(this.EnumDataSource(typeof(EnumTheidentity)));
                ucView.BindPeople(this.peopleEntity.BindPeopleData);
                ucView.BindGender(this.EnumDataSource(typeof(EnumGender)));
                ucView.BindPoliticalFace(this.EnumDataSource(typeof(EnumPoliticalFace)));
                ucView.BindHealthStatus(this.EnumDataSource(typeof(EnumHealthStatus)));
                ucView.BindHouseType(this.EnumDataSource(typeof(EnumHouseType)));

                ucView.BindMaritalstatus(this.EnumDataSource(typeof(EnumMaritalStatus)));

                if ((ucView.ParentModuleView is IDSIEduStaffInfoView) || (ucView.ParentModuleView is IDSIEduStaffAppFormReqEditView) || (ucView.ParentModuleView is IDSIAuditView))
                {
                    ucView.BindUnit(new DSIUnitEntity().BindAllUnit);
                }
                else
                {
                    ucView.BindUnit(new DSIUnitEntity().BindUnitByAuthorize(this.View.CurrentUserID));
                }
                ucView.BindSelfHelp(this.EnumDataSource(typeof(EnumSelfHelp)));
                ucView.BindHardBecause(this.EnumDataSource(typeof(EnumHardBecause)));
                return;
            }
            IDSIStaffPickerView pickerView = this.View as IDSIStaffPickerView;
            if (pickerView != null)
            {
                pickerView.BindUnits(pickerView.IsAllUnit ? new DSIUnitEntity().BindAllUnit : new DSIUnitEntity().BindUnitByAuthorize(this.View.CurrentUserID));
            }
        }
        #endregion

        #region 数据操作
        /// <summary>
        /// picker搜索。
        /// </summary>
        /// <param name="unitID"></param>
        /// <param name="staffName"></param>
        public void PickerSeacher(string unitID, string staffName)
        {
            IDSIStaffPickerView picker = this.View as IDSIStaffPickerView;
            if (picker != null)
            {
                picker.DisplayStaffs(this.staffInfoEntity.BindStaffs(unitID, staffName));
            }
        }
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delAttachments"></param>
        /// <returns></returns>
        public bool UpdateData(DSIStaffInfo data, StringCollection delAttachments)
        {
            if (data == null) return false;
            DSIStaffInfo source = new DSIStaffInfo();
            source.StaffID = data.StaffID;
            if (this.staffInfoEntity.LoadRecord(ref source))
            {
                if (this.staffAppFormReqEntity.LoadAuditingCount(source.StaffID) > 0)
                {
                    this.View.ShowMessage("补助申报正在审批，暂不允许修改！");
                    return false;
                }


                if (!string.IsNullOrEmpty(source.CreateUserID))
                {
                    data.CreateUserID = source.CreateUserID;
                    data.CreateUserName = source.CreateUserName;
                }
                data.CreateTime = source.CreateTime;

                StringBuilder content = new StringBuilder();
                ModuleUtils.ComparePropertyValue(source, data, new string[] { "FamilyMembers" }, new ComparePropertyHandler(delegate(string fieldName, string sourceValue, string targetValue)
                {
                    string strFieldName = this.ModuleConfig.LoadStaffFieldDesc(fieldName);
                    if (string.IsNullOrEmpty(strFieldName)) return;
                    content.Append(",")
                           .Append(strFieldName).Append(":")
                           .Append("[" + this.loadPropertyFieldValue(fieldName, sourceValue) + "]")
                           .Append("=>")
                           .Append("[" + this.loadPropertyFieldValue(fieldName, targetValue) + "]");

                }));

                DSIStaffModifyRecord record = new DSIStaffModifyRecord();
                record.StaffID = data.StaffID;
                record.RecordID = GUIDEx.New;
                string strContent = content.ToString();
                record.Content = (string.IsNullOrEmpty(strContent) ? strContent : strContent.Substring(1)).Trim();
                record.CreateTime = DateTime.Now;
                record.CreateUserId = this.View.CurrentUserID;
                record.CreateUserName = this.View.CurrentUserName;
                if (!string.IsNullOrEmpty(record.Content))
                {
                    this.staffModifyRecordEntity.UpdateRecord(record);
                }
            }
            return this.staffInfoEntity.UpdateRecord(data, delAttachments);
        }
        private static System.Collections.Hashtable propertyfieldvalue_cache = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable());
        private string loadPropertyFieldValue(string fieldName, string id)
        {
            if (string.IsNullOrEmpty(fieldName) || string.IsNullOrEmpty(id)) return id;
            string key = fieldName + "_" + id;
            string value = propertyfieldvalue_cache[key] as string;
            if (string.IsNullOrEmpty(value))
            {
                #region 枚举处理。
                switch (fieldName)
                {
                    case "HardCategory"://困难类别
                        value = this.GetEnumMemberName(typeof(EnumHardCategory), int.Parse(id));
                        break;
                    case "Theidentity"://身份
                        value = this.GetEnumMemberName(typeof(EnumTheidentity), int.Parse(id));
                        break;
                    case "Gender"://性别
                        value = this.GetEnumMemberName(typeof(EnumGender), int.Parse(id));
                        break;
                    case "PeopleID"://民族
                        value = this.peopleEntity.LoadPeopleName(id);
                        break;
                    case "PoliticalFace"://政治面貌
                        value = this.GetEnumMemberName(typeof(EnumPoliticalFace), int.Parse(id));
                        break;
                    case "HealthStatus"://健康状况
                        value = this.GetEnumMemberName(typeof(EnumHealthStatus), int.Parse(id));
                        break;
                    case "HouseType"://住房类型
                        value = this.GetEnumMemberName(typeof(EnumHouseType), int.Parse(id));
                        break;
                    case "Maritalstatus"://婚姻状况
                        value = this.GetEnumMemberName(typeof(EnumMaritalStatus), int.Parse(id));
                        break;
                    case "UnitID"://工作单位
                        value = this.unitEntity.LoadUnitName(id);
                        break;
                    case "SelfHelp"://是否有自救能力
                        value = this.GetEnumMemberName(typeof(EnumSelfHelp), int.Parse(id));
                        break;
                    case "HardBecause"://致困主要原因
                        value = this.GetEnumMemberName(typeof(EnumHardBecause), int.Parse(id));
                        break;
                    case "Birthday"://出生年月
                        {
                            try
                            {
                                DateTime dt = DateTime.Parse(id);
                                return string.Format("{0:yyyy-MM}", dt);
                            }
                            catch (Exception) { }
                        }
                        break;
                    case "TimeWorkStart":
                        {
                            try
                            {
                                DateTime dt = DateTime.Parse(id);
                                return string.Format("{0:yyyy-MM}", dt);
                            }
                            catch (Exception) { }
                        }
                        break;
                }
                #endregion

                //缓存
                if (!string.IsNullOrEmpty(value))
                {
                    propertyfieldvalue_cache[key] = value;
                }
            }
            if (string.IsNullOrEmpty(value)) return id;
            return value;
        }
        #endregion
    }
}