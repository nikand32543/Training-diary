using System.ComponentModel.DataAnnotations;

namespace Training_diary.Model
{
    public class EFmodel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле Имя не может быть пустым")]
        public string Name { get; set; }
    }
}
