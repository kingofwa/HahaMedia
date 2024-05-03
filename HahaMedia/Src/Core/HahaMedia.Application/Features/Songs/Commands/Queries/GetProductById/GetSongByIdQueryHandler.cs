using AutoMapper;
using MediatR;
using HahaMedia.Application.Helpers;
using HahaMedia.Application.Interfaces;
using HahaMedia.Application.Interfaces.Repositories;
using HahaMedia.Application.Wrappers;
using HahaMedia.Domain.Products.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HahaMedia.Domain.Entities;
using HahaMedia.Domain.Dtos;
using System.IO;
using NAudio.Wave;

namespace HahaMedia.Application.Features.Songs.Commands.Queries.GetProductById
{
    public class GetSongByIdQueryHandler(ISongRepository songRepository, IMapper mapper, ITranslator translator) : IRequestHandler<GetSongByIdQuery, BaseResult<SongDto>>
    {
        public async Task<BaseResult<SongDto>> Handle(GetSongByIdQuery request, CancellationToken cancellationToken)
        {
            var song = await songRepository.GetByIdAsync(request.Id);

            using (var mp3Stream = new MemoryStream(song.Mp3Data))
            {
                using (var mp3Reader = new Mp3FileReader(mp3Stream))
                {
                    using (var outputDevice = new WaveOutEvent())
                    {
                        outputDevice.Init(mp3Reader);
                        outputDevice.Play();

                        // Đợi cho âm thanh phát xong trước khi kết thúc phương thức
                        while (outputDevice.PlaybackState == PlaybackState.Playing)
                        {
                            //System.Threading.Thread.Sleep(100);
                        }
                    }
                }
            }

           if (song is null)
            {
                return new BaseResult<SongDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.SongMessages.Song_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            var result = mapper.Map<SongDto>(song);
            return new BaseResult<SongDto>(result);
        }
    }
}
