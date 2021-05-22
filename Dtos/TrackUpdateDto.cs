using System.ComponentModel.DataAnnotations;

namespace Dtos
{
    public class TrackUpdateDto
    {
        [Required]
        public string NameOfTrack { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int AlbumId { get; set; }

    }
}