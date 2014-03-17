//================================================================================
//  FileName: BaseHandler.cs
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
using iPower.Paging;
namespace Yaesoft.DSI.Engine.Handlers
{
    /// <summary>
    /// 请求处理基础类。
    /// </summary>
    public abstract class BaseHandler<T> :IHttpHandler
        where T: IReqPaging
    {
        #region IHttpHandler 成员
        /// <summary>
        /// 
        /// </summary>
        public bool IsReusable
        {
            get { return false; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {

            T data = HandlerUtils.ReqPaging<T>(context.Request);
            object obj = Handler(data);

            string result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            context.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            context.Response.ContentType = "text/html;charset=utf-8";
            context.Response.Write(result);
            context.Response.Flush();
            context.Response.End();
        }
        #endregion

        /// <summary>
        /// 数据处理。
        /// </summary>
        /// <param name="req">请求数据。</param>
        /// <returns></returns>
        protected abstract object Handler(T req);
    }
}