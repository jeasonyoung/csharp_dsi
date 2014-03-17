//================================================================================
//  FileName: AccessoriesDownload.ashx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/7/25
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
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

using Yaesoft.DSI.Engine.Service;
namespace Yaesoft.DSI.Web
{
    /// <summary>
    /// 附件下载。
    /// </summary>
    public class AccessoriesDownload : IHttpHandler, IRequiresSessionState
    {
        #region IHttpHandler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            string fileId = context.Request["FileID"];
            string strType = context.Request["type"];
            string cache = context.Request["cache"];
            if (!string.IsNullOrEmpty(fileId))
            {
                int type = 0;
                if (!string.IsNullOrEmpty(strType))
                {
                    try { type = int.Parse(strType.Trim()); }
                    catch { }
                }
                this.Download(context.Response, fileId, type, cache);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resp"></param>
        /// <param name="fileID"></param>
        /// <param name="type"></param>
        /// <param name="cache"></param>
        private void Download(HttpResponse resp, string fileId, int type, string cache)
        {
            lock (this)
            {
                if (resp != null)
                {
                    byte[] data = null;
                    string name = null, contentType = null;
                    if (string.IsNullOrEmpty(cache))
                        data = DSIAttachmentPresenter<object>.Download(fileId, out name, out contentType);
                    else
                    {
                        string key = string.Format("{0}-{1}", fileId, cache);
                        data = HttpContext.Current.Session[key] as byte[];
                    }
                    if (data == null || data.Length == 0)return;
                    switch (type)
                    {
                        case 0:
                        default:
                            {
                                if (string.IsNullOrEmpty(contentType)) contentType = "application/octet-stream";
                                //下载文件。
                                resp.Buffer = true;
                                resp.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(name, System.Text.Encoding.UTF8));
                                resp.ContentEncoding = Encoding.GetEncoding("gb2312");//设置输出流为简体中文
                                resp.ContentType = contentType;
                                resp.BinaryWrite(data);
                                resp.Flush();
                                resp.End();
                            }
                            break;
                        case 1:
                            {
                                //图片。
                                using (MemoryStream ms = new MemoryStream(data))
                                {
                                    ms.Position = 0;
                                    using (Bitmap bitmap = new Bitmap(ms))
                                    {
                                        bitmap.Save(resp.OutputStream, ImageFormat.Jpeg); 
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }
        #endregion
    }
}