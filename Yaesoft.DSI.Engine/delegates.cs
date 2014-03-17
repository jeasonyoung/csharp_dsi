//================================================================================
//  FileName: delegates.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-1
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

namespace Yaesoft.DSI.Engine
{
    /// <summary>
    /// 显示消息委托。
    /// </summary>
    /// <param name="message"></param>
    /// <param name="afterAlertScript"></param>
    public delegate void ShowMessageHandler(string message, string afterAlertScript);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fieldName"></param>
    /// <param name="sourceValue"></param>
    /// <param name="targetValue"></param>
    public delegate void ComparePropertyHandler(string fieldName,string sourceValue,string targetValue);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fieldName"></param>
    /// <param name="sourceValue"></param>
    public delegate void CopyPropertyHandler(string fieldName,string sourceValue);
}