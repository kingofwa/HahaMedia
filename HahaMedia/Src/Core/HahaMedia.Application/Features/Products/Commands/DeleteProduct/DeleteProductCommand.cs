using MediatR;
using HahaMedia.Application.Wrappers;

namespace HahaMedia.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
