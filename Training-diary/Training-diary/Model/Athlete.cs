using System.ComponentModel.DataAnnotations;

namespace Training_diary.Model
{
    public class Athlete : EFmodel
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<TrainingSession> TrainingSessions { get; set; } = new List<TrainingSession>();
    }
}
