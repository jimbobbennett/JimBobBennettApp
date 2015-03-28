using System;
using Android.Gms.Maps;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace JimBobBennettApp.Droid.Fragments
{
    public class LocationsLivedFragment : Fragment
    {
        private LocationsLivedCallback _callback;
        private SupportMapFragment _map;

        public static LocationsLivedFragment NewInstance()
        {
            return new LocationsLivedFragment { Arguments = new Bundle() };
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.locations_lived, null);

            var locationDetails = view.FindViewById<TextView>(Resource.Id.locations_lived_country_text);

            _map = (SupportMapFragment)ChildFragmentManager.FindFragmentById(Resource.Id.locations_lived_map);
            _callback = new LocationsLivedCallback(locationDetails);
            _map.GetMapAsync(_callback);

            return view;
        }
    }
}