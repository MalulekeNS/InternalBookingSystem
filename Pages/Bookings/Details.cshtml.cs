using InternalBookingSystem.Data;
using InternalBookingSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InternalBookingSystem.Pages.Bookings
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context) => _context = context;

        public Booking Booking { get; set; }

        public async Task OnGet(int id)
        {
            Booking = await _context.Bookings
                .Include(r => r.Resource)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
