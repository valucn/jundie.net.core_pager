using System;
using System.Collections.Generic;
using System.Text;

namespace jundie.net.core_pager
{
    /// <summary>
    /// 分页控件相关选项
    /// </summary>
    public class PagerOptions
    {
        /// <summary>
        /// 当前页  必传
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 总条数  必传
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 分页记录数（每页条数 默认每页15条）
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 路由地址(格式如：/Controller/Action) 默认自动获取
        /// </summary>
        public string RouteUrl { get; set; }

        /// <summary>
        /// 样式 默认 bootstrap样式 1
        /// </summary>
        public int StyleNum { get; set; }

        /// <summary>
        /// 获取或设置路由Url中页索引参数的名称
        /// </summary>
        public string PageIndexParameterName { get; set; }

        /// <summary>
        /// 获取或设置数字页索引分页按钮数目
        /// </summary>
        public int NumericPagerItemCount { get; set; }
    }
}
