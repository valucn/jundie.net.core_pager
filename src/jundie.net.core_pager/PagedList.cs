using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jundie.net.core_pager
{
    //public class PagedList<T> : List<T>, IPagedList<T>
    public class PagedList<T> : List<T>, IPageList
    {
        //public PagedList(IQueryable<T> currentPageItems, int pageIndex, int pageSize, int totalItemCount)
        //{
        //    AddRange(currentPageItems);
        //    TotalItemCount = totalItemCount;
        //    CurrentPageIndex = pageIndex;
        //    PageSize = pageSize;
        //}

        public int CurrentPageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalItemCount { get; set; }

        public int TotalPageCount { get; set; }

        public int StartItemIndex { get { return (CurrentPageIndex - 1) * PageSize + 1; } }

        public int EndItemIndex { get { return TotalItemCount > CurrentPageIndex * PageSize ? CurrentPageIndex * PageSize : TotalItemCount; } }

        public IEnumerable<T> PageListData { set; get; }
    }
}
