using System.Threading.Tasks;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using JimBobBennettApp.Portable;

namespace JimBobBennettApp.Droid.Fragments
{
    public class BlogPostsFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static BlogPostsFragment NewInstance()
        {
            return new BlogPostsFragment { Arguments = new Bundle() };
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.blog_posts, null);

            Task.Factory.StartNew(async () =>
            {
                var posts = await BlogPosts.Instance.GetAllBlogPostsAsync();
            });

            return view;
        }
    }
}