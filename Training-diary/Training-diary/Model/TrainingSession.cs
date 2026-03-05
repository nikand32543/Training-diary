namespace Training_diary.Model
{
    public class TrainingSession : EFmodel
    {
        public DateTime Date { get; set; }
        public string ExerciseType { get; set; }
        public int DurationMinutes { get; set; }
        public int CaloriesBurned { get; set; }
        public string Notes { get; set; }
    }
}
