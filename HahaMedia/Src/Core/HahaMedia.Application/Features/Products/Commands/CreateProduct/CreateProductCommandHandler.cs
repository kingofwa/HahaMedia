using MediatR;
using HahaMedia.Application.Interfaces;
using HahaMedia.Application.Interfaces.Repositories;
using HahaMedia.Application.Wrappers;
using HahaMedia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace HahaMedia.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, BaseResult<long>>
    {
        public async Task<BaseResult<long>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Price, request.BarCode);

            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult<long>(product.Id);
        }
    }
}
