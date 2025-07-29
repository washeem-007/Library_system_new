using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace LIBRARY_SYSTEM.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public List<BookCategory>? BookCategories { get; set; }
    }
}