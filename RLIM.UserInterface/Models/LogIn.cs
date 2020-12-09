using System.ComponentModel.DataAnnotations;

namespace RLIM.UserInterface.Models
{
    public class LogIn
    {
        [Required(ErrorMessage = "You need to give us your Username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You need to give us your Password.")]
        public string Password { get; set; }
    }
}
