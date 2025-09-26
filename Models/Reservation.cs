namespace LibraryManagementSystem.Models
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public Guid BookId { get; set; }
        public Guid MemberId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; }
        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
