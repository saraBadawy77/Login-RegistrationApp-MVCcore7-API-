using System.ComponentModel.DataAnnotations;

namespace RegistrationApp.Models
{
    public class Registration
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a username.")]
        [MinLength(3, ErrorMessage = " at least 3 characters long.")]
       
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter a EmailAddress.")]
        [EmailAddress(ErrorMessage = "Please enter valid email address.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please enter a password.")]
        public string password { get; set; }




    }
}
