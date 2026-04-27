using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_diary.Data;
using Training_diary.Model;

namespace Training_diary.Pages.Training
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public TrainingSession Training { get; set; } = null!;

        public IActionResult OnGet(int id)
        {
            Training = _context.TrainingSessions
                .Include(t => t.Athlete)
                .FirstOrDefault(t => t.Id == id);

            if (Training == null)
                return NotFound();

            return Page();
        }
    }
}