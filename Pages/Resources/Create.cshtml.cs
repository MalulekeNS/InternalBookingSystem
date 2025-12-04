using InternalBookingSystem.Data;
using InternalBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalBookingSystem.Pages.Resources
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Resource Resource { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _context.Resources.Add(Resource);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
