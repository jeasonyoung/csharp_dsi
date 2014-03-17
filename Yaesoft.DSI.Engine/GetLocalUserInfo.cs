//================================================================================
//  FileName: GetLocalUserInfo.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/12/29
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

using Yaesoft.SFIT;
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
namespace Yaesoft.DSI.Engine
{
    /// <summary>
    /// 获取本地用户信息。
    /// </summary>
    public class GetLocalUserInfo : IGetUserInfo
    {
        #region 成员变量，构造函数。
        DSIEmployeeEntity employeeEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public GetLocalUserInfo()
        {
            this.employeeEntity = new DSIEmployeeEntity();
        }
        #endregion

        #region IGetUserInfo 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="userCode"></param>
        /// <param name="employeeID"></param>
        /// <param name="employeeCode"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public bool GetUserInfo(int type, string userCode, out string employeeID, out string employeeCode, out string employeeName)
        {
            bool result = false;
            employeeID = employeeCode = employeeName = null;
            DSIEmployee data = this.employeeEntity.LoadRecord(userCode);
            if (data != null)
            {
                employeeID = data.EmployeeID;
                employeeCode = data.EmployeeCode;
                employeeName = data.EmployeeName;
                result = true;
            }
            return result;
        }
        #endregion
    }
}