using Booking.Server.API.Models;

namespace Booking.Server.API.Validators
{
    public class BookingRequestValidator
    {
        public bool IsBookingRequestValid(BookingRequest bookingRequest)
        {
            if (bookingRequest.DateTo < bookingRequest.DateFrom)
            {
                return false;
            }

            return true;
        }
    }
}
