using InternalBookingSystem.Data;
using InternalBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalBookingSystem.Pages.Resources
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context) => _context = context;

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
            _context.Resources.Remove(Resource);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
