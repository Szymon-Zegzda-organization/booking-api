namespace Booking.Server.API.Validators
{
    public class YearValidator
    {
        public bool IsYearValid(int year)
        {
            if (year < 1)
            {
                return false;
            }

            return true;
        }
    }
}
