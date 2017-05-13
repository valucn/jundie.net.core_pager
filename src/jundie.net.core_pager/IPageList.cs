using System;
using System.Collections.Generic;
using System.Text;

namespace jundie.net.core_pager
{
    public interface IPageList
    {
        int TotalPageCount { get; set; }

        int TotalItemCount { get; set; }

        int CurrentPageIndex { get; set; }

        int PageSize { get; set; }
    }
}
