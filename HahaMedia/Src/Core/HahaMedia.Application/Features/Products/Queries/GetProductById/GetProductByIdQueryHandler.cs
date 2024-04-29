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

namespace HahaMedia.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper, ITranslator translator) : IRequestHandler<GetProductByIdQuery, BaseResult<ProductDto>>
    {
        public async Task<BaseResult<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return new BaseResult<ProductDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            var result = mapper.Map<ProductDto>(product);
            return new BaseResult<ProductDto>(result);
        }
    }
}
