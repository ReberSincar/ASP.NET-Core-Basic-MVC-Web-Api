namespace books.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public decimal Price { get; set; }
    }
}

