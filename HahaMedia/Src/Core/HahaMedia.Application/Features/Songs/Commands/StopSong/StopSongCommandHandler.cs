using MediatR;
using HahaMedia.Application.Helpers;
using HahaMedia.Application.Interfaces;
using HahaMedia.Application.Interfaces.Repositories;
using HahaMedia.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;
using System.IO;

namespace HahaMedia.Application.Features.Songs.Commands.StopSong
{
    public class StopSongCommandHandler(ISongRepository songRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<StopSongCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(StopSongCommand request, CancellationToken cancellationToken)
        {
            var song = await songRepository.GetByIdAsync(request.Id);

            if (song is null)
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }


            using (var mp3Stream = new MemoryStream(song.Mp3Data))
            {
                using (var mp3Reader = new Mp3FileReader(mp3Stream))
                {
                    using (var outputDevice = new WaveOutEvent())
                    {
                        outputDevice.Stop();
                    }
                }
            }

            return new BaseResult();
        }
    }
}
