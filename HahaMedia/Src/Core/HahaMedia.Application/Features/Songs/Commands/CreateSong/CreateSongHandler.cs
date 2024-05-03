using HahaMedia.Application.Features.Products.Commands.CreateProduct;
using HahaMedia.Application.Interfaces.Repositories;
using HahaMedia.Application.Interfaces;
using HahaMedia.Application.Wrappers;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using HahaMedia.Domain.Entities;
using AutoMapper;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace HahaMedia.Application.Features.Songs.Commands.CreateSong
{
    public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, BaseResult<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly ISongRepository _songRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSongCommandHandler( IMapper mapper, ISongRepository songRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _songRepository = songRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<Guid>> Handle(CreateSongCommand request, CancellationToken cancellationToken)
        {
            var song = _mapper.Map<CreateSongCommand, Song>(request);

            // Đọc dữ liệu từ file mp3
            byte[] mp3Data;
            using (var stream = request.Mp3File.OpenReadStream())
            using (var ms = new MemoryStream())
            {
                await stream.CopyToAsync(ms, cancellationToken);
                mp3Data = ms.ToArray();
            }

            song.Mp3Data = mp3Data;

            await _songRepository.AddAsync(song);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<Guid>(song.Id);
        }




        private async Task<string> UploadFileToGoogleDrive(IFormFile mp3File)
        {
            // Lưu tệp MP3 vào ổ đĩa tạm thời
            var tempFilePath = Path.GetTempFileName();
            using (var fileStream = new FileStream(tempFilePath, FileMode.Create))
            {
                await mp3File.CopyToAsync(fileStream);
            }

            // Tải lên tệp lên Google Drive
            var driveFileId = await UploadFileToGoogleDrive(tempFilePath, mp3File.FileName);

            // Xóa tệp tạm thời sau khi đã tải lên Google Drive
            File.Delete(tempFilePath);

            return driveFileId;
        }


        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";

        public async Task<string> UploadFileToGoogleDrive(string filePath, string fileName)
        {

            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }

            Console.Read();

            return Guid.NewGuid().ToString();
        }



    }
}
