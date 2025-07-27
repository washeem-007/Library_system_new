namespace LIBRARY_SYSTEM.Models
{
    public class BookCategory
    {
        public int BookCategoryId { get; set; }
        public int BookId { get; set; }
        public int CategoryID { get; set; }
        public Book? Book { get; set; }
        public Category? Category { get; set; }
    }
}