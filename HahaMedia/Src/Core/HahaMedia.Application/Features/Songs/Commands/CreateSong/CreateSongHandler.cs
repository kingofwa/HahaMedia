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
using Microsoft.Extensions.DependencyInjection;
using HahaMedia.Application.Mappings;
using AutoMapper;

namespace HahaMedia.Application.Features.Songs.Commands.CreateSong
{
    public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, BaseResult<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly ISongRepository _songRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSongCommandHandler(IMapper mapper, ISongRepository songRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _songRepository = songRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<Guid>> Handle(CreateSongCommand request, CancellationToken cancellationToken)
        {
            var song = _mapper.Map<CreateSongCommand, Song>(request);

            await _songRepository.AddAsync(song);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<Guid>(song.Id);
        }
    }
}
