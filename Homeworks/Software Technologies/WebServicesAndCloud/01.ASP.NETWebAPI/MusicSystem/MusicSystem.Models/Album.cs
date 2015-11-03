namespace MusicSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        private ICollection<Song> songs;
        private ICollection<Artist> artists;

        public Album()
        {
            this.artists = new HashSet<Artist>();
            this.songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        public GenreType Genre { get; set; }

        public virtual ICollection<Artist> Artists
        {
            get { return this.artists; }
            set { this.artists = value; }
        }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

    }
}
