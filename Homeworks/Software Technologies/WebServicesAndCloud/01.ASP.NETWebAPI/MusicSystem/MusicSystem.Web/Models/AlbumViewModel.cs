namespace MusicSystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using MusicSystem.Models;

    public class AlbumViewModel
    {
        public static Expression<Func<Album, AlbumViewModel>> FromDataToViewModel
        {
            get
            {
                return a => new AlbumViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Year = a.Year,
                    Genre = a.Genre,
                    ArtistsIds = a.Artists.Select(ar => ar.Id),
                    SongsIds = a.Songs.Select(s => s.Id)
                };
            }
        }

        public static Album FromViewModelToData(AlbumViewModel albumModel)
        {
            return new Album()
            {
                Title = albumModel.Title,
                Year = albumModel.Year,
                Genre = albumModel.Genre
            };
        }

        public int? Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }
        
        public GenreType Genre { get; set; }

        public IEnumerable<int> ArtistsIds { get; set; }

        public IEnumerable<int> SongsIds { get; set; }
    }
}