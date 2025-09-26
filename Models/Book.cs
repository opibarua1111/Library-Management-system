namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public Guid CategoryId { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public Category Category { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
