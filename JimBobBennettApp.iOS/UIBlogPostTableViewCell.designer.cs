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
	[Register ("UIBlogPostTableViewCell")]
	partial class UIBlogPostTableViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView Categories { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView TagIcon { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView Title { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Categories != null) {
				Categories.Dispose ();
				Categories = null;
			}
			if (TagIcon != null) {
				TagIcon.Dispose ();
				TagIcon = null;
			}
			if (Title != null) {
				Title.Dispose ();
				Title = null;
			}
		}
	}
}
