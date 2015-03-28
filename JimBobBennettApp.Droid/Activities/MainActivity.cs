using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using JimBobBennettApp.Droid.Adapters;
using JimBobBennettApp.Droid.Fragments;
using JimBobBennettApp.Droid.Helpers;
using Fragment = Android.Support.V4.App.Fragment;

namespace JimBobBennettApp.Droid.Activities
{
    [Activity(Label = "Jim Bob Bennett", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ScreenOrientation = ScreenOrientation.Portrait,
        Icon = "@drawable/ic_launcher")]
    public class MainActivity : BaseActivity
    {
        private MyActionBarDrawerToggle _drawerToggle;
        private string _drawerTitle;
        private string _title;

        private DrawerLayout _drawerLayout;
        private ListView _drawerListView;
        private DrawerMenuAdapter _adapter;

        protected override int LayoutResource
        {
            get { return Resource.Layout.main; }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _title = _drawerTitle = Title;
            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            _drawerListView = FindViewById<ListView>(Resource.Id.left_drawer);

            //Create Adapter for drawer List
            _drawerListView.Adapter = _adapter = new DrawerMenuAdapter(this);

            //Set click handler when item is selected
            _drawerListView.ItemClick += (sender, args) => ListItemClicked(args.Position);

            //Set Drawer Shadow
            _drawerLayout.SetDrawerShadow(Resource.Drawable.drawer_shadow_dark, GravityCompat.Start);

            //DrawerToggle is the animation that happens with the indicator next to the actionbar
            _drawerToggle = new MyActionBarDrawerToggle(this, _drawerLayout,
                Toolbar,
                Resource.String.drawer_open,
                Resource.String.drawer_close);

            //Display the current fragments title and update the options menu
            _drawerToggle.DrawerClosed += (o, args) =>
            {
                SupportActionBar.Title = _title;
                SupportInvalidateOptionsMenu();
            };

            //Display the drawer title and update the options menu
            _drawerToggle.DrawerOpened += (o, args) =>
            {
                SupportActionBar.Title = _drawerTitle;
                SupportInvalidateOptionsMenu();
            };

            //Set the drawer lister to be the toggle.
            _drawerLayout.SetDrawerListener(_drawerToggle);



            //if first time you will want to go ahead and click first item.
            if (savedInstanceState == null)
            {
                ListItemClicked(0);
            }
        }

        int _oldPosition = -1;

        private void ListItemClicked(int position)
        {
            //this way we don't load twice, but you might want to modify this a bit.
            if (position == _oldPosition)
                return;

            _oldPosition = position;

            Fragment fragment = null;
            switch (position)
            {
                case 0:
                    fragment = AboutMeFragment.NewInstance();
                    break;
                case 1:
                    fragment = BlogPostsFragment.NewInstance();
                    break;
            }

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();

            _drawerListView.SetItemChecked(position, true);
            SupportActionBar.Title = _title = _adapter.GetTitle(position);
            _drawerLayout.CloseDrawers();
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {

            var drawerOpen = _drawerLayout.IsDrawerOpen(GravityCompat.Start);
            //when open don't show anything
            for (var i = 0; i < menu.Size(); i++)
                menu.GetItem(i).SetVisible(!drawerOpen);


            return base.OnPrepareOptionsMenu(menu);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            _drawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            _drawerToggle.OnConfigurationChanged(newConfig);
        }

        // Pass the event to ActionBarDrawerToggle, if it returns
        // true, then it has handled the app icon touch event
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return _drawerToggle.OnOptionsItemSelected(item) || base.OnOptionsItemSelected(item);
        }
    }
}

