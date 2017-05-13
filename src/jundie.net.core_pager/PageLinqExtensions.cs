using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jundie.net.core_pager
{
    public static class PageLinqExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> allItems, int pageIndex, int pageSize)
        {
            return allItems.AsQueryable().ToPagedList(pageIndex, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> allItems, int pageIndex, int pageSize)
        {
            PagedList<T> data = new PagedList<T>();
            if (allItems.Count() % pageSize == 0)
            {
                data.TotalPageCount = allItems.Count() / pageSize;
            }
            else
            {
                data.TotalPageCount = allItems.Count() / pageSize + 1;
            }
            data.CurrentPageIndex = pageIndex;
            data.PageSize = pageSize;
            data.TotalItemCount = allItems.Count();
            data.CurrentPageIndex = pageIndex;
            data.PageListData = allItems.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return data;
            //if (pageIndex < 1)
            //    pageIndex = 1;
            //var itemIndex = (pageIndex - 1) * pageSize;
            //var totalItemCount = allItems.Count();
            //while (totalItemCount <= itemIndex && pageIndex > 1)
            //{
            //    itemIndex = (--pageIndex - 1) * pageSize;
            //}
            //var pageOfItems = allItems.Skip(itemIndex).Take(pageSize);
            //return new PagedList<T>(pageOfItems, pageIndex, pageSize, totalItemCount);
        }
    }
}
