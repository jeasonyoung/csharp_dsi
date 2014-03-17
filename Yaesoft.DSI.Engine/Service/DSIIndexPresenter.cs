//================================================================================
//  FileName: DSIIndexPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-26
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

using Yaesoft.DSI.Engine.Domain;
using Yaesoft.DSI.Engine.Persistence;
using iPower.IRMP.SysMgr.Engine.Service;
namespace Yaesoft.DSI.Engine.Service
{
    /// <summary>
    /// 首页视图接口。
    /// </summary>
    public interface IDSIIndexView : IModuleView, ILoginView
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="indicators"></param>
        void RenderCarouselIndicators(string[] indicators);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        void RenderItems(string[] items);
    }
    /// <summary>
    /// 首页行为类。
    /// </summary>
    public class DSIIndexPresenter : ModulePresenter<IDSIIndexView>
    {
        #region 成员变量，构造函数。
        private DSIProjectEntity projectEntity;
        private SysMgrLoginPresenter presenter;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public DSIIndexPresenter(IDSIIndexView view)
            : base(view)
        {
            this.projectEntity = new DSIProjectEntity();
            this.presenter = new SysMgrLoginPresenter(this.View);
        }
        #endregion

        #region 函数处理。
        /// <summary>
        /// 
        /// </summary>
        public void Login()
        {
            try
            {
                this.presenter.Login();
            }
            catch (Exception e)
            {
                this.View.ShowMessage(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadEntityData()
        {
            IDSIIndexView indexView = this.View as IDSIIndexView;
            if (indexView != null)
            {
                
                List<DSIProject> list = this.projectEntity.LoadProjects(3, true);
                if (list != null && list.Count > 0)
                {
                    DateTime now = DateTime.Now;
                    List<string> indicators = new List<string>(), items = new List<string>();

                    #region 数据处理。
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] != null)
                        {

                            StringBuilder li = new StringBuilder(string.Format("<li data-target=\"#myCarousel\" data-slide-to=\"{0}\"", i)),
                                          item = new StringBuilder("<div class=\"item");
                            bool isActive = false;
                            if (now > list[i].StartTime && now < list[i].EndTime)
                            {
                                isActive = true;
                                li.Append(" class=\"active\" ");
                                item.Append(" active");
                            }
                            li.Append("></li>");
                            item.Append("\">");
                            item.Append("<div class=\"container\">");
                            item.Append("<div class=\"carousel-caption\">");
                            item.AppendFormat("<h1>{0}</h1>", list[i].ProjectName);
                            item.AppendFormat("<p>{0}</p>", list[i].Content);
                            if (list[i].Attachments != null && list[i].Attachments.Count > 0)
                            {
                                item.Append("<p>");
                                //item.Append("<code>附件下载：</code>");
                                item.Append("<ul class=\"left list-inline\">");
                                item.Append("<li><code>附件下载</code></li>");
                                for (int j = 0; j < list[i].Attachments.Count; j++)
                                {
                                    item.Append("<li>");
                                    item.Append("<code>");
                                    item.AppendFormat("<a target=\"_blank\" href=\"AccessoriesDownload.ashx?FileID={0}\">{1}</a>", list[i].Attachments[j].ID, list[i].Attachments[j].Name);
                                    item.Append("</code>");
                                    item.Append("</li>");
                                }
                                item.Append("</ul>");
                                item.Append("</p>");
                            }
                            if (isActive)
                            {
                                item.AppendFormat(" <p><a class=\"btn btn-lg btn-primary\" href=\"frmDSIPersonalStaffAppFormReqList.aspx\" role=\"button\">申报个人补助</a></p>");
                            }
                            item.Append("</div>");
                            item.Append("</div>");
                            item.Append("</div>");
                            indicators.Add(li.ToString());
                            items.Add(item.ToString());
                        }
                    }
                    #endregion

                    string[] strIndicators = new string[indicators.Count], strItems = new string[items.Count];
                    indicators.CopyTo(strIndicators);
                    items.CopyTo(strItems);

                    indexView.RenderCarouselIndicators(strIndicators);
                    indexView.RenderItems(strItems);
                }
            }
        }
        #endregion
    }
}