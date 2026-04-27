using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_diary.Data;
using Training_diary.Model;

namespace Training_diary.Pages.Training
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TrainingSession> Trainings { get; set; } = new List<TrainingSession>();

        public void OnGet()
        {
            Trainings = _context.TrainingSessions
                .Include(t => t.Athlete)
                .OrderByDescending(t => t.Date)
                .ToList();
        }
    }
}