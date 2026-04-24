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
        public TrainingSession Training { get; set; }

        public SelectList AthleteList { get; set; }

        public IActionResult OnGet(int id)
        {
            Training = _context.TrainingSessions
                .Where(c => c.Id == id)
                .Include(b => b.Athlete)
                .FirstOrDefault();

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
            var existingTraining = _context.TrainingSessions
           .Include(b => b.Athlete)
           .FirstOrDefault(b => b.Id == Training.Id);

            if (existingTraining == null)
                return NotFound();

            existingTraining.Date = Training.Date;
            existingTraining.ExerciseType = Training.ExerciseType;
            existingTraining.DurationMinutes = Training.DurationMinutes;
            existingTraining.CaloriesBurned = Training.CaloriesBurned;
            existingTraining.Notes = Training.Notes;

            if (Training.Athlete != null && Training.Athlete.Id > 0)
            {
                existingTraining.Athlete = _context.Athletes.Find(Training.Athlete.Id);
            }
            else
            {
                existingTraining.Athlete = null;
            }

            //_context.TrainingSessions.Update(Training);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }

        private void LoadSelectLists()
        {
            var athlete = _context.Athletes.ToList();

            AthleteList = new SelectList(athlete, "Id", "Name", Training.Athlete?.Id);
        }
    }
}