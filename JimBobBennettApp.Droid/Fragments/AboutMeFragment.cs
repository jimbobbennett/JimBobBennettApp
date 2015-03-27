using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace JimBobBennettApp.Droid.Fragments
{
    public class AboutMeFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static AboutMeFragment NewInstance()
        {
            return new AboutMeFragment { Arguments = new Bundle() };
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.about_me, null);

            return view;
        }
    }
}