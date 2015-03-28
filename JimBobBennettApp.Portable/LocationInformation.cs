namespace JimBobBennettApp.Portable
{
    public class LocationInformation
    {
        public LocationInformation(string name, double latitude, double longitude, string description)
        {
            Name = name;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}
