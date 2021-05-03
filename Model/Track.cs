using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Model
{
    public class Track
    {   
        public Guid Id { get; set; }
      
        [Required]
        public string NameOfTrack { get; set; }

        [Required]
        public string Duration { get; set; }
     
        //Relationship
        public Guid AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public Album Album { get; set; }
    }
}
