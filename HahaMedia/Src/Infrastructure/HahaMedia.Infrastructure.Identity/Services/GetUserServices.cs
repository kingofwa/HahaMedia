using Microsoft.EntityFrameworkCore;
using HahaMedia.Application.Dtos.Account.Requests;
using HahaMedia.Application.Dtos.Account.Responses;
using HahaMedia.Application.Dtos;
using HahaMedia.Application.Interfaces.UserInterfaces;
using HahaMedia.Application.Wrappers;
using HahaMedia.Infrastructure.Identity.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace HahaMedia.Infrastructure.Identity.Services
{
    public class GetUserServices(IdentityContext identityContext) : IGetUserServices
    {
        public async Task<PagedResponse<UserDto>> GetPagedUsers(GetAllUsersRequest model)
        {
            var skip = (model.PageNumber - 1) * model.PageSize;

            var users = await identityContext.Users
                .Skip(skip)
                .Take(model.PageSize)
                .Select(p => new UserDto()
                {
                    Name = p.Name,
                    Email = p.Email,
                    UserName = p.UserName,
                    PhoneNumber = p.PhoneNumber,
                    Id = p.Id,
                    Created = p.Created,
                }).ToListAsync();

            var result = new PagenationResponseDto<UserDto>(users, await identityContext.Users.CountAsync());

            return new PagedResponse<UserDto>(result, model.PageNumber, model.PageSize);
        }
    }
}
