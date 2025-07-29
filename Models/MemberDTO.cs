using System.ComponentModel.DataAnnotations;
namespace LIBRARY_SYSTEM.Models
{
    public class MemberDTO
    {
        public int StudentId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }
    }
}