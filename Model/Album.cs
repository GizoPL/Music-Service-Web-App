using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Model
{
    public class Album
    {   
        public Guid Id {get; set;}  
        [Required]
        public string NameOfArtist {get; set;}
        [Required]
        public string NameOfAlbum { get; set; }
        [Required]
        public string VersionOfAlbum { get; set; }
        [Required]
        public DateTime DateOfPublication { get; set; }
        
        //Relationship
        public Guid SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        public List<Track> Tracks { get; set; }

    }
}
