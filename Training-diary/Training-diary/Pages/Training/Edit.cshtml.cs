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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var training = await _context.TrainingSessions
                .Include(t => t.Athlete)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (training == null)
            {
                return NotFound();
            }

            Training = training;
            LoadSelectLists();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Training.Name = Training.ExerciseType ?? "Тренировка";

            ModelState.ClearValidationState(nameof(Training));

            if (!TryValidateModel(Training, nameof(Training)))
            {
                LoadSelectLists();
                return Page();
            }

            Training.Athlete = null!;

            _context.Attach(Training).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingSessionExists(Training.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }

        private void LoadSelectLists()
        {
            var athletes = _context.Athletes.ToList();
            AthleteList = new SelectList(athletes, "Id", "Name");
        }

        private bool TrainingSessionExists(int id)
        {
            return _context.TrainingSessions.Any(e => e.Id == id);
        }
    }
}