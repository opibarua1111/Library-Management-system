using LibraryManagementSystem.Models.response;

namespace LibraryManagementSystem.Interface
{
    public interface IFinesService
    {
        Task<CustomResponse> GetFinesForMember(Guid id);
        Task<CustomResponse> PayFine(Guid id);
    }
}
