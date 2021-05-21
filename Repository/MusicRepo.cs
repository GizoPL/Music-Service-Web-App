using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dtos;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApp.Model;
using MyFirstWebApp.Repository;

namespace Repository
{
    public class MusicRepo : IMusicRepo
    {
        private readonly IMapper _mapper;
        private readonly MusicContext _context;

        public MusicRepo(MusicContext contex, IMapper mapper)
        {
            _mapper = mapper;
            _context = contex;
        }

        public AlbumReadDto GetAlbum(int Id)
        {
            var album = _context.Albums.Include(p => p.Tracks).FirstOrDefault(p => p.Id == Id);

            if (album is null)
            {
                throw new Exception("Album not found");
            }

            return _mapper.Map<AlbumReadDto>(album);
        }

        public IEnumerable<AlbumReadDto> GetAllAlbums()
        {
            return _mapper.Map<IEnumerable<AlbumReadDto>>(_context.Albums.Include(p => p.Tracks).ToList());
        }

        public IEnumerable<TrackDto> GetAllTracksFromAlbum(int Id)
        {
            return _mapper.Map<IEnumerable<TrackDto>>( _context.Tracks.Where(p => p.AlbumId == Id));
        }

        public TrackDto GetTrackFromAlbum(int Id)
        {
            var track = _context.Tracks.FirstOrDefault(p => p.Id == Id);
    
            if (track is null)
            {
                throw new Exception("Track not found");
            }

            return _mapper.Map<TrackDto>(track);
        }
    }
}