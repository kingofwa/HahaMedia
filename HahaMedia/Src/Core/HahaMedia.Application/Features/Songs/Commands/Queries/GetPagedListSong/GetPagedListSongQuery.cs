using MediatR;
using HahaMedia.Application.Parameters;
using HahaMedia.Application.Wrappers;
using HahaMedia.Domain.Products.Dtos;
using HahaMedia.Domain.Entities;
using HahaMedia.Domain.Dtos;

namespace HahaMedia.Application.Features.Songs.Commands.Queries.GetPagedListSong
{
    public class GetPagedListSongQuery : PagenationRequestParameter, IRequest<PagedResponse<SongDto>>
    {
        public string Name { get; set; }
    }
}
