using MediatR;
using HahaMedia.Application.Interfaces.Repositories;
using HahaMedia.Application.Wrappers;
using HahaMedia.Domain.Products.Dtos;
using System.Threading;
using System.Threading.Tasks;
using HahaMedia.Domain.Entities;
using HahaMedia.Domain.Dtos;

namespace HahaMedia.Application.Features.Songs.Commands.Queries.GetPagedListSong
{
    public class GetPagedListSongQueryHandler(ISongRepository songRepository) : IRequestHandler<GetPagedListSongQuery, PagedResponse<SongDto>>
    {
        public async Task<PagedResponse<SongDto>> Handle(GetPagedListSongQuery request, CancellationToken cancellationToken)
        {
            var result = await songRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);

            return new PagedResponse<SongDto>(result, request);
        }
    }
}
