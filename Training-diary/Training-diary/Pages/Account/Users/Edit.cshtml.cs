using Training_diary.Data;
using Training_diary.Model.AuthApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Training_diary.Pages.Account.Users
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuthUser User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _context.AuthUsers.FindAsync(id);

            if (User == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userInDb = await _context.AuthUsers.FindAsync(User.Id);

            if (userInDb == null)
            {
                return NotFound();
            }

            userInDb.Email = User.Email;
            userInDb.Password = User.Password;
            userInDb.Role = User.Role;
            userInDb.Name = User.Email; 

            ModelState.Clear();

            if (!TryValidateModel(userInDb, nameof(User)))
            {
                return Page();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.AuthUsers.Any(e => e.Id == User.Id))
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
    }
}