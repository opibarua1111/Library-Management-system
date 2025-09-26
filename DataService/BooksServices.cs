using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataService
{
    public class BooksServices : IBooksServices
    {
        private readonly LibraryContext _context; 
        public BooksServices( LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public async Task<CustomResponse> GetBooks()
        {
            try
            {
                var response = new CustomResponse();
                response.Data = await _context.Books
                                        .Include(b => b.Category)
                                        .Include(b => b.BookAuthors)
                                        .ThenInclude(ba => ba.Author).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> GetBookById(Guid id)
        {
            try
            {
                var response = new CustomResponse();
                response.Data = await _context.Books.Include(b => b.Category)
                                           .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
                                           .FirstOrDefaultAsync(b => b.BookId == id);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<CustomResponse> CreateBook(Book book)
        {
            try
            {
                var response = new CustomResponse();
                book.BookId = Guid.NewGuid();
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                response.Data = new { id = book.BookId };
                response.Message = "Book Create Successfull";
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<CustomResponse> UpdateBook(Book book)
        {
            try
            {
                var response = new CustomResponse();
                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                response.Message = "Book update Successfull";
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> DeleteBookById(Guid id)
        {
            try
            {
                var response = new CustomResponse();
                var book = await _context.Books.FindAsync(id);
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                response.Message = "Book delete Successfull";
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<CustomResponse> UpdateAvailability(Guid id, int change)
        {
            try
            {
                var response = new CustomResponse();
                var book = await _context.Books.FindAsync(id);
                book.AvailableCopies += change;
                await _context.SaveChangesAsync();
                response.Data = book;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
