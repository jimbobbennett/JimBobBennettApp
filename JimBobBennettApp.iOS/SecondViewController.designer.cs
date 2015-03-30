// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace JimBobBennettApp.iOS
{
	[Register ("SecondViewController")]
	partial class SecondViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView BlogPostTableView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton VisitBlogButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (BlogPostTableView != null) {
				BlogPostTableView.Dispose ();
				BlogPostTableView = null;
			}
			if (VisitBlogButton != null) {
				VisitBlogButton.Dispose ();
				VisitBlogButton = null;
			}
		}
	}
}
