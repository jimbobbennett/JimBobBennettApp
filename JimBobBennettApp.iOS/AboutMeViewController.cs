﻿using System;
using CoreGraphics;
using Foundation;
using JimBobBennettApp.Portable;
using UIKit;

namespace JimBobBennettApp.iOS
{
    public sealed partial class AboutMeViewController : UIViewController
    {
        public AboutMeViewController(IntPtr handle)
            : base(handle)
        {
            TabBarItem.SetTitleTextAttributes(new UITextAttributes{TextColor = UIColor.Black}, UIControlState.Highlighted);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            var width = View.Frame.Width;
            var scaleFactor = width / JimImageView.Image.Size.Width;

            PhoneStatusBarView.Frame = new CGRect(new CGPoint(0, 0), new CGSize(width, 20));

            ScrollView.Frame = new CGRect(new CGPoint(0, 20), new CGSize(width, View.Frame.Height - 69));
            ScrollView.Scrolled += (sender, args) =>
            {
                var offSet = (float)Math.Max(0f, (ScrollView.ContentOffset.Y));

                var alpha = ((float) JimImageView.Frame.Height - (offSet/2f))/JimImageView.Frame.Height;
                alpha = (float)Math.Min(Math.Max(0, alpha), 1);

                JimImageView.Frame = new CGRect(new CGPoint(0, 20 - (offSet / 2.5f)), JimImageView.Frame.Size);
                JimImageView.Alpha = alpha;

                ImageBackground.Frame = JimImageView.Frame;
            };

            JimImageView.Frame = new CGRect(new CGPoint(0, 20), new CGSize(width, JimImageView.Image.Size.Height * scaleFactor));
            ImageBackground.Frame = JimImageView.Frame;

            TitleTextView.AttributedText = new NSAttributedString(AboutMe.Title, new UIStringAttributes { Font = UIFont.SystemFontOfSize(24) });
            var titleSize = TitleTextView.SizeThatFits(new CGSize(width, float.MaxValue));
            TitleTextView.Frame = new CGRect(new CGPoint(0, JimImageView.Frame.Bottom), new CGSize(width, titleSize.Height));

            SubTitle1.AttributedText = new NSAttributedString(AboutMe.Subtitle1, new UIStringAttributes { Font = UIFont.SystemFontOfSize(16) });
            var subtitle1Size = SubTitle1.SizeThatFits(new CGSize(width, float.MaxValue));
            SubTitle1.Frame = new CGRect(new CGPoint(0, TitleTextView.Frame.Bottom), new CGSize(width, subtitle1Size.Height));

            SubTitle2.AttributedText = new NSAttributedString(AboutMe.Subtitle2, new UIStringAttributes { Font = UIFont.SystemFontOfSize(16) });
            var subtitle2Size = SubTitle2.SizeThatFits(new CGSize(width, float.MaxValue));
            SubTitle2.Frame = new CGRect(new CGPoint(0, SubTitle1.Frame.Bottom), new CGSize(width, subtitle2Size.Height));

            SubTitle3.AttributedText = new NSAttributedString(AboutMe.Subtitle3, new UIStringAttributes { Font = UIFont.SystemFontOfSize(16) });
            var subtitle3Size = SubTitle3.SizeThatFits(new CGSize(width, float.MaxValue));
            SubTitle3.Frame = new CGRect(new CGPoint(0, SubTitle2.Frame.Bottom), new CGSize(width, subtitle3Size.Height));

            ScrollView.ContentSize = new CGSize(width, SubTitle3.Frame.Bottom + 20);

            var tabBarController = (UITabBarController) ParentViewController;
            tabBarController.TabBar.SelectedImageTintColor = UIColor.Black;
        }

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();

            // Clear any references to subviews of the main view in order to
            // allow the Garbage Collector to collect them sooner.
            //
            // e.g. myOutlet.Dispose (); myOutlet = null;

            ReleaseDesignerOutlets();
        }

        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            // Return true for supported orientations
            return false;
        }
    }
}