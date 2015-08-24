using System;
using System.Collections.Generic;
using NewsAggr.Models;

namespace NewsAggr.HtmlParser
{
    interface IHtmlParser
    {
        List<Feed> GetAllFeeds(out Exception exception);
    }
}
