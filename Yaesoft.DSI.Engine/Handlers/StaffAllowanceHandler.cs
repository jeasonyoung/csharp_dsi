//================================================================================
//  FileName: StaffAllowanceHandler.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-22
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

using iPower.Paging;
using iPower.Platform.Engine.Persistence;

using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
namespace Yaesoft.DSI.Engine.Handlers
{
    /// <summary>
    /// 教职工补助Handler.
    /// </summary>
    public class StaffAllowanceHandler : BaseHandler<StaffPaging>
    {
        #region 成员变量，构造函数。
        private CommonEnumsEntity<ModuleConfiguration> commEnumsEntity;
        private DSIStaffAppFormReqEntity staffAppFormReqEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public StaffAllowanceHandler()
        {
            this.commEnumsEntity = new CommonEnumsEntity<ModuleConfiguration>(new ModuleConfiguration());
            this.staffAppFormReqEntity = new DSIStaffAppFormReqEntity();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        protected override object Handler(StaffPaging req)
        {
            CallbackDataGrid<Allowance> callback = new CallbackDataGrid<Allowance>();
            DataTable dtSource = this.staffAppFormReqEntity.StaffAllowanceListDataSource(req.StaffID);
            string order = null;
            if (!string.IsNullOrEmpty(req.sort) && !string.IsNullOrEmpty(req.order))
            {
                order = req.sort + " " + req.order;
            }
            callback.rows = new List<Allowance>();
            DataRow[] drs = dtSource.Select(string.Empty, order);
            if (drs != null && (callback.total = drs.Length) > 0)
            {
                int index = 0, rows = req.rows, startIndex = (req.page - 1) * rows;
                string[] ignores = new string[] { "GenderName" };
                List<Allowance> list = null;
                if (rows > 0)
                {
                    list = new List<Allowance>();
                    for (int i = 0; i < callback.total; i++)
                    {
                        if (index > rows) break;
                        if (i >= startIndex)
                        {
                            Allowance data = ModuleUtils.Assignment<Allowance>(drs[i], ignores);
                            data.GenderName =  this.commEnumsEntity.GetEnumMemberName(typeof(EnumGender), int.Parse(string.Format("{0}", drs[i]["Gender"])));
                            list.Add(data);
                            index++;
                        }
                    }
                }
                if (list == null)
                {
                    list = this.convertAssignment(drs, ignores);
                }
                callback.rows = list;
            }
            return callback;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="drs"></param>
        /// <param name="ignores"></param>
        /// <returns></returns>
        private List<Allowance> convertAssignment(DataRow[] drs, string[] ignores)
        {
            if (drs == null || drs.Length == 0) return null;
            List<Allowance> list = new List<Allowance>();
            for (int i = 0; i < drs.Length; i++)
            {
                Allowance data = ModuleUtils.Assignment<Allowance>(drs[i], ignores);
                data.GenderName = this.commEnumsEntity.GetEnumMemberName(typeof(EnumGender), int.Parse(string.Format("{0}", drs[i]["Gender"])));
                list.Add(data);
            }
            return list;
        }
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public class StaffPaging : ReqPaging
    {
        /// <summary>
        /// 
        /// </summary>
        public string StaffID { get; set; }
    }
}