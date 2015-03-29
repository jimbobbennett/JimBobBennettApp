
using UIKit;

namespace JimBobBennettApp.iOS
{
    public partial class AboutMeViewController : UIViewController
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public AboutMeViewController()
            : base(UserInterfaceIdiomIsPhone ? "AboutMeViewController_iPhone" : "AboutMeViewController_iPad", null)
        {
           
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}