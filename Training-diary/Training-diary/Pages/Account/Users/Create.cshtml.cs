using Training_diary.Data;
using Training_diary.Model.AuthApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Training_diary.Pages.Account.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuthUser User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (User != null && !string.IsNullOrEmpty(User.Email))
            {
                User.Name = User.Email;
            }

            ModelState.Clear();

            if (!TryValidateModel(User, nameof(User)))
            {
                return Page();
            }

            _context.AuthUsers.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}