using System.ComponentModel.DataAnnotations;

namespace Dtos
{
    public class SupplierRegisterDto
    {
        
        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        public string ConfirmPassword {get; set;}
        
    }
}