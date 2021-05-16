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
        [Key]
        public  int Id {get; set;}  
        [Required]
        public string NameOfArtist {get; set;}
        [Required]
        public string NameOfAlbum { get; set; }
        [Required]
        public string VersionOfAlbum { get; set; }
        [Required]
        public DateTime DateOfPublication { get; set; }
        
        //Relationship
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }

    }
}
