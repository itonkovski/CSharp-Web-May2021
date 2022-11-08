//using System;
//using System.Collections.Generic;

//namespace ConsumeSpotifyWebAPI.Models
//{
    

//        public  class GetArtistTopTracks
//        {
//            public Track[] Tracks { get; set; }
//        }

//        public  class Track
//        {
//            public Album Album { get; set; }
//            public Artist[] Artists { get; set; }
//            public long DiscNumber { get; set; }
//            public long DurationMs { get; set; }
//            public bool Explicit { get; set; }
//            public ExternalIds ExternalIds { get; set; }
//            public ExternalUrls ExternalUrls { get; set; }
//            public Uri Href { get; set; }
//            public string Id { get; set; }
//            public bool IsLocal { get; set; }
//            public bool IsPlayable { get; set; }
//            public string Name { get; set; }
//            public long Popularity { get; set; }
//            public Uri PreviewUrl { get; set; }
//            public long TrackNumber { get; set; }
//            public TrackType Type { get; set; }
//            public string Uri { get; set; }
//        }

//        public  class Album
//        {
//            public AlbumTypeEnum AlbumType { get; set; }
//            public Artist[] Artists { get; set; }
//            public ExternalUrls ExternalUrls { get; set; }
//            public Uri Href { get; set; }
//            public string Id { get; set; }
//            public Image[] Images { get; set; }
//            public string Name { get; set; }
//            public DateTimeOffset ReleaseDate { get; set; }
//            public ReleaseDatePrecision ReleaseDatePrecision { get; set; }
//            public long TotalTracks { get; set; }
//            public AlbumTypeEnum Type { get; set; }
//            public string Uri { get; set; }
//        }

//        public  class Artist
//        {
//            public ExternalUrls ExternalUrls { get; set; }
//            public Uri Href { get; set; }
//            public Id Id { get; set; }
//            public Name Name { get; set; }
//            public ArtistType Type { get; set; }
//            public UriEnum Uri { get; set; }
//        }

//        public  class ExternalUrls
//        {
//            public Uri Spotify { get; set; }
//        }

//        public  class Image
//        {
//            public long Height { get; set; }
//            public Uri Url { get; set; }
//            public long Width { get; set; }
//        }

//        public  class ExternalIds
//        {
//            public string Isrc { get; set; }
//        }

//        public enum AlbumTypeEnum { Album, Single };

//        public enum Id { The3EoonCWqWAoq6TfHvlSk4G };

//        public enum Name { Monalia };

//        public enum ArtistType { Artist };

//        public enum UriEnum { SpotifyArtist3EoonCWqWAoq6TfHvlSk4G };

//        public enum ReleaseDatePrecision { Day };

//        public enum TrackType { Track };
    



//    //public class GetArtistTopTracks
//    //{
//    //    public Albums Albums { get; set; }
//    //}

//    //public class Pokedex
//    //{
//    //    public string AlbumGroup { get; set; }
//    //    public string AlbumType { get; set; }
//    //    public Artist[] Artists { get; set; }
//    //    public ExternalUrls ExternalUrls { get; set; }
//    //    public Uri Href { get; set; }
//    //    public string Id { get; set; }
//    //    public Image[] Images { get; set; }
//    //    public string Name { get; set; }
//    //    public DateTimeOffset ReleaseDate { get; set; }
//    //    public string ReleaseDatePrecision { get; set; }
//    //    public long TotalTracks { get; set; }
//    //    public string Type { get; set; }
//    //    public string Uri { get; set; }
//    //}

//    //public class Artist
//    //{
//    //    public ExternalUrls ExternalUrls { get; set; }
//    //    public Uri Href { get; set; }
//    //    public string Id { get; set; }
//    //    public string Name { get; set; }
//    //    public string Type { get; set; }
//    //    public string Uri { get; set; }
//    //}

//    //public class ExternalUrls
//    //{
//    //    public Uri Spotify { get; set; }
//    //}

//    //public class Image
//    //{
//    //    public long Height { get; set; }
//    //    public Uri Url { get; set; }
//    //    public long Width { get; set; }
//    //}
//}
