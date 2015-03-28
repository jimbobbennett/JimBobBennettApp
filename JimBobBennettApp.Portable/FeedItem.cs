using System;
using System.Collections.Generic;

namespace JimBobBennettApp.Portable
{
    public class FeedItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime PubDate { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public string Description { get; set; }
    }
}
