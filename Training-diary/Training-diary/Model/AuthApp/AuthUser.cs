using System.ComponentModel.DataAnnotations;

namespace Training_diary.Model.AuthApp
{
    public class AuthUser : EFmodel
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "User"; 
    }
}