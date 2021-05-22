using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dtos;
using MyFirstWebApp.Model;

namespace Repository
{
    public interface IMusicRepo
    {
        bool SaveChanges();
        void CreateAlbum(Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbum(Album album);
        public IEnumerable<Album> GetAllAlbums();
        public Album GetAlbum(int Id);
        
        void CreateTrack(Track track);
        void UpdateTrack(Track track);
        void DeleteTrack(Track track);
        public IEnumerable<Track> GetAllTracksFromAlbum(int Id);
        public Track GetTrackFromAlbum(int Id);
    }
}