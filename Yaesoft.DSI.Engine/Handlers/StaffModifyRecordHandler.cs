//================================================================================
//  FileName: StaffModifyRecordHandler.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-8
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
using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
namespace Yaesoft.DSI.Engine.Handlers
{
    /// <summary>
    /// 职工档案修改记录Handler.
    /// </summary>
    public class StaffModifyRecordHandler : BaseHandler<DSIStaffModifyRecord>
    {
        #region 成员变量，构造函数。
        private DbModuleEntity<DSIStaffModifyRecord> staffModifyRecordEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public StaffModifyRecordHandler()
        {
            this.staffModifyRecordEntity = new DbModuleEntity<DSIStaffModifyRecord>();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        protected override object Handler(DSIStaffModifyRecord req)
        {
            CallbackDataGrid<DSIStaffModifyRecord> callback = new CallbackDataGrid<DSIStaffModifyRecord>();
            string order = "CreateTime desc";
            if (!string.IsNullOrEmpty(req.sort) && !string.IsNullOrEmpty(req.order))
            {
                order = req.sort + " " + req.order;
            }
            DataTable dtSource = this.staffModifyRecordEntity.GetAllRecord(string.Format("StaffID = '{0}'", req.StaffID), order);
            int index = 0, rows = req.rows, startIndex = (req.page - 1) * rows;
            callback.total = dtSource.Rows.Count;
            List<DSIStaffModifyRecord> list = null;
            if (rows > 0)
            {
                DataTable dt = dtSource.Clone();
                for (int i = 0; i < callback.total; i++)
                {
                    if (index > rows) break;
                    if (i >= startIndex)
                    {
                        dt.ImportRow(dtSource.Rows[i]);
                        index++;
                    }
                }
                list = this.staffModifyRecordEntity.ConvertDataSource(dt);
            }
            if (list == null) list = this.staffModifyRecordEntity.ConvertDataSource(dtSource);
            callback.rows = list;
            return callback;
        }
    }
}