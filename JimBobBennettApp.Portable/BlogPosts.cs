using System.Collections.Generic;
using System.Threading.Tasks;

namespace JimBobBennettApp.Portable
{
    public class BlogPosts
    {
        private readonly FeedService _feedService = new FeedService();

        static BlogPosts()
        {
            Instance = new BlogPosts();
        }

        private BlogPosts()
        {
        }

        public static BlogPosts Instance { get; private set; }

        public async Task<IEnumerable<FeedItem>> GetAllBlogPostsAsync()
        {
            return await _feedService.GetFeedItems("http://www.jimbobbennett.io/rss/");
        }
    }
}
