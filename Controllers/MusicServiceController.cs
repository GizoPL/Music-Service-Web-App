using System;
using System.Collections.Generic;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Model;
using Repository;

namespace Controllers
{
    [Route("api/MusicService")]
    [ApiController]
    public class MusicServiceController : ControllerBase
    {
        private readonly IMusicRepo _repository;

        public MusicServiceController(IMusicRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("/Albums")]
        public ActionResult <IEnumerable<AlbumReadDto>> GetAllAlbums()
        {
            var albums = _repository.GetAllAlbums();
            return Ok(albums);
        }
        
       [HttpGet("/Album/{id}")]
       public ActionResult<AlbumReadDto> GetAlbum(int id){

           var album = _repository.GetAlbum(id);
           return Ok(album);
       }

       
        [HttpGet("/Tracks/{id}")]
        public ActionResult<IEnumerable<TrackDto>> GetAllTracksFromAlbum(int id)
        {
            var tracks = _repository.GetAllTracksFromAlbum(id);
            
            return Ok(tracks);
        }

        [HttpGet("/Track/{id}")]
        public ActionResult<TrackDto> GetTrackFromAlbum(int id)
        {
            var track = _repository.GetTrackFromAlbum(id);
            return Ok(track);
        }

    }
}