using Booking.Server.API.Validators;

namespace Booking.Server.Test.API.Validators
{
    public class YearValidatorTest
    {
        private readonly YearValidator YearValidator = new YearValidator();

        [Test]
        [TestCase(1)]
        [TestCase(1024)]
        [TestCase(2022)]
        public void ValidYearTest(int year)
        {
            var expected = true;
            var actual = YearValidator.IsYearValid(year);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void NotValidYearTest(int year)
        {
            var expected = false;
            var actual = YearValidator.IsYearValid(year);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
