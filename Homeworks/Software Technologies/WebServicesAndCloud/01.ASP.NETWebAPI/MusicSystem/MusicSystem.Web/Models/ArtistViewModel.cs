namespace MusicSystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using MusicSystem.Models;

    public class ArtistViewModel
    {
        public static Expression<Func<Artist, ArtistViewModel>> FromDataToViewModel
        {
            get
            {
                return a => new ArtistViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Country = a.Country,
                    DateOfBirth = a.DateOfBirth
                };
            }
        }

        public static Artist FromViewModelToData(ArtistViewModel artistModel)
        {
            return new Artist()
            {
                Name = artistModel.Name,
                Country = artistModel.Country,
                DateOfBirth = artistModel.DateOfBirth
            };
        }

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}