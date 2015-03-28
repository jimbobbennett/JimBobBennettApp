using System;
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using JimBobBennettApp.Portable;

namespace JimBobBennettApp.Droid.Adapters
{
    public class BlogPostAdapter : BaseAdapter<FeedItem>
    {
        private readonly Activity _context;
        private readonly List<FeedItem> _items;

        class ViewHolder : Java.Lang.Object
        {
            public ViewHolder(View view)
            {
                Title = view.FindViewById<TextView>(Resource.Id.blog_post_row_title);
                Tags = view.FindViewById<TextView>(Resource.Id.blog_post_row_tags);

                var font = Typeface.CreateFromAsset(Application.Context.Assets, "fonts/fontawesome.ttf");

                var tagIcon = view.FindViewById<TextView>(Resource.Id.blog_post_row_tag_icon);
                tagIcon.SetTypeface(font, TypefaceStyle.Normal);
            }

            public TextView Title { get; private set; }
            public TextView Tags { get; private set; }

            public void UpdateFromItem(FeedItem item)
            {
                Title.Text = item.Title;
                Tags.Text = string.Join(", ", item.Categories);
            }
        }

        public BlogPostAdapter(Activity context, List<FeedItem> items)
        {
            _context = context;
            _items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];

            var view = convertView;
            ViewHolder viewHolder;

            if (view == null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.blog_post_row, null);
                viewHolder = new ViewHolder(view);

                view.Tag = viewHolder;
            }
            else
            {
                viewHolder = (ViewHolder) view.Tag;
            }

            viewHolder.UpdateFromItem(item);

            return view;
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override FeedItem this[int position]
        {
            get { return _items[position]; }
        }
    }
}