namespace Booking.Server.API.Models
{
    public class BookingResult
    {
        public DateTime Date { get; set; }
        public List<Guid> CarIds { get; set; }
    }
}
