using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyFirstWebApp.Model;

namespace Dtos
{
    public class SupplierReadDto
    {
        
        public int Id { get; set; }
        
        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
    }
}