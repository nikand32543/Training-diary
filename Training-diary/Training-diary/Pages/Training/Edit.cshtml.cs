using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public SelectList AthleteList { get; set; } = null!;

        public IActionResult OnGet(int id)
        {
            Training = _context.TrainingSessions
                .Include(t => t.Athlete)
                .FirstOrDefault(t => t.Id == id);

            if (Training == null)
                return NotFound();

            LoadSelectLists();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoadSelectLists();
                return Page();
            }
            Training.Athlete = null;

            _context.TrainingSessions.Update(Training);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }

        private void LoadSelectLists()
        {
            var athletes = _context.Athletes.ToList();
            AthleteList = new SelectList(athletes, "Id", "Name", Training.AthleteId);
        }
    }
}