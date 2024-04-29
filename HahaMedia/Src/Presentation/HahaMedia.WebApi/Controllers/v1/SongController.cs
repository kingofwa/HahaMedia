using HahaMedia.Application.Features.Products.Commands.CreateProduct;
using HahaMedia.Application.Features.Products.Queries.GetPagedListProduct;
using HahaMedia.Application.Features.Songs.Commands.CreateSong;
using HahaMedia.Application.Wrappers;
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
    [Authorize]
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
    }
}
