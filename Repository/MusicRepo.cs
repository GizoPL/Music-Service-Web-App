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
     
        private readonly MusicContext _context;

        public MusicRepo(MusicContext contex)
        {
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

        public void DeleteAlbum(Album album)
        {
            if(album is null)
            {
                throw new ArgumentNullException(nameof(album));
            }
            
            _context.Albums.Remove(album);
        }

        public void DeleteTrack(Track track)
        {
             if(track is null)
            {
                throw new ArgumentNullException(nameof(track));
            }
            
            _context.Tracks.Remove(track);
        }

        public Album GetAlbum(int Id)
        {
            var album = _context.Albums.Include(p => p.Tracks).FirstOrDefault(p => p.Id == Id);

            if (album is null)
            {
                throw new Exception("Album not found");
            }

            return album;
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return _context.Albums.Include(p => p.Tracks).ToList();
        }

        public IEnumerable<Track> GetAllTracksFromAlbum(int Id)
        {
            return  _context.Tracks.Where(p => p.AlbumId == Id);
        }

        public Track GetTrackFromAlbum(int Id)
        {
            var track = _context.Tracks.FirstOrDefault(p => p.Id == Id);
    
            if (track is null)
            {
                throw new Exception("Track not found");
            }

            return track;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0 );
        }

        public void UpdateAlbum(Album album){}

        public void UpdateTrack(Track track){}
    }
}