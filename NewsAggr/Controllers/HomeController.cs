using System;
using System.Web.Mvc;
using NewsAggr.Models;
using NewsAggr.DAL.Repository;
using NewsAggr.HtmlParser;

namespace NewsAggr.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Parse(string url)
        {
            Exception exception = null;
            O57Parser parser = new O57Parser();

            Resource o57Resource = new Resource();
            
            o57Resource.Feeds = parser.GetAllFeeds(out exception);

            NewsAggregatorRepository<Feed> feedRepository = new NewsAggregatorRepository<Feed>();
            NewsAggregatorRepository<Resource> resourceRepository = new NewsAggregatorRepository<Resource>();

            foreach (Feed feed in o57Resource.Feeds)
            {
                feedRepository.Add(feed, out exception);
            }
            resourceRepository.Add(o57Resource, out exception);

            //ViewBag.Message = resource.Feeds.Count;
            return View("ParseResults");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}