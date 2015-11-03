namespace MusicSystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using MusicSystem.Models;

    public class SongViewModel
    {
        public static Expression<Func<Song, SongViewModel>> FromDataToViewModel
        {
            get
            {
                return s => new SongViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Year = s.Year,
                    Genre = s.Genre,
                    Artist = s.Artist.Name,
                    Album = s.Album.Title
                };
            }
        }

        public static Song FromViewModelToData(SongViewModel songModel)
        {
            return new Song()
            {
                Title = songModel.Title,
                Year = songModel.Year,
                Genre = songModel.Genre
            };
        }

        public int? Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        public GenreType Genre { get; set; }

        public string Album { get; set; }

        public string Artist { get; set; }
    }
}