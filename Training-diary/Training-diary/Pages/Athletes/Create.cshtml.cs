using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Training_diary.Data;
using Training_diary.Model;

namespace Training_diary.Pages.Athletes
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Athlete Athlete { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Athletes.Add(Athlete);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}