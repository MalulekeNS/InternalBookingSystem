using InternalBookingSystem.Data;
using InternalBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InternalBookingSystem.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Booking Booking { get; set; }
        public List<Resource> Resources { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Booking = await _context.Bookings.FindAsync(id);
            if (Booking == null) return RedirectToPage("Index");

            Resources = await _context.Resources.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            Resources = await _context.Resources.ToListAsync();

            if (!ModelState.IsValid)
                return Page();

            if (Booking.EndTime <= Booking.StartTime)
            {
                ErrorMessage = "End time must be after start time.";
                return Page();
            }

            var conflict = await _context.Bookings
                .Where(b => b.ResourceId == Booking.ResourceId && b.Id != Booking.Id)
                .Where(b =>
                    Booking.StartTime < b.EndTime &&
                    Booking.EndTime > b.StartTime
                )
                .FirstOrDefaultAsync();

            if (conflict != null)
            {
                ErrorMessage = "This resource is already booked during this time.";
                return Page();
            }

            _context.Bookings.Update(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
