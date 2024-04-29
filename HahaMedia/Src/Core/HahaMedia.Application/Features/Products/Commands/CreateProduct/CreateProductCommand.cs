using MediatR;
using HahaMedia.Application.Wrappers;
using System;

namespace HahaMedia.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<BaseResult<Guid>>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string BarCode { get; set; }
    }
}
