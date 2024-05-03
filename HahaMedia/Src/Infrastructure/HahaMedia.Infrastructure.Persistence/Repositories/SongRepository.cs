using HahaMedia.Application.Dtos;
using HahaMedia.Application.Interfaces.Repositories;
using HahaMedia.Domain.Dtos;
using HahaMedia.Domain.Entities;
using HahaMedia.Domain.Products.Dtos;
using HahaMedia.Infrastructure.Identity.Models;
using HahaMedia.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaMedia.Infrastructure.Persistence.Repositories
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        private readonly DbSet<Song> songs;
        private readonly DbSet<ApplicationUser> users;
        public SongRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            songs = dbContext.Set<Song>();
            users = dbContext.Set<ApplicationUser>();
        }

        public async Task<PagenationResponseDto<SongDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
        {
            var query = songs.OrderBy(p => p.Created).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Title.Contains(name));
            }

            var joinedQuery = query.GroupJoin(
                users,
                s => s.CreatedBy,
                user => user.Id,
                (s, userList) => new { Song = s, Users = userList }
            ).SelectMany(
                x => x.Users.DefaultIfEmpty(),
                (song, user) => new SongDto(song.Song, user != null ? "Abc" : "")
            );

            return await Paged(
                joinedQuery,
                pageNumber,
                pageSize);
        }
    }
}
