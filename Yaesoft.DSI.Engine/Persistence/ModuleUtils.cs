//================================================================================
//  FileName: ModuleUtils.cs
//  Desc:模块工具类。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/1
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
using System.IO;
using System.IO.Compression;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Xml;
using iPower.Utility;
using Yaesoft.DSI.Engine.Domain;
using System.Reflection;
using iPower.Data.ORM;
namespace Yaesoft.DSI.Engine.Persistence
{
    /// <summary>
    /// 模块工具类。
    /// </summary>
    public static class ModuleUtils
    {
        /// <summary>
        /// 将Xml/Xslt转化为Html。
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="xsltPath"></param>
        /// <returns></returns>
        public static string XmlAndXsltToHtml(XmlDocument doc, string xsltPath)
        {
            string html = string.Empty;
            if (doc != null && File.Exists(xsltPath))
            {
                using (FileStream fs = new FileStream(xsltPath, FileMode.Open, FileAccess.Read))
                {
                    html = XmlTools.XmlAndXsltToHtml(doc, fs);
                }
            }
            return html;
        }
        /// <summary>
        /// 将流数据转换成Byte数组。
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] StreamToRaw(Stream stream)
        {
            byte[] raw = null;
            if (stream != null && stream.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] buffer = new byte[1024];
                    int len = 0;
                    while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, len);
                    }
                    raw = ms.ToArray();
                }
            }
            return raw;
        }
        /// <summary>
        ///  裁剪按比例图片并将其转换为字节数组。
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="imgFormat"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static byte[] CutUploadImageToArray(Stream stream, ImageFormat imgFormat, int w, int h)
        {
            byte[] output = null;
            if (stream != null && stream.Length > 0)
            {
                using (Bitmap bitmap = new Bitmap(stream))
                {
                    Image result = ImageHelper.MakeThumbnail(bitmap, w, h, "CUT");
                    if (result != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            result.Save(ms, imgFormat);
                            output = ms.ToArray();
                        }
                    }
                }
            }
            return output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ignoreNames"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T Assignment<T>(DataRow row, string[] ignoreNames)
        {
            T data = default(T);
            if (row != null)
            {
                data = Activator.CreateInstance<T>();
                Type t = typeof(T);
                foreach (PropertyInfo tp in t.GetProperties())
                {
                    if (ignoreNames != null && ignoreNames.Length > 0 && IsIgnore(ignoreNames, tp.Name)) continue;
                    if (tp != null && tp.CanWrite)
                    {
                        object value = row[tp.Name];
                        if (value != null) tp.SetValue(data, value, null);
                    }
                }
            }
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ignoreNames"></param>
        /// <param name="handler"></param>
        public static void CopyPropertyValue(object source, string[] ignoreNames, CopyPropertyHandler handler)
        {
            if (source == null || handler == null) return;
            Type s = source.GetType();
            foreach (PropertyInfo sp in s.GetProperties())
            {
                if (ignoreNames != null && ignoreNames.Length > 0 && IsIgnore(ignoreNames, sp.Name)) continue;
                object[] customs = sp.GetCustomAttributes(typeof(DbFieldAttribute), false);
                if (customs != null && customs.Length > 0 && sp.CanRead)
                {
                    handler(sp.Name, string.Format("{0}", sp.GetValue(source, null)));
                }
            }
        }
        /// <summary>
        /// 比较对象属性值。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="ignoreNames"></param>
        /// <param name="handler"></param>
        public static void ComparePropertyValue(object source, object target,string[] ignoreNames, ComparePropertyHandler handler)
        {
            if (source == null || target == null || handler == null) return;
            Type s = source.GetType(), t = target.GetType();
            foreach (PropertyInfo tp in t.GetProperties())
            {
                if (ignoreNames != null && ignoreNames.Length > 0 && IsIgnore(ignoreNames, tp.Name)) continue;
                object[] customs = tp.GetCustomAttributes(typeof(DbFieldAttribute), false);
                if ( customs != null && customs.Length > 0 && tp.CanRead)
                {
                    PropertyInfo sp = s.GetProperty(tp.Name);
                    if (tp == null || !tp.CanRead) continue;
                    string sourceValue = string.Format("{0}", sp.GetValue(source, null)), targetValue = string.Format("{0}", tp.GetValue(target, null));
                    if (!string.Equals(sourceValue, targetValue, StringComparison.InvariantCultureIgnoreCase))
                    {
                        handler(tp.Name, sourceValue, targetValue);
                    }
                }
            }
        }
        /// <summary>
        /// 是否忽略。
        /// </summary>
        /// <param name="ignoreNames"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
        private static bool IsIgnore(string[] ignoreNames, string colName)
        {
            if (ignoreNames != null && ignoreNames.Length > 0 && !string.IsNullOrEmpty(colName))
            {
                bool result = Array.Exists<String>(ignoreNames, new Predicate<string>(delegate(string v)
                {
                    return string.Equals(v, colName, StringComparison.InvariantCultureIgnoreCase);
                }));
                return result;
            }
            return false;
        }
    }
}