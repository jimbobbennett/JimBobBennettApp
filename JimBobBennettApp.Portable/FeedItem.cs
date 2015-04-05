using System;
using SQLite.Net.Attributes;

namespace JimBobBennettApp.Portable
{
    [Table("BlogPosts")]
    public class FeedItem
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Link { get; set; }
        public string Title { get; set; }
        public DateTime PubDate { get; set; }
        public string Categories { get; set; }
    }
}
