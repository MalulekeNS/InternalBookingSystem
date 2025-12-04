using InternalBookingSystem.Data;
using InternalBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalBookingSystem.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Booking Booking { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Booking = await _context.Bookings.FindAsync(id);
            if (Booking == null) return RedirectToPage("Index");
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            _context.Bookings.Remove(Booking);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
