using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using JimBobBennettApp.Droid.Controls;
using JimBobBennettApp.Portable;

namespace JimBobBennettApp.Droid.Fragments
{
    public class AboutMeFragment : Fragment
    {
        private FrameLayout _frameLayout;
        private ImageView _imageView;
        private LinearLayout _textLayout;
        private ExtendedScrollView _extendedScrollView;

        public static AboutMeFragment NewInstance()
        {
            return new AboutMeFragment { Arguments = new Bundle() };
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.about_me, null);

            var title = view.FindViewById<TextView>(Resource.Id.about_me_title);
            var subtitle1 = view.FindViewById<TextView>(Resource.Id.about_me_subtitle1);
            var subtitle2 = view.FindViewById<TextView>(Resource.Id.about_me_subtitle2);
            var subtitle3 = view.FindViewById<TextView>(Resource.Id.about_me_subtitle3);

            title.Text = AboutMe.Title;
            subtitle1.Text = AboutMe.Subtitle1;
            subtitle2.Text = AboutMe.Subtitle2;
            subtitle3.Text = AboutMe.Subtitle3;

            _frameLayout = view.FindViewById<FrameLayout>(Resource.Id.about_me_main_image_frame);
            _imageView = view.FindViewById<ImageView>(Resource.Id.about_me_main_image);
            _textLayout = view.FindViewById<LinearLayout>(Resource.Id.about_me_text_layout);
            _extendedScrollView = view.FindViewById<ExtendedScrollView>(Resource.Id.about_me_scroll_view);

            _frameLayout.LayoutChange += (s, e) =>
            {
                _textLayout.SetPadding(0, _frameLayout.MeasuredHeight, 0, 0); 
            };

            _extendedScrollView.Scrolled += (s, e) =>
            {
                _frameLayout.TranslationY = -(int) (e.Y/2.5F);
                _imageView.Alpha = (((float)_frameLayout.MeasuredHeight - e.Y) / _frameLayout.MeasuredHeight);
            };

            return view;
        }
    }
}