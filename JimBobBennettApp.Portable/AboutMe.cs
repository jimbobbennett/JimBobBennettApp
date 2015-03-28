using System;
using System.Collections.Generic;

namespace JimBobBennettApp.Portable
{
    public static class AboutMe
    {
        public static string Title
        {
            get { return "Xamarin and WPF developer, blogger and technology geek"; }
        }

        public static string Subtitle1
        {
            get
            {
                return "Passionate technologist with a huge range of experience ranging from C#/WPF in the finance industry, " +
                       "to cross platform mobile application development using Xamarin.";
            }
        }

        public static string Subtitle2
        {
            get
            {
                return "I have delivered projects ranging from my own mobile apps, to being both the architect and " +
                       "driving force behind a new real-time equity trading platform for a leading Asian brokerage.";
            }
        }

        public static string Subtitle3
        {
            get
            {
                return "I have also created and contributed to a number of open source projects, been involved in the " +
                       "Asian startup scene working in the mobile app space, blogged and been a guest on a podcast that " +
                       "has topped the iTunes Software How-To category.";
            }
        }

        public static string Twitter
        {
            get { return "http://twitter.com/jimbobbennett"; }
        }

        public static string LinkedIn
        {
            get { return "http://www.linkedin.com/pub/jim-bennett/20/448/367"; }
        }

        public static string GitHub
        {
            get { return "http://github.com/jimbobbennett"; }
        }

        public static string GooglePlus
        {
            get { return "http://plus.google.com/+JimBennettio"; }
        }

        public static IEnumerable<LocationInformation> LocationsLived
        {
            get
            {
                yield return new LocationInformation("England", 52.8849565, -1.9770329, "Cold.  Rains a lot");
                yield return new LocationInformation("Hong Kong", 22.3700556, 114.1223784, "Awesome Noodles");
                yield return new LocationInformation("Bermuda", 32.3191775, -64.7670827, "Expensive fruit");
                yield return new LocationInformation("Bangkok", 13.7246005, 100.6331108, "Amazing food, especially the fried chicken");
            }
        }
    }
}
