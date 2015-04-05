
using System;
using System.Collections.Generic;
using CoreGraphics;
using CoreLocation;
using JimBobBennettApp.Portable;
using MapKit;
using UIKit;

namespace JimBobBennettApp.iOS
{
    public partial class LocationsLivedViewController : UIViewController
    {
        private readonly CLLocationManager _locationManager;
        private readonly Dictionary<IMKAnnotation, LocationInformation> _annotations = new Dictionary<IMKAnnotation, LocationInformation>(); 

        public LocationsLivedViewController(IntPtr handle)
            : base(handle)
        {
            _locationManager = new CLLocationManager();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var width = View.Frame.Width;

            var titleSize = TitleTextView.SizeThatFits(new CGSize(width, float.MaxValue));
            TitleTextView.Frame = new CGRect(new CGPoint(0, 20), new CGSize(width, titleSize.Height));

            MapView.Frame = new CGRect(new CGPoint(0, TitleTextView.Frame.Bottom + 5), new CGSize(width, width));
            DetailsTextView.Frame = new CGRect(new CGPoint(0, MapView.Frame.Bottom + 10), new CGSize(width, 100));

            _locationManager.RequestWhenInUseAuthorization();

            MapView.ShowsUserLocation = true;
            
            var region = new MKCoordinateRegion(MapView.CenterCoordinate, new MKCoordinateSpan(180, 360));
            MapView.Region = region;

            foreach (var locationInformation in AboutMe.LocationsLived)
            {
                var annotation = new MKPointAnnotation {Title = locationInformation.Name};
                annotation.SetCoordinate(new CLLocationCoordinate2D(locationInformation.Latitude, locationInformation.Longitude));
                MapView.AddAnnotation(annotation);
                _annotations.Add(annotation, locationInformation);

                MapView.DidSelectAnnotationView += MapViewOnDidSelectAnnotationView;
            }
        }

        private void MapViewOnDidSelectAnnotationView(object sender, MKAnnotationViewEventArgs mkAnnotationViewEventArgs)
        {
            var locationInformation = _annotations[mkAnnotationViewEventArgs.View.Annotation];
            DetailsTextView.Text = locationInformation.Description;
        }

        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            // Return true for supported orientations
            return false;
        }
    }
}