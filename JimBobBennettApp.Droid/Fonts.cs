using Android.App;
using Android.Graphics;

namespace JimBobBennettApp.Droid
{
    public static class Fonts
    {
        static Fonts()
        {
            FontAwesome = Typeface.CreateFromAsset(Application.Context.Assets, "fonts/fontawesome.ttf"); 
        }

        public static Typeface FontAwesome { get; private set; }
    }
}