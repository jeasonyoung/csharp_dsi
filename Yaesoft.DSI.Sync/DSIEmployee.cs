//================================================================================
// FileName: DSIEmployee.cs
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
	
using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.DSI.Sync
{
	///<summary>
	///tblDSIEmployeeӳ���ࡣ
	///</summary>
	[DbTable("tblDSIEmployee")]
	internal class DSIEmployee
	{
		#region ���ԡ�
		///<summary>
		///��ȡ������EmployeeID��
		///</summary>
        [DbField("EmployeeID", DbFieldUsage.PrimaryKey)]
        public string EmployeeID { get; set; }
		///<summary>
		///��ȡ������EmployeeCode��
		///</summary>
        [DbField("EmployeeCode")]
        public string EmployeeCode { get; set; }
		///<summary>
		///��ȡ������EmployeeName��
		///</summary>
        [DbField("EmployeeName")]
        public string EmployeeName { get; set; }	
		#endregion

        #region ���ء�
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("��ʦID:{0},��ʦ����:{1},��ʦ����:{2}", this.EmployeeID, this.EmployeeCode, this.EmployeeName);
        }
        #endregion
    }
}