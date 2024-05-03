using HahaMedia.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaMedia.Application.Features.Songs.Commands.StopSong
{
    public class StopSongCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}

