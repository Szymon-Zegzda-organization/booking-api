namespace Booking.Server.API.Models
{
    public class BookingRequest
    {
        public Guid CarId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
