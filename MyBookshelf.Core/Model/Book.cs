namespace MyBookshelf.Core.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? Note { get; set; }
        public string? Review { get; set; }
        public string? Quotes { get; set; }
    }
}
