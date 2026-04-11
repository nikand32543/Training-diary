using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Training_diary.Data;
using Training_diary.Model;

namespace Training_diary.Pages.Athletes
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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
            if (!ModelState.IsValid)
                return Page();

            _context.Athletes.Update(Athlete);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}