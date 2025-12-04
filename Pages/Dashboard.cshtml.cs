using InternalBookingSystem.Data;
using InternalBookingSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class DashboardModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DashboardModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public int TotalResources { get; set; }
    public int TotalBookings { get; set; }
    public int BookingsToday { get; set; }
    public int BookingsThisWeek { get; set; }

    public Booking NextBooking { get; set; }
    public List<Booking> UpcomingBookings { get; set; }

    public async Task OnGet()
    {
        TotalResources = await _context.Resources.CountAsync();
        TotalBookings = await _context.Bookings.CountAsync();

        var today = DateTime.Today;
        BookingsToday = await _context.Bookings
            .Where(b => b.StartTime.Date == today)
            .CountAsync();

        var weekStart = today.AddDays(-(int)today.DayOfWeek);
        BookingsThisWeek = await _context.Bookings
            .Where(b => b.StartTime >= weekStart)
            .CountAsync();

        NextBooking = await _context.Bookings
            .Include(r => r.Resource)
            .Where(b => b.StartTime > DateTime.Now)
            .OrderBy(b => b.StartTime)
            .FirstOrDefaultAsync();

        UpcomingBookings = await _context.Bookings
            .Include(r => r.Resource)
            .Where(b => b.StartTime > DateTime.Now)
            .OrderBy(b => b.StartTime)
            .Take(10)
            .ToListAsync();
    }
}
