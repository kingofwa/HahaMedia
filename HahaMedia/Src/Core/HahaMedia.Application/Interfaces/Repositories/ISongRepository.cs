using HahaMedia.Application.Dtos;
using HahaMedia.Domain.Dtos;
using HahaMedia.Domain.Entities;
using HahaMedia.Domain.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaMedia.Application.Interfaces.Repositories
{
    public interface ISongRepository : IGenericRepository<Song>
    {
        Task<PagenationResponseDto<SongDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);
    }
}
