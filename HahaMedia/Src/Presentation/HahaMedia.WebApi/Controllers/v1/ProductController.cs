using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HahaMedia.Application.Features.Products.Commands.CreateProduct;
using HahaMedia.Application.Features.Products.Commands.DeleteProduct;
using HahaMedia.Application.Features.Products.Commands.UpdateProduct;
using HahaMedia.Application.Features.Products.Queries.GetPagedListProduct;
using HahaMedia.Application.Features.Products.Queries.GetProductById;
using HahaMedia.Application.Wrappers;
using HahaMedia.Domain.Products.Dtos;
using System.Threading.Tasks;

namespace HahaMedia.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class ProductController : BaseApiController
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<PagedResponse<ProductDto>> GetPagedListProduct([FromQuery] GetPagedListProductQuery model)
        {
            _logger.LogInformation("Start request!!!");
            return await Mediator.Send(model);
        }

        [HttpGet]
        public async Task<BaseResult<ProductDto>> GetProductById([FromQuery] GetProductByIdQuery model)
            => await Mediator.Send(model);

        [HttpPost, Authorize]
        public async Task<BaseResult<long>> CreateProduct(CreateProductCommand model)
            => await Mediator.Send(model);

        [HttpPut, Authorize]
        public async Task<BaseResult> UpdateProduct(UpdateProductCommand model)
            => await Mediator.Send(model);

        [HttpDelete, Authorize]
        public async Task<BaseResult> DeleteProduct([FromQuery] DeleteProductCommand model)
            => await Mediator.Send(model);

    }
}