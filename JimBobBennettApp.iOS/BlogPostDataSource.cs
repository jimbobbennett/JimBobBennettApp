using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using JimBobBennettApp.Portable;
using UIKit;

namespace JimBobBennettApp.iOS
{
    public class BlogPostDataSource : UITableViewSource
    {
        private readonly List<FeedItem> _posts = new List<FeedItem>();

        public async Task LoadBlogPostsAsync()
        {
            var posts = await BlogPosts.Instance.GetAllBlogPostsAsync();
            _posts.Clear();
            _posts.AddRange(posts);
        }
        
        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _posts.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("blogpost");
            cell = cell ?? new UITableViewCell(UITableViewCellStyle.Default, "blogpost");

            var post = _posts[indexPath.Row];
            cell.TextLabel.Text = post.Title;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var post = _posts[indexPath.Row];
            UIApplication.SharedApplication.OpenUrl(new NSUrl(post.Link));
            tableView.DeselectRow(indexPath, false);
        }
    }
}