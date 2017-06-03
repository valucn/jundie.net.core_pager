﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace jundie.net.core_pager
{
    public static class PagerExtensions
    {
        //public static HtmlPager Pager(this IHtmlHelper helper, IPagedList pagedList, Func<int, string> generatePageUrl, string, prev_page_text = "上一页", string next_page_text = "下一页")
        //{
        //    TagBuilder ul = new TagBuilder("ul");
        //    ul.AddCssClass("pagination");
        //    ul = CompleteUlBefore(ul, pagedList, generatePageUrl, prev_page_text);
        //    for (int i = 1; i <= pagedList.TotalPageCount; i++)
        //    {
        //        string temp = generatePageUrl(i);
        //        ul.InnerHtml.AppendHtml(GenerateItem(temp, i, list.CurrentPageIndex));
        //    }
        //    ul = CompleteUlAfter(ul, list, generatePageUrl, next_page_text);
        //    return ul;
        //}

        public static IHtmlContent PagedListPager(this IHtmlHelper html,
                                                   IPageList list,
                                                   Func<int, string> generatePageUrl,
                                                   string prev_page_text = "上一页",
                                                   string next_page_text = "下一页")
        {

            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            ul = CompleteUlBefore(ul, list, generatePageUrl, prev_page_text);
            for (int i = 1; i <= list.TotalPageCount; i++)
            {
                string temp = generatePageUrl(i);
                ul.InnerHtml.AppendHtml(GenerateItem(temp, i, list.CurrentPageIndex));
            }
            ul = CompleteUlAfter(ul, list, generatePageUrl, next_page_text);
            return ul;
        }

        public static IHtmlContent PagedListPager_mobile(this IHtmlHelper html,
                                                   IPageList list,
                                                   Func<int, string> generatePageUrl,
                                                   string prev_page_text = "上一页",
                                                   string next_page_text = "下一页")
        {

            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            ul = CompleteUlBefore(ul, list, generatePageUrl, prev_page_text);
            for (int i = 1; i <= list.TotalPageCount; i++)
            {
                string temp = generatePageUrl(i);
                ul.InnerHtml.AppendHtml(GenerateItem(temp, i, list.CurrentPageIndex));
            }
            ul = CompleteUlAfter(ul, list, generatePageUrl, next_page_text);
            return ul;
        }

        public static TagBuilder GenerateItem(string href, int page, int index)
        {
            TagBuilder link = new TagBuilder("a");
            link.Attributes["href"] = href;
            link.InnerHtml.SetContent(page.ToString());
            TagBuilder li = new TagBuilder("li");
            if (page == index)
            {
                li.AddCssClass("active");
            }
            li.InnerHtml.SetHtmlContent(link);
            return li;
        }

        public static TagBuilder CompleteUlBefore(TagBuilder ul, IPageList list, Func<int, string> generatePageUrl, string prev_page_text = "上一页")
        {
            if (list.TotalPageCount >= list.CurrentPageIndex && list.CurrentPageIndex > 1)
            {
                TagBuilder nextLi = new TagBuilder("li");
                TagBuilder LastA = new TagBuilder("a");
                LastA.Attributes["href"] = generatePageUrl(list.CurrentPageIndex - 1);
                LastA.InnerHtml.SetContent(prev_page_text);
                nextLi.InnerHtml.SetHtmlContent(LastA);
                ul.InnerHtml.AppendHtml(nextLi);
            }
            return ul;
        }

        public static TagBuilder CompleteUlAfter(TagBuilder ul, IPageList list, Func<int, string> generatePageUrl, string next_page_text = "下一页")
        {
            if (list.TotalPageCount > list.CurrentPageIndex && list.CurrentPageIndex >= 1)
            {
                TagBuilder nextLi = new TagBuilder("li");
                TagBuilder nextA = new TagBuilder("a");
                nextA.Attributes["href"] = generatePageUrl(list.CurrentPageIndex + 1);
                nextA.InnerHtml.SetContent(next_page_text);
                nextLi.InnerHtml.SetHtmlContent(nextA);
                ul.InnerHtml.AppendHtml(nextLi);
            }
            return ul;
        }
    }
}