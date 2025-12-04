using InternalBookingSystem.Data;
using InternalBookingSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InternalBookingSystem.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) => _context = context;

        public List<Booking> Bookings { get; set; }

        public async Task OnGet()
        {
            Bookings = await _context.Bookings
                .Include(b => b.Resource)
                .OrderByDescending(b => b.StartTime)
                .ToListAsync();
        }
    }
}
