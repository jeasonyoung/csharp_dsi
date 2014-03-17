//================================================================================
//  FileName: ModuleConfiguration.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/1
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using iPower;
using iPower.Utility;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Persistence;
using iPower.FileStorage;
namespace Yaesoft.DSI.Engine.Persistence
{
    /// <summary>
    ///  模块配置键。
    /// </summary>
    public class ModuleConfigurationKeys : BaseModuleConfigurationKeys
    {
        /// <summary>
        /// 档案字段描述配置文件键名。
        /// </summary>
        public const string StaffFieldDescConfigFileKey = "StaffFieldDescConfigFile";
        /// <summary>
        /// 教职工申报打印Xslt文件键名。
        /// </summary>
        public const string StaffAppFormReqPrintXsltPathKey = "StaffAppFormReqPrintXsltPath";
        /// <summary>
        /// 基层工会管理员角色ID键名。
        /// </summary>
        public const string BaseAdminRoleIDKey = "BaseAdminRoleID";
        /// <summary>
        /// 错误错误页面Url键名。
        /// </summary>
        public const string ErrorHandlerPageUrl = "ErrorHandlerPageUrl";
    }
    /// <summary>
    /// 模块配置类。
    /// </summary>
    public class ModuleConfiguration : BaseModuleConfiguration
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ModuleConfiguration()
            : base("DSI")
        {
        }
        #endregion

        #region 静态实例。
        static ModuleConfiguration m_config;
        /// <summary>
        /// 获取静态实例。
        /// </summary>
        public static ModuleConfiguration ModuleConfig
        {
            get
            {
                lock (typeof(ModuleConfiguration))
                {
                    if (m_config == null)
                        m_config = new ModuleConfiguration();
                    return m_config;
                }
            }
        }
        #endregion

        #region 错误处理页面。
        /// <summary>
        /// 错误错误页面Url.
        /// </summary>
        public string ErrorHandlerPageUrl
        {
            get { return this[ModuleConfigurationKeys.ErrorHandlerPageUrl];}
        }
        #endregion

        #region 基层工会角色ID。
        /// <summary>
        /// 获取基层工会角色ID。
        /// </summary>
        public string BaseAdminRoleID
        {
            get
            {
                return this[ModuleConfigurationKeys.BaseAdminRoleIDKey];
            }
        }
        #endregion

        #region 上传文件存储。
        /// <summary>
        /// 获取附件对象。
        /// </summary>
        public IFileStorageFactory FileStorageFacotry
        {
            get
            {
                return FileStorageFactoryInstance.Instance;
            }
        }
        #endregion

        #region 打印。
        /// <summary>
        /// 教职工申报打印Xslt文件路径。
        /// </summary>
        public string StaffAppFormReqPrintXsltPath
        {
            get
            {
                return Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "\\" + this[ModuleConfigurationKeys.StaffAppFormReqPrintXsltPathKey]);
            }
        }
        /// <summary>
        /// 获取档案字段描述配置文件。
        /// </summary>
        private XmlDocument StaffFieldDescConfigFile
        {
            get
            {
                string path = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "\\" + this[ModuleConfigurationKeys.StaffFieldDescConfigFileKey]);
                if (File.Exists(path))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    return doc;
                }
                return null;
            }
        }
        #endregion

        #region 记录。
        private static Hashtable STAFF_FIELDS_CACHE = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public string LoadStaffFieldDesc(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName)) return fieldName;
            string desc = STAFF_FIELDS_CACHE[fieldName] as string;
            if (string.IsNullOrEmpty(desc))
            {
                XmlDocument doc = this.StaffFieldDescConfigFile;
                if (doc == null) return string.Empty;
                XmlNode node = doc.SelectSingleNode(string.Format("//field[@column='{0}']/@desc", fieldName));
                if (node != null && node is XmlAttribute)
                {
                    desc = ((XmlAttribute)node).Value;
                    if (!string.IsNullOrEmpty(desc)) STAFF_FIELDS_CACHE[fieldName] = desc;
                }
            }
            return desc;
        }
        #endregion
    }
}