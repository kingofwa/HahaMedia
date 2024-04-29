using HahaMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HahaMedia.Domain.Dtos
{
    public class SongDto
    {
        public SongDto()
        {
        }
        public SongDto(Song song, string userName)
        {
            Id = song.Id;
            Title = song.Title;
            Genre = song.Genre;
            UserName = userName;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string UserName { get; set; }
    }
}
