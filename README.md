骏蝶 asp.net core 分页系统 Ver1.0.2
<h3>View：</h3>
<div style="padding: 6px;border: #CCC 1px solid;background-color: #F8F8F8;">
	<pre>
@addTagHelper &quot;*, jundie.net.core_pager&quot;
@model IEnumerable&lt;jundie.net.core_pager.demo_cn.models.article&gt;
@{
    ViewData[&quot;Title&quot;] = &quot;分页示例&quot;;
    ViewData[&quot;menu_demo&quot;] = &quot;active&quot;;
    var pagerOption = ViewData[&quot;pagerOption&quot;] as jundie.net.core_pager.PagerOptions;
}
&lt;h3&gt;@ViewData[&quot;Message&quot;]&lt;/h3&gt;
&lt;div class=&quot;panel panel-default&quot;&gt;
    &lt;!-- Default panel contents --&gt;
    &lt;div class=&quot;panel-heading&quot;&gt;
    	@ViewData[&quot;Title&quot;] (@pagerOption.Total)
    &lt;/div&gt;
    &lt;!-- Table --&gt;
    &lt;table class=&quot;table table-striped table-bordered&quot;&gt;
        &lt;thead&gt;
            &lt;tr&gt;
                &lt;th&gt;@Html.DisplayNameFor(model =&gt; model.Title)&lt;/th&gt;
                &lt;th&gt;@Html.DisplayNameFor(model =&gt; model.Author)&lt;/th&gt;
                &lt;th&gt;@Html.DisplayNameFor(model =&gt; model.Source)&lt;/th&gt;
            &lt;/tr&gt;
        &lt;/thead&gt;
        &lt;tbody&gt;
        @foreach (var item in Model)
        {
            &lt;tr&gt;
                &lt;td&gt;@item.Title&lt;/td&gt;
                &lt;td&gt;@item.Author&lt;/td&gt;
                &lt;td&gt;@item.Source&lt;/td&gt;
            &lt;/tr&gt;
        }
        &lt;/tbody&gt;
    &lt;/table&gt;
&lt;/div&gt;
&lt;pager pager-option=&quot;pagerOption&quot;&gt;&lt;/pager&gt;
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