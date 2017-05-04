using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jundie.net.core_pager.demo_cn.models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jundie.net.core_pager.demo_cn.Controllers
{
    public class demoController : Controller
    {
        // GET: /<controller>/
        public IActionResult index(int page = 1)
        {
            var model = demo_data.AllArticles.OrderByDescending(m => m.PubDate);
            var pagerOption = new PagerOptions
            {
                CurrentPage = page,
                PageSize = 5,
                Total = model.Count(),
                RouteUrl = "/demo",
                PageIndexParameterName = "page"
            };
            ViewData["pagerOption"] = pagerOption;
            return View(model.Skip((pagerOption.CurrentPage - 1) * pagerOption.PageSize).Take(pagerOption.PageSize));
        }
    }
}
