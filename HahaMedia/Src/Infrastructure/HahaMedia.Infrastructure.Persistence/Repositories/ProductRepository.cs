using Microsoft.EntityFrameworkCore;
using HahaMedia.Application.Dtos;
using HahaMedia.Application.Interfaces.Repositories;
using HahaMedia.Domain.Products.Dtos;
using HahaMedia.Domain.Entities;
using HahaMedia.Infrastructure.Persistence.Contexts;
using System.Linq;
using System.Threading.Tasks;
using HahaMedia.Infrastructure.Identity.Models;

namespace HahaMedia.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DbSet<Product> products;
        private readonly DbSet<ApplicationUser> users;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            products = dbContext.Set<Product>();
            users = dbContext.Set<ApplicationUser>();
        }

        public async Task<PagenationResponseDto<ProductDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
        {
            var query = products.OrderBy(p => p.Created).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            var joinedQuery = query.Join(users, product => product.CreatedBy, user => user.Id, (product, user) => new ProductDto(product, user.UserName));

            return await Paged(
                joinedQuery,
                pageNumber,
                pageSize);

        }
    }
}
