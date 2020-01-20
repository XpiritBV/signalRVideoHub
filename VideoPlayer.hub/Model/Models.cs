namespace VideoPlayer
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Movies
    {
        [JsonProperty("categories")]
        public Category[] Categories { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("videos")]
        public Video[] Videos { get; set; }
    }

    public partial class Video
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sources")]
        public Uri[] Sources { get; set; }

        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
