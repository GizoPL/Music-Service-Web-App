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
        [Key]
        public int Id { get; set; }
      
        [Required]
        public string NameOfTrack { get; set; }

        [Required]
        public string Duration { get; set; }
     
        //Relationship
        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }
    }
}
