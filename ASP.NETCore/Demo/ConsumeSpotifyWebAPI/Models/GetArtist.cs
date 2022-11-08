namespace ConsumeSpotifyWebAPI.Models
{

    public class GetArtist
    {
        public Artist Artists { get; set; }
    }

    public class Artist
    {
        public ExternalUrls ExternalUrls { get; set; }
        public Followers Followers { get; set; }
        public string[] Genres { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public Image[] Images { get; set; }
        public string Name { get; set; }
        public long Popularity { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class ExternalUrls
    {
        public string Spotify { get; set; }
    }

    public class Followers
    {
        public string Href { get; set; }
        public long Total { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
        public long Height { get; set; }
        public long Width { get; set; }
    }
}
