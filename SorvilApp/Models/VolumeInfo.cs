using Newtonsoft.Json;
using SorvilApp.Util;

namespace SorvilApp.Models
{
    public class VolumeInfo
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("authors")]
        public List<string> Authors { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("industryIdentifiers")]
        public List<IndustryIdentifier> IndustryIdentifiers { get; set; }

        [JsonProperty("imageLinks")]
        public ImageLinks ImageLinks { get; set; }

        [JsonProperty("publishedDate")]
        public string PublishedDate { get; set; }
    }
}
