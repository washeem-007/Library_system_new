using System.Collections.Generic;

namespace LIBRARY_SYSTEM.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? ISBN { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public List<BookCategory>? BookCategories { get; set; }
    }
}