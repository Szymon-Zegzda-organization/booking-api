using Booking.Server.API.Models;
using Booking.Server.API.Validators;

namespace Booking.Server.Test.API.Validators
{
    public class BookingRequestValidatorTest
    {
        private readonly BookingRequestValidator BookingRequestValidator = new BookingRequestValidator();

        private static readonly List<BookingRequest> ValidBookingRequests = new List<BookingRequest>()
        {
            new BookingRequest() { DateFrom = DateTime.MinValue, DateTo = DateTime.MaxValue },
            new BookingRequest() { DateFrom = DateTime.MinValue, DateTo = DateTime.MinValue },
            new BookingRequest() { DateFrom = DateTime.MaxValue, DateTo = DateTime.MaxValue }
        };

        [Test]
        [TestCaseSource(nameof(ValidBookingRequests))]
        public void ValidBookingRequestTest(BookingRequest bookingRequest)
        {
            var expected = true;
            var actual = BookingRequestValidator.IsBookingRequestValid(bookingRequest);

            Assert.That(actual, Is.EqualTo(expected));
        }


        private static readonly List<BookingRequest> NotValidBookingRequests = new List<BookingRequest>()
        {
            new BookingRequest() { DateFrom = DateTime.MaxValue, DateTo = DateTime.MinValue }
        };

        [Test]
        [TestCaseSource(nameof(NotValidBookingRequests))]
        public void NotValidBookingRequestTest(BookingRequest bookingRequest)
        {
            var expected = false;
            var actual = BookingRequestValidator.IsBookingRequestValid(bookingRequest);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
