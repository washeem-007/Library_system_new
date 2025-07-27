using System.Collections.Generic;

namespace LIBRARY_SYSTEM.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public List<BookCategory>? BookCategories { get; set; }
    }
}