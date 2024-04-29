using HahaMedia.Application.Features.Products.Commands.CreateProduct;
using HahaMedia.Application.Interfaces.Repositories;
using HahaMedia.Application.Interfaces;
using HahaMedia.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HahaMedia.Domain.Entities;

namespace HahaMedia.Application.Features.Songs.Commands.CreateSong
{
    public class CreateSongHandler(ISongRepository songRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateSongCommand, BaseResult<Guid>>
    {

        public async Task<BaseResult<Guid>> Handle(CreateSongCommand request, CancellationToken cancellationToken)
        {

            var song = new Song();

            await songRepository.AddAsync(song);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult<Guid>(song.Id);
        }
    }
}
