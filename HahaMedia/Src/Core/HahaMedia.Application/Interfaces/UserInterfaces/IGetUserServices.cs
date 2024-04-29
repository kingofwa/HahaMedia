using HahaMedia.Application.Dtos.Account.Requests;
using HahaMedia.Application.Dtos.Account.Responses;
using HahaMedia.Application.Wrappers;
using System.Threading.Tasks;

namespace HahaMedia.Application.Interfaces.UserInterfaces
{
    public interface IGetUserServices
    {
        Task<PagedResponse<UserDto>> GetPagedUsers(GetAllUsersRequest model);
    }
}
