using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using JimBobBennettApp.Droid.Adapters;
using JimBobBennettApp.Portable;

namespace JimBobBennettApp.Droid.Fragments
{
    public class BlogPostsFragment : Fragment
    {
        private Button _visitBlog;
        private ListView _listView;
        private SwipeRefreshLayout _swipeRefreshLayout;
        private readonly List<FeedItem> _blogPosts = new List<FeedItem>();
        private BaseAdapter _adapter;
        
        public static BlogPostsFragment NewInstance()
        {
            return new BlogPostsFragment { Arguments = new Bundle() };
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.blog_posts, null);

            _visitBlog = view.FindViewById<Button>(Resource.Id.visit_my_blog_button);
            _listView = view.FindViewById<ListView>(Resource.Id.blog_posts_list);
            _swipeRefreshLayout = view.FindViewById<SwipeRefreshLayout>(Resource.Id.blog_posts_swipe_refresh);

            _visitBlog.Click += (s, e) =>
            {
                LoadUrl("http://jimbobbennett.io");
            };

            _swipeRefreshLayout.Refresh += async (s, e) => await LoadBlogPosts();

            _adapter = CreateAdapter();
            _listView.Adapter = _adapter;

            _listView.ItemClick += (s, e) =>
            {
                LoadUrl(_blogPosts[e.Position].Link);
            };

            _swipeRefreshLayout.Refreshing = true;
            Task.Factory.StartNew(async () => await LoadBlogPosts());

            return view;
        }

        private BlogPostAdapter CreateAdapter()
        {
            return new BlogPostAdapter(Activity, _blogPosts);
        }

        private void LoadUrl(string url)
        {
            var i = new Intent(Intent.ActionView);
            i.SetData(Uri.Parse(url));
            StartActivity(i);
        }

        private async Task LoadBlogPosts()
        {
            var posts = await BlogPosts.Instance.GetAllBlogPostsAsync();

            _blogPosts.Clear();
            _blogPosts.AddRange(posts);

            Activity.RunOnUiThread(() =>
            {
                _adapter.NotifyDataSetChanged();
                _swipeRefreshLayout.Refreshing = false;
            });
        }
    }
}