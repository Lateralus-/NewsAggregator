using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;
using NewsAggr.DAL;
using NewsAggr.Models;
using System.Text.RegularExpressions;
using NewsAggr.DAL.Repository;

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
            var webGet = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            var tempUrl = "http://minfin.com.ua/";
            //ViewBag.Message = url;
            try 
            {
                doc = webGet.Load(url);
            }
            catch (Exception e)
            {
                doc = webGet.Load(tempUrl);
            }
            var headers = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("text"));
                       
            Resource resource = new Resource();

            resource.Feeds = new List<Feed>();
            NewsAggregatorRepository<Feed> FeedRep = new NewsAggregatorRepository<Feed>();
            resource.Name = "057 Karkiv news";

            Exception ex = null;
            foreach (var header in headers)
            {
                Feed feed = new Feed();

                
                string title = Regex.Replace(header.InnerText, @"\t|\n|\r", "");
                feed.Title = title;
                feed.Date = DateTime.Now;

                resource.Feeds.Add(feed);
                FeedRep.Add(feed, out ex);
            }
            resource.LastUpdatedDate = DateTime.Now;

           
            ViewBag.Message = resource.Feeds.Count;
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