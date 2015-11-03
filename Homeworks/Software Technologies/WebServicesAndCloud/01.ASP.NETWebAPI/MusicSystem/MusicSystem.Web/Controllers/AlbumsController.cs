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
    public class AlbumsController : BaseController
    {
        public AlbumsController() 
            : base()
        {
        }

        public AlbumsController(IMusicSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.Data.Albums.All().Select(AlbumViewModel.FromDataToViewModel));
        }

        [HttpGet]
        public IHttpActionResult FindId(int id)
        {
            var album = this.Data.Albums.Find(a => a.Id == id)
                                          .Select(AlbumViewModel.FromDataToViewModel);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] AlbumViewModel albumModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var album = AlbumViewModel.FromViewModelToData(albumModel);
            
            this.Data.Albums.Add(album);
            this.Data.SaveChanges();

            return Created(this.Url.ToString(), album);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] AlbumViewModel albumModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var album = this.Data.Albums.All()
                                        .FirstOrDefault(a => a.Id == id);

            if (album == null)
            {
                return BadRequest("No album found with the corresponding id.");
            }

            album.Title = albumModel.Title;
            album.Year = albumModel.Year;
            album.Genre = albumModel.Genre;

            this.Data.Albums.Update(album);
            this.Data.SaveChanges();

            return Ok(album);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var album = this.Data.Albums.All()
                                        .FirstOrDefault(a => a.Id == id);

            if (album == null)
            {
                return BadRequest("No album found with the corresponding id.");
            }

            this.Data.Albums.Delete(album);
            this.Data.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult AddArtist(int albumId, int artistId)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var album = this.Data.Albums.All()
                                        .FirstOrDefault(a => a.Id == albumId);
            if (album == null)
            {
                return BadRequest("No album found with the corresponding id.");
            }

            var artist = this.Data.Artists.All()
                                        .FirstOrDefault(a => a.Id == artistId);
            if (artist == null)
            {
                return BadRequest("No artist found with the corresponding id.");
            }

            album.Artists.Add(artist);
            this.Data.SaveChanges();

            return Ok(album);
        }

        [HttpPut]
        public IHttpActionResult AddSong(int albumId, int songId)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var album = this.Data.Albums.All()
                                        .FirstOrDefault(a => a.Id == albumId);
            if (album == null)
            {
                return BadRequest("No album found with the corresponding id.");
            }

            var song = this.Data.Songs.All()
                                        .FirstOrDefault(s => s.Id == songId);
            if (song == null)
            {
                return BadRequest("No song found with the corresponding id.");
            }

            album.Songs.Add(song);
            this.Data.SaveChanges();

            return Ok(album);
        }
    }
}
