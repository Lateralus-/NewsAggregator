using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;

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
            HtmlNode bodyNode = null;
            if (doc.DocumentNode != null)
            {
                bodyNode = doc.DocumentNode.SelectSingleNode("//body");
            }

            ViewBag.Message = bodyNode != null? bodyNode.ChildNodes.Count.ToString(): "Seems not to be working";
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