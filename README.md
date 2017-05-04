骏蝶 asp.net core 分页系统 Ver1.0.2
<h3>View：</h3>
<div style="padding: 6px;border: #CCC 1px solid;background-color: #F8F8F8;">
	<pre>
@addTagHelper "*, jundie.net.core_pager"
@model IEnumerable<jundie.net.core_pager.demo_cn.models.article>
@{
    ViewData["Title"] = "分页示例";
    ViewData["menu_demo"] = "active";
    var pagerOption = ViewData["pagerOption"] as jundie.net.core_pager.PagerOptions;
}
<h3>@ViewData["Message"]</h3>
<div class="panel panel-default">
    <!-- Default panel contents -->
    <div class="panel-heading">
        @ViewData["Title"] (@pagerOption.Total)
    </div>
    <!-- Table -->
    <table class="table table-striped table-bordered">
        <thead>
            <tr>
                <th>@Html.DisplayNameFor(model => model.Title)</th>
                <th>@Html.DisplayNameFor(model => model.Author)</th>
                <th>@Html.DisplayNameFor(model => model.Source)</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var item in Model)
            {
                <tr>
                    <td>@item.Title</td>
                    <td>@item.Author</td>
                    <td>@item.Source</td>
                </tr>
            }
        </tbody>
    </table>
</div>
<pager pager-option="pagerOption"></pager>
	</pre>
</div>
<h3>Controller:</h3>
<div style="padding: 6px;border: #CCC 1px solid;background-color: #F8F8F8;">
	<pre>
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
	</pre>
</div>