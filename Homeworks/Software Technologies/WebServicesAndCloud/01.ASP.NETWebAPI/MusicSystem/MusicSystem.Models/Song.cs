namespace MusicSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        public GenreType Genre { get; set; }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
