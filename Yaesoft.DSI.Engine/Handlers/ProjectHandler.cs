//================================================================================
//  FileName: ProjectHandler.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-2-13
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

using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;

using Newtonsoft.Json;
namespace Yaesoft.DSI.Engine.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class ProjectHandler : IHttpHandler
    {
        #region 成员变量，构造函数。
        private DSIProjectEntity projectEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public ProjectHandler()
        {
            this.projectEntity = new DSIProjectEntity();
        }
        #endregion

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
            bool isView = false;
            string strIsView = context.Request["isview"];
            if (!string.IsNullOrEmpty(strIsView))
            {
                try
                {
                    isView = bool.Parse(strIsView);
                }
                catch (Exception) { }
            }
            List<DSIProject> list = this.projectEntity.LoadProjects(1, isView);
            string result = JsonConvert.SerializeObject(list);
            context.Response.Clear();
            context.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            context.Response.ContentType = "text/html;charset=utf-8";
            context.Response.Write(result);
            context.Response.Flush();
            context.Response.End();
        }

        #endregion
    }
}
