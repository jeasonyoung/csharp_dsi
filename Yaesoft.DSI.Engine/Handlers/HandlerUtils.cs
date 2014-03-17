//================================================================================
//  FileName: HandlerUtils.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-9
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
using System.Web;
using System.Reflection;
using iPower.Paging;
namespace Yaesoft.DSI.Engine.Handlers
{
    /// <summary>
    /// 请求处理工具类。
    /// </summary>
    public static class HandlerUtils
    {
        /// <summary>
        /// 分页请求。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static T ReqPaging<T>(HttpRequest request)
            where T : IReqPaging
        {
            T result = Activator.CreateInstance<T>();
            Type t = typeof(T);
            foreach (PropertyInfo p in t.GetProperties())
            {
                if (p.CanWrite)
                {
                    string value = request[p.Name];
                    if (!string.IsNullOrEmpty(value))
                    {
                        object obj = convertValue(p.PropertyType, value);
                        p.SetValue(result, obj, null);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static object convertValue(Type type, string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            if (type == typeof(string)) return value;
            if (type == typeof(Int32)) return Int32.Parse(value);
            if (type == typeof(float)) return float.Parse(value);
            if (type == typeof(bool)) return bool.Parse(value);
            if (type == typeof(DateTime)) return DateTime.Parse(value);
            return value;
        }
    }
}