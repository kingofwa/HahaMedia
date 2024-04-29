using HahaMedia.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaMedia.Application.Features.Songs.Commands.CreateSong
{
    public class CreateSongCommand : IRequest<BaseResult<Guid>>
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int? Duration { get; set; } 
        public string Genre { get; set; }
    }
}
