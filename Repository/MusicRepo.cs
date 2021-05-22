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

        public void CreateAlbum(Album album)
        {
            if(album == null)
            {
                throw new ArgumentNullException(nameof(album));
            }

            _context.Albums.Add(album);
        }

        public void CreateTrack(Track track)
        {
             if(track == null)
            {
                throw new ArgumentNullException(nameof(track));
            }

            _context.Tracks.Add(track);
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

        public IEnumerable<TrackReadDto> GetAllTracksFromAlbum(int Id)
        {
            return _mapper.Map<IEnumerable<TrackReadDto>>( _context.Tracks.Where(p => p.AlbumId == Id));
        }

        public TrackReadDto GetTrackFromAlbum(int Id)
        {
            var track = _context.Tracks.FirstOrDefault(p => p.Id == Id);
    
            if (track is null)
            {
                throw new Exception("Track not found");
            }

            return _mapper.Map<TrackReadDto>(track);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0 );
        }
    }
}