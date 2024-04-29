using MediatR;
using HahaMedia.Application.Parameters;
using HahaMedia.Application.Wrappers;
using HahaMedia.Domain.Products.Dtos;

namespace HahaMedia.Application.Features.Products.Queries.GetPagedListProduct
{
    public class GetPagedListProductQuery : PagenationRequestParameter, IRequest<PagedResponse<ProductDto>>
    {
        public string Name { get; set; }
    }
}
