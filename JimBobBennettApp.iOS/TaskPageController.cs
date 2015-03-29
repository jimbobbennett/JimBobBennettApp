using FlyoutNavigation;
using MonoTouch.Dialog;
using UIKit;

namespace JimBobBennettApp.iOS
{
    public class TaskPageController : DialogViewController
    {
        public TaskPageController(FlyoutNavigationController navigation, string title)
            : base(null)
        {
            Root = new RootElement(title)
            {
                new Section
                {
                    new CheckboxElement(title)
                }
            };

            NavigationItem.LeftBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Action, delegate
            {
                navigation.ToggleMenu();
            });
        }
    }
}