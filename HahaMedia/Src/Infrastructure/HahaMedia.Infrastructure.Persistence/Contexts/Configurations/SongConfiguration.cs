using HahaMedia.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahaMedia.Infrastructure.Persistence.Contexts.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {

        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Title).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Genre).HasMaxLength(100);
        }
    }
}