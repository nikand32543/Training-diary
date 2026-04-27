using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_diary.Data;
using Training_diary.Model;

namespace Training_diary.Pages.Training
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public IActionResult OnPost()
        {
            var training = _context.TrainingSessions.Find(Training.Id);

            if (training != null)
            {
                _context.TrainingSessions.Remove(training);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}