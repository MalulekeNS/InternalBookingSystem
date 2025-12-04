using InternalBookingSystem.Data;
using InternalBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalBookingSystem.Pages.Resources
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Resource Resource { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Resource = await _context.Resources.FindAsync(id);
            if (Resource == null) return RedirectToPage("Index");
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _context.Resources.Update(Resource);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
