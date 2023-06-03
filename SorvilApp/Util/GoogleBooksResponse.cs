using Newtonsoft.Json;
using SorvilApp.Models;

namespace SorvilApp.Util
{
    public class GoogleBooksResponse
    {
        [JsonProperty("items")]
        public List<Book> Items { get; set; }
    }
}
