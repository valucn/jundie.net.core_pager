using System;
using System.Collections.Generic;
using System.Text;

namespace jundie.net.core_pager
{
    public class PagedList<T> : IPageList
    {
        public int PageCount { get; set; }

        public int TotalItemCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<T> PageListData { set; get; }
    }
}
