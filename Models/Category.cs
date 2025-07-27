using System.Collections.Generic;

namespace LIBRARY_SYSTEM.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? Description { get; set; }
        public List<BookCategory>? BookCategories { get; set; }
    }
}