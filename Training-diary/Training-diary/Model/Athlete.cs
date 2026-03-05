using System.ComponentModel.DataAnnotations;

namespace Training_diary.Model
{
    public class Athlete : EFmodel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
