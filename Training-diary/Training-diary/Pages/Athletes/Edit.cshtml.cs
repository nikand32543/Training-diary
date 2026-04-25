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

        public IActionResult OnGet(int id)
        {
            Athlete = _context.Athletes.FirstOrDefault(a => a.Id == id);

            if (Athlete == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Athletes.Update(Athlete);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}