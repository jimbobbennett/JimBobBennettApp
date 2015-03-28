using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JimBobBennettApp.Portable
{
    public class FeedService
    {
        public async Task<List<FeedItem>> GetFeedItems(string url)
        {
            var feedItemsList = new List<FeedItem>();

            try
            {
                var client = new HttpClient();
                var stream = await client.GetStreamAsync(url);

                var xDoc = XDocument.Load(stream);
                var items = xDoc.Descendants("item").ToList();

                foreach (var element in items)
                {
                    var item = new FeedItem();

                    item.Link = element.Descendants("link").Single().Value;
                    item.Description = element.Descendants("description").Single().Value;
                    item.Categories = element.Descendants("category").Select(c => c.Value).ToList();
                    item.PubDate = DateTime.Parse(element.Descendants("pubDate").Single().Value);
                    item.Title = element.Descendants("title").Single().Value;

                    feedItemsList.Add(item);
                }
            }
            catch
            {
                // do nothing
            }

            return feedItemsList;
        }
    }
}
