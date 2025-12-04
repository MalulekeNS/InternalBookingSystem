using InternalBookingSystem.Data;
using InternalBookingSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InternalBookingSystem.Pages.Resources
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) => _context = context;

        public List<Resource> ResourceList { get; set; }

        public async Task OnGet()
        {
            ResourceList = await _context.Resources.ToListAsync();
        }
    }
}
