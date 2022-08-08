namespace Booking.Server.API.Validators
{
    public class MonthValidator
    {
        public bool IsMonthValid(int month)
        {
            if (month < 1)
            {
                return false;
            }

            if (month > 12)
            {
                return false;
            }

            return true;
        }
    }
}
