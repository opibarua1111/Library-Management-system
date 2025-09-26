using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;

namespace LibraryManagementSystem.Interface
{
    public interface IMembersService
    {
        Task<CustomResponse> CreateMember(Member member);
        Task<CustomResponse> DeleteMember(Guid id);
        Task<CustomResponse> GetLoanHistory(Guid id);
        Task<CustomResponse> GetMemberById(Guid id);
        Task<CustomResponse> GetMembers();
        Task<CustomResponse> GetReservations(Guid id);
        Task<CustomResponse> UpdateMember(Member member);
    }
}
