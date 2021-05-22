using System;
using System.Collections.Generic;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AlbumController(IMusicRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<AlbumReadDto>> GetAllAlbums()
        {
            var albums = _repository.GetAllAlbums();

            if(albums is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<AlbumReadDto>>(albums));
        }
        
       [HttpGet("{id}", Name = "GetAlbum")]
       public ActionResult<AlbumReadDto> GetAlbum(int id)
       {
           var album = _repository.GetAlbum(id);
           
           if(album is null)
           {
               return NotFound();
           }

           return Ok(_mapper.Map<AlbumReadDto>(album));
       }

       [HttpPost]
       public ActionResult<AlbumReadDto> CreateAlbum(AlbumCreateDto albumCreateDto)
       {
            var albumModel = _mapper.Map<Album>(albumCreateDto);

            _repository.CreateAlbum(albumModel);

            _repository.SaveChanges();

            var albumReadDto = _mapper.Map<AlbumReadDto>(albumModel);

            return CreatedAtRoute(nameof(GetAlbum), new {Id = albumReadDto.Id}, albumCreateDto);
       }

       [HttpPut("{id}")]
       public ActionResult UpdateAlbum(int id, AlbumUpdateDto albumUpdateDto)
       {
            var albumModel = _repository.GetAlbum(id);

            if(albumModel is null)
            {
                return NotFound();
            }

            _mapper.Map(albumUpdateDto, albumModel);

            _repository.UpdateAlbum(albumModel);

            _repository.SaveChanges();

            return NoContent();
       }

       [HttpDelete("{id}")]
       public ActionResult DeleteAlbum(int id)
       {
           var album = _repository.GetAlbum(id);
           
           if(album is null)
           {
               return NotFound();
           }

           _repository.DeleteAlbum(album);

           _repository.SaveChanges();

           return NoContent();
       }

    }
}