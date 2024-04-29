using HahaMedia.Application.Dtos;
using HahaMedia.Domain.Products.Dtos;
using HahaMedia.Domain.Entities;
using System.Threading.Tasks;

namespace HahaMedia.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PagenationResponseDto<ProductDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);
    }
}
