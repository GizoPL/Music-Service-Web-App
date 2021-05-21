using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dtos;
using MyFirstWebApp.Model;

namespace Repository
{
    public interface IMusicRepo
    {
        public IEnumerable<AlbumReadDto> GetAllAlbums();
        public AlbumReadDto GetAlbum(int Id);
        public IEnumerable<TrackDto> GetAllTracksFromAlbum(int Id);
        public TrackDto GetTrackFromAlbum(int Id);
    }
}