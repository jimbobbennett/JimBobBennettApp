using System;
using CoreGraphics;
using Foundation;
using JimBobBennettApp.Portable;
using UIKit;

namespace JimBobBennettApp.iOS
{
    public sealed partial class BlogPostsViewController : UIViewController
    {
        private readonly BlogPostDataSource _dataSource = new BlogPostDataSource();
        private readonly UIRefreshControl _refreshControl;

        public BlogPostsViewController(IntPtr handle)
            : base(handle)
        {
            TabBarItem.Image = UIImage.FromBundle("second");

            _refreshControl = new UIRefreshControl();
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            var tabBarController = (UITabBarController)ParentViewController;
            tabBarController.TabBar.SelectedImageTintColor = UIColor.Black;

            var width = View.Frame.Width;
            var height = View.Frame.Height;

            VisitBlogButton.Frame = new CGRect(new CGPoint(0, height-99), new CGSize(width, 30));
            VisitBlogButton.TouchUpInside += (sender, args) =>
            {
                UIApplication.SharedApplication.OpenUrl(new NSUrl("http://jimbobbennett.io"));
            };

            BlogPostTableView.Frame = new CGRect(new CGPoint(0, 20), new CGSize(width, VisitBlogButton.Frame.Top - 20));
            BlogPostTableView.TableFooterView = new UIView();
            BlogPostTableView.Add(_refreshControl);

            _refreshControl.ValueChanged += RefreshControlOnValueChanged;

            BlogPostTableView.Source = _dataSource;
            await _dataSource.LoadBlogPostsAsync();
            BlogPostTableView.ReloadData();
        }

        private async void RefreshControlOnValueChanged(object sender, EventArgs eventArgs)
        {
            await BlogPosts.Instance.GetAllBlogPostsAsync();
            BlogPostTableView.ReloadData();
            _refreshControl.EndRefreshing();
        }

        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            // Return true for supported orientations
            return false;
        }
    }
}