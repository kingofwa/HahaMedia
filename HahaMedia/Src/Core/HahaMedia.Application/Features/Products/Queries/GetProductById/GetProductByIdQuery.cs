using MediatR;
using HahaMedia.Application.Wrappers;
using HahaMedia.Domain.Products.Dtos;

namespace HahaMedia.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<BaseResult<ProductDto>>
    {
        public long Id { get; set; }
    }
}
