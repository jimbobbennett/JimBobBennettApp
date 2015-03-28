using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;

namespace JimBobBennettApp.Droid.Controls
{
    public class ExtendedScrollView : ScrollView
    {
        protected ExtendedScrollView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public ExtendedScrollView(Context context)
            : base(context)
        {
        }

        public ExtendedScrollView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public ExtendedScrollView(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
        }

        public ExtendedScrollView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        public event EventHandler<ScrolledEventArgs> Scrolled;
 
        protected override void OnScrollChanged(int l, int t, int oldl, int oldt)
        {
            base.OnScrollChanged(l, t, oldl, oldt);

            if (Scrolled == null)
				return;

            Scrolled(this, new ScrolledEventArgs
            {
                X = l,
                Y = t,
                OldX = oldl,
                OldY = oldt
            });
        }
    }
}