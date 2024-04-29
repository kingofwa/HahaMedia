
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HahaMedia.Application.Dtos.Account.Requests;
using HahaMedia.Application.Dtos.Account.Responses;
using HahaMedia.Application.Interfaces.UserInterfaces;
using HahaMedia.Application.Wrappers;
using System.Threading.Tasks;

namespace HahaMedia.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class AccountController(IAccountServices accountServices) : BaseApiController
    {
        [HttpPost]
        public async Task<BaseResult<AuthenticationResponse>> Authenticate(AuthenticationRequest request)
            => await accountServices.Authenticate(request);

        [HttpPut, Authorize]
        public async Task<BaseResult> ChangeUserName(ChangeUserNameRequest model)
            => await accountServices.ChangeUserName(model);

        [HttpPut, Authorize]
        public async Task<BaseResult> ChangePassword(ChangePasswordRequest model)
            => await accountServices.ChangePassword(model);

        [HttpPost]
        public async Task<BaseResult<AuthenticationResponse>> Start()
        {
            var gostUsername = await accountServices.RegisterGostAccount();
            return await accountServices.AuthenticateByUserName(gostUsername.Data);
        }
    }
}