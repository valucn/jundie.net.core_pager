using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jundie.net.core_pager
{
    public class PagedList<T> : IPageList
    {
        public PagedList(IEnumerable<T> allItems, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            var items = allItems as IList<T> ?? allItems.ToList();
            TotalItemCount = items.Count();
            CurrentPageIndex = pageIndex;
            //AddRange(items.Skip(StartItemIndex - 1).Take(pageSize));
        }

        public int PageCount { get; set; }

        public int TotalItemCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int CurrentPageIndex { get; set; }

        public int StartItemIndex { get { return (CurrentPageIndex - 1) * PageSize + 1; } }

        public IEnumerable<T> PageListData { set; get; }
    }
}
