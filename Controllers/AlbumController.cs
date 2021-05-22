using System;
using System.Collections.Generic;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Model;
using Repository;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMusicRepo _repository;

        public AlbumController(IMusicRepo repository)
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

           var album = _repository.GetAlbum(id);
           
           if(album is null)
           {
               return NotFound();
           }

           return Ok(album);
       }

    }
}