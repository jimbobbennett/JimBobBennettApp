using System;
using System.IO;
using Foundation;
using JimBobBennettApp.Portable;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;

namespace JimBobBennettApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libFolder = Path.Combine(docFolder, "..", "Library");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            var dbPath = Path.Combine(libFolder, "blogposts.db3");

            CopyDatabaseIfNotExists(dbPath);

            BlogPosts.CreateBlogPosts(dbPath, new SQLitePlatformIOS());

            return true;
        }

        private static void CopyDatabaseIfNotExists(string dbPath)
        {
            if (File.Exists(dbPath)) return;

            var existingDb = NSBundle.MainBundle.PathForResource("blogposts", "db3");
            File.Copy(existingDb, dbPath);
        }

        // This method is invoked when the application is about to move from active to inactive state.
        // OpenGL applications should use this method to pause.
        public override void OnResignActivation(UIApplication application)
        {
        }

        // This method should be used to release shared resources and it should store the application state.
        // If your application supports background exection this method is called instead of WillTerminate
        // when the user quits.
        public override void DidEnterBackground(UIApplication application)
        {
        }

        /// This method is called as part of the transiton from background to active state.
        public override void WillEnterForeground(UIApplication application)
        {
        }

        /// This method is called when the application is about to terminate. Save data, if needed. 
        public override void WillTerminate(UIApplication application)
        {
        }
    }
}