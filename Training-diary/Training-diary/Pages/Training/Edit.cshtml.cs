using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_diary.Data;
using Training_diary.Model;

namespace Training_diary.Pages.Training
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrainingSession Training { get; set; } = null!;

        public IActionResult OnGet(int id)
        {
            Training = _context.TrainingSessions
                .Where(t => t.Id == id)
                .Include(t => t.Athlete)
                .FirstOrDefault();

            if (Training == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.TrainingSessions.Update(Training);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}