using System.ComponentModel.DataAnnotations.Schema;

namespace Training_diary.Model
{
    public class TrainingSession : EFmodel
    {
        public DateTime Date { get; set; }
        public string ExerciseType { get; set; }
        public int DurationMinutes { get; set; }
        public int CaloriesBurned { get; set; }
        public string Notes { get; set; }

        public int AthleteId { get; set; }

        public Athlete Athlete { get; set; } = null!;
    }
}
