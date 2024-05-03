using HahaMedia.Application.Features.Products.Commands.CreateProduct;
using HahaMedia.Application.Features.Products.Commands.UpdateProduct;
using HahaMedia.Application.Features.Products.Queries.GetPagedListProduct;
using HahaMedia.Application.Features.Products.Queries.GetProductById;
using HahaMedia.Application.Features.Songs.Commands.CreateSong;
using HahaMedia.Application.Features.Songs.Commands.Queries.GetPagedListSong;
using HahaMedia.Application.Features.Songs.Commands.Queries.GetProductById;
using HahaMedia.Application.Features.Songs.Commands.StopSong;
using HahaMedia.Application.Wrappers;
using HahaMedia.Domain.Dtos;
using HahaMedia.Domain.Products.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HahaMedia.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    //[Authorize]
    public class SongController : BaseApiController
    {
        private readonly ILogger<SongController> _logger;

        public SongController(ILogger<SongController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<BaseResult<Guid>> CreateSong(CreateSongCommand model)
           => await Mediator.Send(model);

        [HttpGet]
        public async Task<PagedResponse<SongDto>> GetPagedListSong([FromQuery] GetPagedListSongQuery model)
        {
            _logger.LogInformation("Start request!!!");
            return await Mediator.Send(model);
        }

        [HttpGet]
        public async Task<BaseResult<SongDto>> GetSongById([FromQuery] GetSongByIdQuery model)
           => await Mediator.Send(model);


        [HttpPost]
        public async Task<BaseResult> StopSong(StopSongCommand model)
           => await Mediator.Send(model);
        
    }
}
