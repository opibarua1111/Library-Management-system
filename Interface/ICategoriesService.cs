using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;

namespace LibraryManagementSystem.Interface
{
    public interface ICategoriesService
    {
        Task<CustomResponse> CreateCategory(Category category);
        Task<CustomResponse> DeleteCategory(Guid id);
        Task<CustomResponse> GetCategories();
        Task<CustomResponse> UpdateCategory(Category category);
    }
}
