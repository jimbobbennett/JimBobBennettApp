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
	[Register ("AboutMeViewController")]
	partial class AboutMeViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView ImageBackground { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView JimImageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView PhoneStatusBarView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIScrollView ScrollView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView SubTitle1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView SubTitle2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView SubTitle3 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView TitleTextView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ImageBackground != null) {
				ImageBackground.Dispose ();
				ImageBackground = null;
			}
			if (JimImageView != null) {
				JimImageView.Dispose ();
				JimImageView = null;
			}
			if (PhoneStatusBarView != null) {
				PhoneStatusBarView.Dispose ();
				PhoneStatusBarView = null;
			}
			if (ScrollView != null) {
				ScrollView.Dispose ();
				ScrollView = null;
			}
			if (SubTitle1 != null) {
				SubTitle1.Dispose ();
				SubTitle1 = null;
			}
			if (SubTitle2 != null) {
				SubTitle2.Dispose ();
				SubTitle2 = null;
			}
			if (SubTitle3 != null) {
				SubTitle3.Dispose ();
				SubTitle3 = null;
			}
			if (TitleTextView != null) {
				TitleTextView.Dispose ();
				TitleTextView = null;
			}
		}
	}
}
