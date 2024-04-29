using MediatR;
using HahaMedia.Application.Interfaces.Repositories;
using HahaMedia.Application.Wrappers;
using HahaMedia.Domain.Products.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace HahaMedia.Application.Features.Products.Queries.GetPagedListProduct
{
    public class GetPagedListProductQueryHandler(IProductRepository productRepository) : IRequestHandler<GetPagedListProductQuery, PagedResponse<ProductDto>>
    {
        public async Task<PagedResponse<ProductDto>> Handle(GetPagedListProductQuery request, CancellationToken cancellationToken)
        {
            var result = await productRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);

            return new PagedResponse<ProductDto>(result, request);
        }
    }
}
