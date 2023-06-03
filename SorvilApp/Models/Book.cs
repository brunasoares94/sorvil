using Newtonsoft.Json;
using SorvilApp.Util;

namespace SorvilApp.Models
{
    public class Book
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("volumeInfo")]
        public VolumeInfo VolumeInfo { get; set; }
       
    }
}
