using HtmlAgilityPack;
using NewsAggr.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsAggr.HtmlParser
{
    public class O57Parser : IHtmlParser
    {
        private string _newsUrl = @"http://www.057.ua/news";
        private string _baseUrl = @"http://www.057.ua";
        private HtmlDocument _document;
        private HtmlWeb _webGet;
        private List<HtmlNode> _newsNodes;
        private int _newsCount;
        public int NewsCount 
        { 
            get { return _newsCount; } 
        }

        public O57Parser()
        {
            Exception exception = null;
            try
            {
                this._webGet = new HtmlWeb();
                this._document = this._webGet.Load(this._newsUrl);
                this._newsNodes = this.GetDivs(this._document.DocumentNode, "text", out exception);
                this._newsCount = this._newsNodes.Count;
            }
            catch (Exception e)
            {
                exception = e;
                this._document = null;
            }
        }

        private List<HtmlNode> GetDivs(HtmlNode documentNode, string className, out Exception exception)
        {
            List<HtmlNode> result = null;
            exception = null;
            try
            {
                result = documentNode.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains(className)).ToList();
            }
            catch(Exception e)
            {
                exception = e;
            }
            
            return result;
        }

        private string GetLink(HtmlNode node, out Exception exception)
        {
            string link = "";
            exception = null;
            try
            {
                var links = node.DescendantNodes().Where(c => c.Attributes.Contains("href") && c.Attributes["href"].Value.Contains("news/")).ToList() ;
                if (links.Count == 0) return link;
                link = links.FirstOrDefault().GetAttributeValue("href", String.Empty);
            }
            catch (Exception e)
            {
                exception = e;
            }
            return link;
        }

        private HtmlDocument GetDocByLink(string link, out Exception exception)
        {
            HtmlDocument doc = null;
            exception = null;
            try
            {
                doc = this._webGet.Load(String.Concat(this._baseUrl, link));
            }
            catch(Exception e)
            {
                exception = e;
            }
            return doc;
        }

        private string GetInnerText(HtmlNode node, out Exception exception)
        {
            string innerText = "";
            exception = null;
            try
            {
                innerText = node.InnerText;
            }
            catch(Exception e)
            {
                exception = e;
            }
            return innerText;
        }


        public List<Feed> GetAllFeeds(out Exception exception)
        {
            List<Feed> o57Feeds = new List<Feed>();
            exception = null;
            try
            {
                for (var i = 0; i< this.NewsCount; i++)
                {
                    HtmlDocument currentBody = this.GetDocByLink(this.GetLink(this._newsNodes[i], out exception), out exception);
                    //todo: static goes after date div. Possible to try to retrieve date from currentBody.DocumentNode instead of body.
                    var body = this.GetDivs(currentBody.DocumentNode, "static", out exception).FirstOrDefault();
                    var dateDiv = this.GetDivs(body, "date", out exception).FirstOrDefault().SelectNodes("//span");
                    var date = this.GetInnerText(dateDiv.Last(), out exception).Split('.');

                    var feed = new Feed();
                    feed.Title = this.GetInnerText(this._newsNodes[i], out exception);
                    feed.Body = this.GetInnerText(body, out exception);
                    try
                    {
                        feed.Date = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                    }
                    catch (Exception)
                    {
                        feed.Date = DateTime.Now;
                    }
                    

                    o57Feeds.Add(feed);
                }
            }
            catch (Exception e)
            {
                exception = e; 
               
            }

            return o57Feeds;
        }
    }
}