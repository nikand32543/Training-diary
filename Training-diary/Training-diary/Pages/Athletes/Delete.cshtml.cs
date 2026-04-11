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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Athlete = await _context.Athletes.FindAsync(id);

            if (Athlete == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var athlete = await _context.Athletes.FindAsync(Athlete.Id);

            if (athlete != null)
            {
                _context.Athletes.Remove(athlete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}