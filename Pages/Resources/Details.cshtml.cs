using InternalBookingSystem.Data;
using InternalBookingSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InternalBookingSystem.Pages.Resources
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context) => _context = context;

        public Resource Resource { get; set; }
        public List<Booking> Bookings { get; set; }

        public async Task OnGet(int id)
        {
            Resource = await _context.Resources.FindAsync(id);

            Bookings = await _context.Bookings
                .Where(b => b.ResourceId == id && b.EndTime > DateTime.Now)
                .OrderBy(b => b.StartTime)
                .ToListAsync();
        }
    }
}
