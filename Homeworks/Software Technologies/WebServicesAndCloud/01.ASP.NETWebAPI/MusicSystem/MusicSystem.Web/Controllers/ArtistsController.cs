namespace MusicSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Data;
    using MusicSystem.Web.Models;
    using MusicSystem.Models;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ArtistsController : BaseController
    {
        public ArtistsController() 
            : base()
        {
        }

        public ArtistsController(IMusicSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.Data.Artists.All().Select(ArtistViewModel.FromDataToViewModel));
        }

        [HttpGet]
        public IHttpActionResult FindId(int id)
        {
            var artist = this.Data.Artists.Find(a => a.Id == id)
                                          .Select(ArtistViewModel.FromDataToViewModel);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] ArtistViewModel artistModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var artist = ArtistViewModel.FromViewModelToData(artistModel);

            this.Data.Artists.Add(artist);
            this.Data.SaveChanges();

            return Created(this.Url.ToString(), artist);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] ArtistViewModel artistModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var artist = this.Data.Artists.All()
                                          .FirstOrDefault(a => a.Id == id);

            if (artist == null)
            {
                return BadRequest("No artist found with the corresponding id.");
            }

            artist.Name = artistModel.Name;
            artist.DateOfBirth = artistModel.DateOfBirth;
            artist.Country = artistModel.Country;

            this.Data.Artists.Update(artist);
            this.Data.SaveChanges();

            return Ok(artist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var artist = this.Data.Artists.All()
                                          .FirstOrDefault(a => a.Id == id);

            if (artist == null)
            {
                return BadRequest("No artist found with the corresponding id.");
            }

            this.Data.Artists.Delete(artist);
            this.Data.SaveChanges();

            return Ok();
        }
    }
}
