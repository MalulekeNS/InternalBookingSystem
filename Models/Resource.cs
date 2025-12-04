using System.ComponentModel.DataAnnotations;

namespace InternalBookingSystem.Models
{
    public class Resource
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }

        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }

        public bool IsAvailable { get; set; } = true;

        public List<Booking> Bookings { get; set; }
    }
}
