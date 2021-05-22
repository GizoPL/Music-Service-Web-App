using System;
using System.ComponentModel.DataAnnotations;

namespace Dtos
{
    public class AlbumUpdateDto
    {
        [Required]
        public string NameOfArtist {get; set;}
        [Required]
        public string NameOfAlbum { get; set; }
        [Required]
        public string VersionOfAlbum { get; set; }
        [Required]
        public DateTime DateOfPublication { get; set; }
        [Required]
        public int SupplierId { get; set; }
    }
}