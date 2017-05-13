using System;
using System.Collections.Generic;
using System.Text;

namespace jundie.net.core_pager
{
    public interface IPageList
    {
        int PageCount { get; set; }

        int TotalItemCount { get; set; }

        int PageNumber { get; set; }

        int PageSize { get; set; }
    }
}
