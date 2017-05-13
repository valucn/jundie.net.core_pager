using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jundie.net.core_pager
{
    public static class PageHelper
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> superset, int pageNumber, int pageSize)
        {
            PagedList<T> data = new PagedList<T>();
            if (superset.Count() % pageSize == 0)
            {
                data.PageCount = superset.Count() / pageSize;
            }
            else
            {
                data.PageCount = superset.Count() / pageSize + 1;
            }
            data.PageNumber = pageNumber;
            data.PageSize = pageSize;
            data.TotalItemCount = superset.Count();
            data.PageListData = superset.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return data;
        }
    }
}
