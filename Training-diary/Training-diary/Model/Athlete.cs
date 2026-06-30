using System.ComponentModel.DataAnnotations;

namespace Training_diary.Model
{
    public class Athlete : EFmodel
    {
        [Required(ErrorMessage = "Email обязателен для заполнения")]
        [EmailAddress(ErrorMessage = "Некорректный формат почты")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Номер телефона обязателен")]
        [Phone(ErrorMessage = "Введите корректный номер телефона")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Укажите дату рождения")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public ICollection<TrainingSession> TrainingSessions { get; set; } = new List<TrainingSession>();
    }
}
