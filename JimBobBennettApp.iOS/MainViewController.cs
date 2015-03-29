
using FlyoutNavigation;
using MonoTouch.Dialog;
using UIKit;

namespace JimBobBennettApp.iOS
{
    public partial class MainViewController : UIViewController
    {
        private FlyoutNavigationController _navigation;
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _navigation = new FlyoutNavigationController
            {
                Position = FlyOutNavigationPosition.Left, 
                View = {Frame = UIScreen.MainScreen.Bounds}
            };

            View.AddSubview(_navigation.View);
            AddChildViewController(_navigation);

            _navigation.ViewControllers = new UIViewController[]
            {
                new UINavigationController(CreateViewController<AboutMeViewController>("AboutMeViewController" ,"AboutMeViewController")),
                new UINavigationController(new TaskPageController(_navigation, "Latest Blog Posts")),
                new UINavigationController(new TaskPageController(_navigation, "Where I've Lived"))
            };

            _navigation.NavigationRoot = new RootElement("Navigation")
            {
                new Section("Pages")
                {
                    new StringElement("About Me"),
                    new StringElement("Latest Blog Posts"),
                    new StringElement("Where I've Lived"),
                }
            };
        }

        private static T CreateViewController<T>(string storyboardName, string viewControllerStoryBoardId = "") where T : UIViewController
        {
            var storyboard = UIStoryboard.FromName(storyboardName, null);
            return string.IsNullOrEmpty(viewControllerStoryBoardId) ? (T)storyboard.InstantiateInitialViewController() : (T)storyboard.InstantiateViewController(viewControllerStoryBoardId);
        }
    }
}