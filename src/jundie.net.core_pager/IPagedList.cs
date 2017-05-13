using System.Collections;
using System.Collections.Generic;

namespace jundie.net.core_pager
{
    public interface IPagedList : IEnumerable
    {
        int CurrentPageIndex { get; set; }

        int PageSize { get; set; }

        int TotalItemCount { get; set; }
    }

    public interface IPagedList<T> : IEnumerable<T>, IPagedList { }
}
