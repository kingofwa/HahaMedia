using HahaMedia.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace HahaMedia.Domain.Entities
{
    public class Song : AuditableBaseEntity
    {
        public Song()
        {
            Id = Guid.NewGuid();
        }
        public string Title { get; set; }
        public string Artist { get; set; }

        public int? Duration { get; set; } // Dùng int? để cho phép giá trị null

        public string Genre { get; set; }

        public byte[] Mp3Data { get; set; }
    }
}
