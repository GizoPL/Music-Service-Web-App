using System;

namespace Dtos
{
    public class AlbumCreateDto
    {
        public string NameOfArtist {get; set;}
        public string NameOfAlbum { get; set; }
        public string VersionOfAlbum { get; set; }
        public DateTime DateOfPublication { get; set; }
        public int SupplierId { get; set; }
        
    }
}