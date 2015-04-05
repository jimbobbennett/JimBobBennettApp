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
        public static async Task<List<FeedItem>> GetFeedItemsAsync(string url)
        {
            var feedItemsList = new List<FeedItem>();

            try
            {
                var client = new HttpClient();
                var stream = await client.GetStreamAsync(url);

                var xDoc = XDocument.Load(stream);
                var items = xDoc.Descendants("item").ToList();

                feedItemsList.AddRange(items.Select(element => new FeedItem
                {
                    Link = element.Descendants("link").Single().Value,
                    Categories = string.Join(", ", element.Descendants("category").Select(c => c.Value)),
                    PubDate = DateTime.Parse(element.Descendants("pubDate").Single().Value),
                    Title = element.Descendants("title").Single().Value
                }));
            }
            catch
            {
                // do nothing
            }

            return feedItemsList;
        }
    }
}
