//================================================================================
//  FileName: OrgFactory.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/3
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
using System.Data;
using iPower;
using iPower.IRMP.Org;

using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
namespace Yaesoft.DSI.Engine
{
    /// <summary>
    /// 用户信息工厂。
    /// </summary>
    public class OrgFactory : IOrgFactory
    {
        #region 成员变量，构造函数。
        DSIUnitEntity unitEntity = null;
        DSIEmployeeEntity employeeEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public OrgFactory()
        {
            this.unitEntity = new DSIUnitEntity();
            this.employeeEntity = new DSIEmployeeEntity();
        }
        #endregion

        #region IOrgFactory 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OrgDepartmentCollection GetAllDepartment(string departmentID)
        {
            return this.unitEntity.GetAllDepartment(departmentID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OrgEmployeeCollection GetAllEmployee(string employeeID)
        {
            return this.employeeEntity.GetAllEmployee(employeeID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OrgPostCollection GetAllPost(string postID)
        {
            return new OrgPostCollection();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OrgRankCollection GetAllRank(string rankID)
        {
            return new OrgRankCollection();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public OrgDepartmentCollection GetSubCharge(string employeeID)
        {
            return this.unitEntity.GetSubCharge(employeeID);
        }
        #endregion
    }
}