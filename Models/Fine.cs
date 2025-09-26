namespace LibraryManagementSystem.Models
{
    public class Fine
    {
        public Guid FineId { get; set; }
        public Guid LoanId { get; set; }
        public decimal Amount { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaidDate { get; set; }
        public Loan Loan { get; set; }
    }
}
