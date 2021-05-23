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

        [HttpGet("getAllTracksByAlbumId/{id}")]
        public ActionResult<IEnumerable<TrackReadDto>> GetAllTracksFromAlbum(int id)
        {
            var tracks = _repository.GetAllTracksFromAlbum(id);
            
            return Ok(_mapper.Map<IEnumerable<TrackReadDto>>(tracks));
        }

        [HttpGet("getTrack/{id}", Name ="GetSingleTrack")]
        public ActionResult<TrackReadDto> GetSingleTrack(int id){
            
            var track = _repository.GetTrackFromAlbum(id);

            if(track is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TrackReadDto>(track));
        }

        [HttpPost("createTrack")]
        public ActionResult<TrackReadDto> CreateTrack(TrackCreateDto trackCreateDto)
        {
            var trackModel = _mapper.Map<Track>(trackCreateDto);

            _repository.CreateTrack(trackModel);

            _repository.SaveChanges();
            
            var trackReadDto = _mapper.Map<TrackReadDto>(trackModel);

            return CreatedAtRoute(nameof(GetSingleTrack), new {Id = trackReadDto.Id}, trackCreateDto);
        }

        [HttpPut("updateTrack/{id}")]
        public ActionResult UpdateTrack(int id, TrackUpdateDto trackUpdateDto)
        {
            var trackModel = _repository.GetTrackFromAlbum(id);
            
            if(trackModel is null)
            {
                return NotFound();
            }
            _mapper.Map(trackUpdateDto, trackModel);

            _repository.UpdateTrack(trackModel);

            _repository.SaveChanges();

            return NoContent();
        }

         [HttpDelete("deleteTrack/{id}")]
       public ActionResult DeleteTrack(int id)
       {
           var track = _repository.GetTrackFromAlbum(id);
           
           if(track is null)
           {
               return NotFound();
           }

           _repository.DeleteTrack(track);

           _repository.SaveChanges();

           return NoContent();
       }
    }
}