using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Training_diary.Data;
using Training_diary.Model;

namespace Training_diary.Pages.Athletes
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Athlete Athlete { get; set; } = null!;

        public IActionResult OnGet(int id)
        {
            Athlete = _context.Athletes.Find(id);

            if (Athlete == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var trainings = _context.TrainingSessions.Where(t => t.AthleteId == Athlete.Id);
            _context.TrainingSessions.RemoveRange(trainings);

            var athlete = _context.Athletes.Find(Athlete.Id);
            if (athlete != null)
            {
                _context.Athletes.Remove(athlete);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}