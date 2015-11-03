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
    public class SongsController : BaseController
    {
        public SongsController()
            : base()
        {
        }

        public SongsController(IMusicSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.Data.Songs.All().Select(SongViewModel.FromDataToViewModel));
        }

        [HttpGet]
        public IHttpActionResult FindId(int id)
        {
            var song = this.Data.Songs.Find(a => a.Id == id)
                                      .Select(SongViewModel.FromDataToViewModel);

            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] SongViewModel songModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var song = SongViewModel.FromViewModelToData(songModel);

            this.Data.Songs.Add(song);
            this.Data.SaveChanges();

            return Created(this.Url.ToString(), song);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] SongViewModel songModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var song = this.Data.Songs.All()
                                      .FirstOrDefault(s => s.Id == id);

            if (song == null)
            {
                return BadRequest("No song found with the corresponding id.");
            }

            song.Title = songModel.Title;
            song.Genre = songModel.Genre;
            song.Year = songModel.Year;

            this.Data.Songs.Update(song);
            this.Data.SaveChanges();

            return Ok(song);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var song = this.Data.Songs.All()
                                      .FirstOrDefault(a => a.Id == id);

            if (song == null)
            {
                return BadRequest("No song found with the corresponding id.");
            }

            this.Data.Songs.Delete(song);
            this.Data.SaveChanges();

            return Ok();
        }
    }
}
