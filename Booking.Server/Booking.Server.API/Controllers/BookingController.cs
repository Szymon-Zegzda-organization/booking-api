using Booking.Server.API.Models;
using Booking.Server.API.Validators;
using Booking.Server.DB;
using Booking.Server.DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingRequestValidator BookingRequestValidator = new BookingRequestValidator();
        private readonly YearValidator YearValidator = new YearValidator();
        private readonly MonthValidator MonthValidator = new MonthValidator();

        private readonly DatabaseContext DatabaseContext;

        public BookingController(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        [HttpPost]
        public async Task SubmitBooking(BookingRequest bookingRequest)
        {
            if (!BookingRequestValidator.IsBookingRequestValid(bookingRequest))
            {
                throw new ArgumentException(nameof(bookingRequest));
            }

            var bookings = new List<BookingInfo>();
            
            var dateFrom = new DateTime(bookingRequest.DateFrom.Year, bookingRequest.DateFrom.Month, bookingRequest.DateFrom.Day);
            var dateTo = new DateTime(bookingRequest.DateTo.Year, bookingRequest.DateTo.Month, bookingRequest.DateTo.Day);
            var orderId = Guid.NewGuid();

            while (dateFrom <= dateTo)
            {
                var booking = new BookingInfo()
                {
                    Date = dateFrom,
                    CarId = bookingRequest.CarId,
                    OrderId = orderId
                };

                bookings.Add(booking);

                dateFrom = dateFrom.AddDays(1);
            }

            await DatabaseContext.BookingInfo.AddRangeAsync(bookings);
            await DatabaseContext.SaveChangesAsync();
        }

        [HttpGet("{year:int}/{month:int}")]
        public async Task<List<BookingResult>> GetBookings([FromRoute]int year, [FromRoute]int month)
        {
            if (!YearValidator.IsYearValid(year))
            {
                throw new ArgumentException(nameof(year));
            }

            if (!MonthValidator.IsMonthValid(month))
            {
                throw new ArgumentException(nameof(month));
            }

            var results = await DatabaseContext.BookingInfo
                .Where(x => x.Date.Month == month && x.Date.Year == year)
                .ToListAsync();

            return results
                .GroupBy(k => k.Date, v => v, (key, val) => new { key = key, values = val })
                .Select(x => new BookingResult()
                {
                    Date = x.key,
                    CarIds = x.values.Select(i => i.CarId).ToList()
                })
                .ToList();
        }
    }
}
