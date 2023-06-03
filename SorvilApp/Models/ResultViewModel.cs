namespace SorvilApp.Models
{
    public class ResultViewModel
    {
        public List<BookViewModel> Books { get; set; }

        public string SearchTerm { get; set; }
        public string Genre { get; set; }
        public int? Year { get; set; }
        public bool? HasISBN { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class BookViewModel
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string? PublishedYear { get; set; }
        public string Id { get; set; }
        public string Description{ get; set; }
    }
}