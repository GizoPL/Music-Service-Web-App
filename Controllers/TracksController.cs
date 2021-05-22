using System.Collections.Generic;
using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Model;
using Repository;

namespace Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly IMusicRepo _repository;
        private readonly IMapper _mapper;

        public TracksController(IMusicRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetAllTracksFromAlbum")]
        public ActionResult<IEnumerable<TrackReadDto>> GetAllTracksFromAlbum(int id)
        {
            var tracks = _repository.GetAllTracksFromAlbum(id);
            
            return Ok(tracks);
        }

        [HttpPost()]
        public ActionResult<TrackReadDto> CreateTrack(TrackCreateDto trackCreateDto)
        {
            var trackModel = _mapper.Map<Track>(trackCreateDto);
            _repository.CreateTrack(trackModel);
            _repository.SaveChanges();
            
            var trackReadDto = _mapper.Map<TrackReadDto>(trackModel);

            return CreatedAtRoute(nameof(GetAllTracksFromAlbum), new {Id = trackReadDto.Id}, trackCreateDto);
        }
    }
}