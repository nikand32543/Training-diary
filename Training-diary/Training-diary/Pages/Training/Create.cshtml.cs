using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Training_diary.Data;
using Training_diary.Model;

namespace Training_diary.Pages.Training
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrainingSession Training { get; set; } = new();

        public SelectList AthletesList { get; set; }

        public void OnGet()
        {
            var athletes = _context.Athletes.ToList();
            AthletesList = new SelectList(athletes, "Id", "Name");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var athletes = _context.Athletes.ToList();
                AthletesList = new SelectList(athletes, "Id", "Name");
                return Page();
            }

            _context.TrainingSessions.Add(Training);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}