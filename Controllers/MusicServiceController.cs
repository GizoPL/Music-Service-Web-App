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

        [HttpGet]
        public ActionResult <IEnumerable<AlbumReadDto>> GetAllAlbums()
        {
            var albums = _repository.GetAllAlbums();
            return Ok(albums);
        }
        
       [HttpGet("{id}")]
       public ActionResult<AlbumReadDto> GetAlbum(int id){

        Console.WriteLine("__________________________________________________-" + id);
           var album = _repository.GetAlbum(id);
           Console.WriteLine(album);
           return Ok(album);
       }

    }
}