using System.Collections.Generic;

namespace LIBRARY_SYSTEM.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public string? BookId { get; set; }
        public string? MemberId { get; set; }
        public string? LoanDate { get; set; }
        public string? ReturnDate { get; set; }
    }
}