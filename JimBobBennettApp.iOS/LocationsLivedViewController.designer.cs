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
	[Register ("LocationsLivedViewController")]
	partial class LocationsLivedViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView DetailsTextView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MapKit.MKMapView MapView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView TitleTextView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (DetailsTextView != null) {
				DetailsTextView.Dispose ();
				DetailsTextView = null;
			}
			if (MapView != null) {
				MapView.Dispose ();
				MapView = null;
			}
			if (TitleTextView != null) {
				TitleTextView.Dispose ();
				TitleTextView = null;
			}
		}
	}
}
