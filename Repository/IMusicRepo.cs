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
        public IEnumerable<AlbumReadDto> GetAllAlbums();
        public AlbumReadDto GetAlbum(int Id);
        public IEnumerable<TrackReadDto> GetAllTracksFromAlbum(int Id);
        public TrackReadDto GetTrackFromAlbum(int Id);
        void CreateAlbum(Album album);
        void CreateTrack(Track track);
    }
}