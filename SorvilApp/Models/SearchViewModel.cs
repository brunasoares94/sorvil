namespace SorvilApp.Models
{
    public class SearchViewModel
    {
        public string? SearchTerm { get; set; }
        public string? Genre { get; set; }
        public int? Year { get; set; }
        public bool? HasISBN { get; set; }
    }
}
