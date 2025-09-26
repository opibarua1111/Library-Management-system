using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataService
{
    public class AuthorsService : IAuthorsService
    {
        private readonly LibraryContext _context;
        public AuthorsService(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public async Task<CustomResponse> GetAuthors()
        {
            try
            {
                var response = new CustomResponse();
                response.Data = await _context.Authors.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<CustomResponse> GetAuthorById(Guid id)
        {
            try
            {
                var response = new CustomResponse();
                response.Data = await _context.Authors
                    .Include(a => a.BookAuthors)
                    .ThenInclude(ba => ba.Book)
                    .FirstOrDefaultAsync(a => a.AuthorId == id);
                
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> CreateAuthor(Author author)
        {
            try
            {
                var response = new CustomResponse();
                author.AuthorId = Guid.NewGuid();
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                response.Data = new { id = author.AuthorId };
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> UpdateAuthor(Author author)
        {
            try
            {
                var response = new CustomResponse();
                _context.Entry(author).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> DeleteAuthor(Guid id)
        {
            try
            {
                var response = new CustomResponse();
                var author = await _context.Authors.FindAsync(id);
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> GetBooksByAuthor(Guid id)
        {
            try
            {
                var response = new CustomResponse();
                var books = await _context.BookAuthors.Where(ba => ba.AuthorId == id)
                            .Include(ba => ba.Book)
                            .Select(ba => ba.Book).ToListAsync();
                response.Data = books;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
