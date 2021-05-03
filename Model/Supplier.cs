using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Model
{
    public class Supplier
    { 
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        
        //Relationship
        public List<Album> Albums { get; set; }
    }
}
