using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Training_diary.Model
{
    public class TrainingSession : EFmodel
    {
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string ExerciseType { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public int CaloriesBurned { get; set; }
        public string Notes { get; set; }

        public int? AthleteId { get; set; }

        public Athlete? Athlete { get; set; } //= new Athlete();
    }
}
