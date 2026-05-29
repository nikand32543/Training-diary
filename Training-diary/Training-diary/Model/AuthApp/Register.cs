using System.ComponentModel.DataAnnotations;

namespace Training_diary.Model.AuthApp
{
    public class Register
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}