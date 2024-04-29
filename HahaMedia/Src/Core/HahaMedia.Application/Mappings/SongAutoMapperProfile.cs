using AutoMapper;
using HahaMedia.Application.Features.Songs.Commands.CreateSong;
using HahaMedia.Domain.Dtos;
using HahaMedia.Domain.Entities;
using HahaMedia.Domain.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaMedia.Application.Mappings
{
    public class SongAutoMapperProfile : Profile
    {
        public SongAutoMapperProfile()
        {
            CreateMap<CreateSongCommand, Song>();
        }
    }
}