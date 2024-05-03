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
            Artist = song.Artist;
            Genre = song.Genre;
            UserName = userName;
            Mp3Data = song.Mp3Data;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Artist { get; set; }
        public string UserName { get; set; }
        public byte[] Mp3Data { get; set; }
    }
}
