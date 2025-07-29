using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace LIBRARY_SYSTEM.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]  
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; } 
    }
}