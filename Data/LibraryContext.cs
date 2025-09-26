using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite Key for BookAuthor
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            // Auto-generate GUID IDs for all entities
            modelBuilder.Entity<Book>().Property(b => b.BookId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Author>().Property(a => a.AuthorId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Category>().Property(c => c.CategoryId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Member>().Property(m => m.MemberId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Loan>().Property(l => l.LoanId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Fine>().Property(f => f.FineId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Reservation>().Property(r => r.ReservationId).HasDefaultValueSql("NEWID()");
        }
    }
}
