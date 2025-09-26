using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataService
{
    public class CategoriesService : ICategoriesService
    {
        private readonly LibraryContext _context;
        public CategoriesService(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public async Task<CustomResponse> GetCategories()
        {
            try
            {
                var response = new CustomResponse();
                response.Data = await _context.Categories.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<CustomResponse> CreateCategory(Category category)
        {
            try
            {
                var response = new CustomResponse();
                category.CategoryId = Guid.NewGuid();
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                response.Data = new { id = category.CategoryId };
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> UpdateCategory(Category category)
        {
            try
            {
                var response = new CustomResponse();
                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> DeleteCategory(Guid id)
        {
            try
            {
                var response = new CustomResponse();
                var category = await _context.Categories.FindAsync(id);
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
