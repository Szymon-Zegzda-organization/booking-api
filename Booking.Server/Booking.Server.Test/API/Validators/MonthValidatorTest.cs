using Booking.Server.API.Validators;

namespace Booking.Server.Test.API.Validators
{
    public class MonthValidatorTest
    {
        private readonly MonthValidator MonthValidator = new MonthValidator();

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(12)]
        public void ValidMonthTest(int month)
        {
            var expected = true;
            var actual = MonthValidator.IsMonthValid(month);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(13)]
        public void NotValidMonthTest(int month)
        {
            var expected = false;
            var actual = MonthValidator.IsMonthValid(month);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
