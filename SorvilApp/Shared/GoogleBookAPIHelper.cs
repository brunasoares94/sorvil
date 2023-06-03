using Newtonsoft.Json;
using SorvilApp.Models;
using SorvilApp.Util;
using System.Text;

namespace SorvilApp.Shared
{
    public class GoogleBookAPIHelper
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public GoogleBookAPIHelper(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public List<Book> SearchBooks(string searchTerm, string? genre, int? year, bool? hasISBN)
        {
            var apiKey = _configuration["GoogleBooksAPI:ApiKey"];

            var urlBuilder = new StringBuilder();
            urlBuilder.Append("https://www.googleapis.com/books/v1/volumes?");
            urlBuilder.Append($"q={Uri.EscapeDataString(searchTerm)}");
            urlBuilder.Append("&key=" + apiKey);

            if (!string.IsNullOrEmpty(genre))
            {
                urlBuilder.Append("&subject:" + Uri.EscapeDataString(genre));
            }

            if (year.HasValue)
            {
                urlBuilder.Append("&filter=" + Uri.EscapeDataString($"publishedDate:{year.Value}"));
            }

            if (hasISBN.HasValue)
            {
                urlBuilder.Append("&filter=" + Uri.EscapeDataString(hasISBN.Value ? "isbn" : "!isbn"));
            }

            var url = urlBuilder.ToString();

            var response = _httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            var json = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<GoogleBooksResponse>(json);

            var books = result?.Items;

            return books;
        }

        public async Task<IEnumerable<Book>> SearchBooksByYearAsync(int year)
        {
            string apiKey = _configuration["GoogleBooksAPI:ApiKey"];
            string url = $"https://www.googleapis.com/books/v1/volumes?q={year}&key={apiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            string responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                GoogleBooksResponse booksResponse = JsonConvert.DeserializeObject<GoogleBooksResponse>(responseContent);
                return booksResponse.Items;
            }
            else
            {
                return null;
            }
        }

        public async Task<Book> GetBookByISBN(string isbn)
        {
            string apiKey = _configuration["GoogleBooksAPI:ApiKey"];
            var url = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}&key={apiKey}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GoogleBooksResponse>(content);

                if (result.Items != null && result.Items.Count > 0)
                {
                    var book = result.Items[0];
                    return book;
                }
            }

            return null;
        }
    }
}
