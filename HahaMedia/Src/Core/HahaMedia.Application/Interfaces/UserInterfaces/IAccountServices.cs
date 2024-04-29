using HahaMedia.Application.Dtos.Account.Requests;
using HahaMedia.Application.Dtos.Account.Responses;
using HahaMedia.Application.Wrappers;
using System.Threading.Tasks;

namespace HahaMedia.Application.Interfaces.UserInterfaces
{
    public interface IAccountServices
    {
        Task<BaseResult<string>> RegisterGostAccount();
        Task<BaseResult> ChangePassword(ChangePasswordRequest model);
        Task<BaseResult> ChangeUserName(ChangeUserNameRequest model);
        Task<BaseResult<AuthenticationResponse>> Authenticate(AuthenticationRequest request);
        Task<BaseResult<AuthenticationResponse>> AuthenticateByUserName(string username);

    }
}
