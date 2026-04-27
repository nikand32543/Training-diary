using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Training_diary.Data;
using Training_diary.Model;

namespace Training_diary.Pages.Athletes
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Athlete Athlete { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Athlete = await _context.Athletes.FindAsync(id);

            if (Athlete == null)
                return NotFound();

            return Page();
        }
    }
}