using Newtonsoft.Json;

namespace SorvilApp.Util
{
    public class ImageLinks
    {
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("smallThumbnail")]
        public string SmallThumbnail { get; set; }
    }
}
