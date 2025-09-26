namespace LibraryManagementSystem.Models
{
    public class Loan
    {
        public Guid LoanId { get; set; }
        public Guid BookId { get; set; }
        public Guid MemberId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
