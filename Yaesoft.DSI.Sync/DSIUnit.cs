//================================================================================
// FileName: DSIUnit.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
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
	
using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.DSI.Sync
{
	///<summary>
	///tblDSIUnit映射类。
	///</summary>
	[DbTable("tblDSIUnit")]
	public class DSIUnit
	{
		#region 属性。
		///<summary>
		///获取或设置UnitID。
		///</summary>
        [DbField("UnitID", DbFieldUsage.PrimaryKey)]
        public string UnitID { get; set; }
		///<summary>
		///获取或设置UnitCode。
		///</summary>
        [DbField("UnitCode")]
        public string UnitCode { get; set; }
		///<summary>
		///获取或设置UnitName。
		///</summary>
        [DbField("UnitName")]
        public string UnitName { get; set; }
		#endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("单位ID:{0},单位代码:{1},单位名称:{2}", this.UnitID, this.UnitCode, this.UnitName);
        }
        #endregion
    }
}