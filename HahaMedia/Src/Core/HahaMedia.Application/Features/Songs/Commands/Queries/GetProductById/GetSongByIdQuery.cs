using MediatR;
using HahaMedia.Application.Wrappers;
using HahaMedia.Domain.Products.Dtos;
using HahaMedia.Domain.Entities;
using HahaMedia.Domain.Dtos;
using System;

namespace HahaMedia.Application.Features.Songs.Commands.Queries.GetProductById
{
    public class GetSongByIdQuery : IRequest<BaseResult<SongDto>>
    {
        public Guid Id { get; set; }
    }
}
