using System.Collections.Generic;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using Java.Lang;
using JimBobBennettApp.Portable;

namespace JimBobBennettApp.Droid.Fragments
{
    public class LocationsLivedCallback : Object, IOnMapReadyCallback
    {
        private readonly TextView _locationDetails;
        private readonly Dictionary<string, LocationInformation> _markers = new Dictionary<string, LocationInformation>(); 

        public LocationsLivedCallback(TextView locationDetails)
        {
            _locationDetails = locationDetails;
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            LatLng firstLatLng = null;

            foreach (var location in AboutMe.LocationsLived)
            {
                var latlng = new LatLng(location.Latitude, location.Longitude);
                firstLatLng = firstLatLng ?? latlng;

                var markerOptions = new MarkerOptions().SetPosition(latlng).SetTitle(location.Name);
                var marker = googleMap.AddMarker(markerOptions);

                _markers[marker.Id] = location;
            }

            googleMap.MarkerClick += GoogleMapOnMarkerClick;

            var update = CameraUpdateFactory.NewLatLngZoom(firstLatLng, googleMap.MinZoomLevel);
            googleMap.MoveCamera(update);
        }

        private void GoogleMapOnMarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
        {
            LocationInformation location;
            if (_markers.TryGetValue(e.Marker.Id, out location))
            {
                _locationDetails.Text = location.Description;
            }

            e.Handled = false;
        }
    }
}