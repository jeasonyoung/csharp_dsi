using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Yaesoft.DSI.Engine.Persistence;

namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDSIEduRptAllowanceDetailView : IDSIStaffAllowanceView
    {
        /// <summary>
        /// 获取单位ID。
        /// </summary>
        string UnitID { get; }
        /// <summary>
        /// 获取年度。
        /// </summary>
        string Year { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class DSIEduRptAllowanceDetailPresenter : DSIStaffAllowancePresenter
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        public DSIEduRptAllowanceDetailPresenter(IDSIEduRptAllowanceDetailView view)
            : base(view)
        {
        }
        #endregion

        #region 数据。
        /// <summary>
        /// 
        /// </summary>
        public override DataTable ListDataSource
        {
            get
            {
                IDSIEduRptAllowanceDetailView listView = this.View as IDSIEduRptAllowanceDetailView;
                if (listView != null)
                {
                    return this.EduRptAllowanceDetail(listView.UnitID, listView.Year);
                }
                return null;
            }
        }
        #endregion
    }
}