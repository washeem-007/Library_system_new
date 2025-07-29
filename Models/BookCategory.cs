using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace LIBRARY_SYSTEM.Models
{
    public class BookCategory
    {
        public int BookCategoryId { get; set; }
        public int BookId { get; set; }
        public int CategoryID { get; set; }

        [JsonIgnore]
        public Book? Book { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }
    }
}