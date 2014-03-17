//================================================================================
// FileName: DSIPeopleEntity.cs
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
using System.Collections.Specialized;
using System.Text;
using System.Data;
	
using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.DSI.Engine.Domain;
namespace Yaesoft.DSI.Engine.Persistence
{
	///<summary>
	///DSIPeopleEntity实体类。
	///</summary>
    internal class DSIPeopleEntity : DbModuleEntity<DSIPeople>
    {
        /// <summary>
        /// 绑定民族数据。
        /// </summary>
        public IListControlsData BindPeopleData
        {
            get
            {
                return new ListControlsDataSource("PeopleName", "PeopleID", this.GetAllRecord("", "PeopleCode"));
            }
        }

        private static System.Collections.Hashtable cache = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable());
        /// <summary>
        /// 
        /// </summary>
        /// <param name="peopleId"></param>
        /// <returns></returns>
        public string LoadPeopleName(string peopleId)
        {
            if (string.IsNullOrEmpty(peopleId)) return string.Empty;
            string name = cache[peopleId] as string;
            if (string.IsNullOrEmpty(name))
            {
                DSIPeople data = new DSIPeople();
                data.PeopleID = peopleId;
                if (this.LoadRecord(ref data))
                {
                    name = data.PeopleName;
                    if (!string.IsNullOrEmpty(name)) cache[peopleId] = name;
                }
            }
            return name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PeopleName"></param>
        /// <returns></returns>
        public IListControlsData ListDataSource(string peopleName)
        {
            return new ListControlsDataSource("PeopleName", "PeopleID", this.GetAllRecord(string.Format("PeopleName like '%{0}%'", peopleName), "PeopleCode"));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="peopleID"></param>
        /// <returns></returns>
        public IListControlsData ListDataSource(GUIDEx peopleID)
        {
            return new ListControlsDataSource("PeopleName", "PeopleID", this.GetAllRecord(string.Format("PeopleID = '{0}'", peopleID), "PeopleCode"));
        }
    }
}