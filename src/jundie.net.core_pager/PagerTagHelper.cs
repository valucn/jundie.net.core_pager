﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace jundie.net.core_pager
{
    [HtmlTargetElement("V6-pager")]
    public class PagerTagHelper : TagHelper
    {
        public PagerOptions PagerOption { get; set; }

        /// <summary>
        /// tag id
        /// </summary>
        [HtmlAttributeName("id")]
        public string tag_id { get; set; }

        /// <summary>
        /// tag名称
        /// </summary>
        [HtmlAttributeName("tag-name")]
        public string tag_name { get; set; } = "ul";

        /// <summary>
        /// tag样式名称
        /// </summary>
        [HtmlAttributeName("tag-class-name")]
        public string tag_class_name { get; set; } = "pagination";

        /// <summary>
        /// 分类参数
        /// </summary>
        [HtmlAttributeName("page-index-parameter-name")]
        public string page_name { get; set; } = "page";

        /// <summary>
        /// 当前页模板
        /// </summary>
        [HtmlAttributeName("current-pager-item-template")]
        public string current_item { get; set; } = "<li class=\"page-item active\"><a class=\"page-link\" href=\"javascript:void(0);\">{0}</a></li>";

        IUrlHelper url;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";

            if (PagerOption.PageSize <= 0)
            {
                PagerOption.PageSize = 15;
            }
            if (PagerOption.CurrentPage <= 0)
            {
                PagerOption.CurrentPage = 1;
            }
            if (PagerOption.Total <= 0) { return; }
            if (PagerOption.PageIndexParameterName == "")
            {
                PagerOption.PageIndexParameterName = "page";
            }
            if (PagerOption.NumericPagerItemCount <= 0)
            {
                PagerOption.NumericPagerItemCount = 10;
            }

            //总页数
            var totalPage = PagerOption.Total / PagerOption.PageSize + (PagerOption.Total % PagerOption.PageSize > 0 ? 1 : 0);
            if (totalPage <= 0) { return; }

            //当前路由地址
            if (string.IsNullOrEmpty(PagerOption.RouteUrl))
            {
                //PagerOption.RouteUrl = helper.ViewContext.HttpContext.Request.RawUrl;
                if (!string.IsNullOrEmpty(PagerOption.RouteUrl))
                {

                    var lastIndex = PagerOption.RouteUrl.LastIndexOf("/");
                    PagerOption.RouteUrl = PagerOption.RouteUrl.Substring(0, lastIndex);
                }
            }
            PagerOption.RouteUrl = PagerOption.RouteUrl.TrimEnd('/');

            //构造分页样式
            var sbPage = new StringBuilder(string.Empty);
            switch (PagerOption.StyleNum)
            {
                case 2:
                    {
                        break;
                    }
                default:
                    {
                        #region 默认样式
                        string para_connect = "?";
                        if (PagerOption.RouteUrl.IndexOf("?") != -1)
                        {
                            para_connect = "&";
                        }
                        sbPage.Append("\r\n<!-- pager start -->\r\n");
                        sbPage.Append($"    <{tag_name} id=\"{tag_id}\" class=\"{tag_class_name}\">\r\n");
                        sbPage.AppendFormat("        <li><a href=\"{0}{2}{3}={1}\" aria-label=\"Previous\"><span aria-hidden=\"true\">&laquo;</span></a></li>\r\n",
                                                PagerOption.RouteUrl,
                                                PagerOption.CurrentPage - 1 <= 0 ? 1 : PagerOption.CurrentPage - 1,
                                                para_connect,
                                                page_name);

                        int for_start = PagerOption.CurrentPage - PagerOption.NumericPagerItemCount / 2;//4
                        int cha = 1 - for_start - 1;
                        if (for_start < 1)
                        {
                            for_start = 1;
                        }
                        int for_end = PagerOption.CurrentPage + PagerOption.NumericPagerItemCount / 2 - 1;
                        if (PagerOption.CurrentPage <= PagerOption.NumericPagerItemCount / 2)
                        {
                            for_end = PagerOption.NumericPagerItemCount;
                        }
                        if (for_end > totalPage)
                        {
                            for_end = totalPage;
                        }
                        for (int i = for_start; i <= for_end; i++)
                        {
                            if (i == PagerOption.CurrentPage)
                            {
                                sbPage.AppendFormat($"        {current_item}\r\n",
                                    i,
                                    i == PagerOption.CurrentPage ? "class=\"active\"" : "",
                                    PagerOption.RouteUrl,
                                    para_connect,
                                    page_name);
                            }
                            else
                            {
                                //url.Action();
                                sbPage.AppendFormat("        <li><a href=\"{2}{3}{4}={0}\">{0}</a></li>\r\n",
                                    i,
                                    "",
                                    PagerOption.RouteUrl,
                                    para_connect,
                                    page_name);
                            }
                        }

                        sbPage.Append("        <li>\r\n");
                        sbPage.AppendFormat("            <a href=\"{0}{2}{3}={1}\" aria-label=\"Next\">\r\n",
                                            PagerOption.RouteUrl,
                                            PagerOption.CurrentPage + 1 > totalPage ? PagerOption.CurrentPage : PagerOption.CurrentPage + 1,
                                            para_connect,
                                            page_name);
                        sbPage.Append("                <span aria-hidden=\"true\">&raquo;</span>\r\n");
                        sbPage.Append("            </a>\r\n");
                        sbPage.Append("        </li>\r\n");
                        sbPage.Append($"    </{tag_name}>\r\n");
                        sbPage.Append("<!--// pager end, Copy right 2017 Jundie.net -->\r\n");
                        #endregion
                    }
                    break;
            }

            output.Content.SetHtmlContent(sbPage.ToString());
        }
    }
}
