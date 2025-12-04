using InternalBookingSystem.Data;
using InternalBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InternalBookingSystem.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Booking Booking { get; set; }

        public List<Resource> Resources { get; set; }
        public string ErrorMessage { get; set; }

        public async Task OnGet()
        {
            Resources = await _context.Resources.OrderBy(r => r.Name).ToListAsync();
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

            // **CONFLICT CHECK**
            var conflictingBooking = await _context.Bookings
                .Where(b => b.ResourceId == Booking.ResourceId)
                .Where(b =>
                    Booking.StartTime < b.EndTime &&
                    Booking.EndTime > b.StartTime
                )
                .FirstOrDefaultAsync();

            if (conflictingBooking != null)
            {
                ErrorMessage = "This resource is already booked during the selected time.";
                return Page();
            }

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
