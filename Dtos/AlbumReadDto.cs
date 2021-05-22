using System;
using System.Collections.Generic;
using MyFirstWebApp.Model;

namespace Dtos
{
    public class AlbumReadDto
    {
        public int Id {get; set;}  
        public string NameOfArtist {get; set;}
        public string NameOfAlbum { get; set; }
        public string VersionOfAlbum { get; set; }
        public DateTime DateOfPublication { get; set; }
        public int SupplierId { get; set; }
        public ICollection<TrackReadDto> Tracks { get; set; }

    }
}