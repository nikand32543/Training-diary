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
            LoadAthletes();
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            Training.Name = Training.ExerciseType ?? "Без названия";

            ModelState.ClearValidationState(nameof(Training));
            if (!TryValidateModel(Training, nameof(Training)))
            {
                LoadAthletes();
                return Page();
            }

            _context.TrainingSessions.Add(Training);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        private void LoadAthletes()
        {
            var athletes = _context.Athletes.ToList();
            AthletesList = new SelectList(athletes, "Id", "Name");
        }
    }
}