using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Object = Java.Lang.Object;
using String = Java.Lang.String;

namespace JimBobBennettApp.Droid.Adapters
{
    class DrawerMenuAdapter : BaseAdapter
    {
        class DrawerMenuViewHolder : Object
        {
            public TextView Title { get; set; }
            public TextView TitleIcon { get; set; }
        }

        readonly Tuple<string, string>[] _sections;

        readonly Context _context;

        public DrawerMenuAdapter(Context context)
        {
            _context = context;

            var names = context.Resources.GetStringArray(Resource.Array.sections);
            var icons = context.Resources.GetStringArray(Resource.Array.sections_icons);

            if (names.Length != icons.Length)
                throw new ArgumentException("Names and Icons must match in length. Check your arrays.xml");

            _sections = new Tuple<string, string>[names.Length];

            for (var i = 0; i < names.Length; i++)
            {
                _sections[i] = Tuple.Create(icons[i], names[i]);
            }
        }

        public string GetTitle(int position)
        {
            return _sections[position].Item2;
        }

        public override Object GetItem(int position)
        {
            return new String(_sections[position].Item2);
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            DrawerMenuViewHolder holder = null;

            if (view != null)
                holder = view.Tag as DrawerMenuViewHolder;

            if (holder == null)
            {
                holder = new DrawerMenuViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                view = inflater.Inflate(Resource.Layout.item_menu, parent, false);
                holder.Title = view.FindViewById<TextView>(Resource.Id.menu_title);
                holder.TitleIcon = view.FindViewById<TextView>(Resource.Id.menu_icon);
                holder.TitleIcon.SetTypeface(Fonts.FontAwesome, TypefaceStyle.Normal);
                view.Tag = holder;
            }

            if (position == 0 && convertView == null)
                holder.Title.SetTypeface(holder.Title.Typeface, TypefaceStyle.Bold);
            else
                holder.Title.SetTypeface(holder.Title.Typeface, TypefaceStyle.Normal);


            holder.Title.Text = _sections[position].Item2;
            holder.TitleIcon.Text = _sections[position].Item1;

            return view;
        }

        public override int Count
        {
            get
            {
                return _sections.Length;
            }
        }

        public override bool IsEnabled(int position)
        {
            return true;
        }

        public override bool AreAllItemsEnabled()
        {
            return false;
        }
    }
}