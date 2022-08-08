using System.ComponentModel.DataAnnotations;
 
namespace Booking.Server.DB.Models
{
    public class BookingInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid CarId { get; set; }

        [Required]
        public Guid OrderId { get; set; }
    }
}
