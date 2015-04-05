using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;

namespace JimBobBennettApp.Portable
{
    public class BlogPosts
    {
        private SQLiteAsyncConnection _connection;
        private readonly object _syncObj = new object();
        private string _dbPath;
        private ISQLitePlatform _sqLitePlatform;

        public static void CreateBlogPosts(string dbPath, ISQLitePlatform sqLitePlatform)
        {
            Instance = new BlogPosts {_dbPath = dbPath, _sqLitePlatform = sqLitePlatform};
        }

        private async Task CreateConnectionAsync()
        {
            lock (_syncObj)
            {
                if (_connection != null) return;

                var connectionFunc = new Func<SQLiteConnectionWithLock>(() =>
                {
                    var connectionString = new SQLiteConnectionString(_dbPath, false);
                    return new SQLiteConnectionWithLock(_sqLitePlatform, connectionString);
                });

                _connection = new SQLiteAsyncConnection(connectionFunc);
            }

            await _connection.CreateTableAsync<FeedItem>();
        }

        private BlogPosts()
        {

        }

        public static BlogPosts Instance { get; private set; }

        public async Task<IEnumerable<FeedItem>> GetAllBlogPostsAsync()
        {
            await CreateConnectionAsync();
            Debug.WriteLine("Connected!");
            
            await AddNewItemsToDbAsync();

            return await _connection.Table<FeedItem>().OrderByDescending(f => f.PubDate).ToListAsync();
        }

        private async Task AddNewItemsToDbAsync()
        {
            var feedItems = await FeedService.GetFeedItemsAsync("http://www.jimbobbennett.io/rss/");

            foreach (var feedItem in feedItems)
            {
                var item = await _connection.FindAsync<FeedItem>(feedItem.Link.GetHashCode());
                if (item == null)
                {
                    feedItem.Id = feedItem.Link.GetHashCode();
                    await _connection.InsertAsync(feedItem);
                    Debug.WriteLine("Inserted item!");
                }
            }
        }
    }
}
