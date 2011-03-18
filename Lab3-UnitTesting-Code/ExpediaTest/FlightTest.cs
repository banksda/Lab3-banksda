using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
    [TestFixture()]
    public class FlightTest
    {
        //TODO Task 6 items go here
        private readonly DateTime startDate = DateTime.Now;
        private readonly DateTime endDate = DateTime.Now + TimeSpan.FromDays(1);
        private readonly int miles = 5;
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(startDate, endDate, miles);
            Assert.IsNotNull(target);
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayFlight()
        {
            var target = new Flight(startDate, endDate, miles);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDayFlight()
        {
            var target = new Flight(startDate, endDate+TimeSpan.FromDays(1), miles);
            Assert.AreEqual(240, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDaysFlight()
        {
            var target = new Flight(startDate, endDate+TimeSpan.FromDays(9), miles);
            Assert.AreEqual(400, target.getBasePrice());
        }
        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDates()
        {
            new Flight(endDate, startDate, miles);
        }
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(startDate, endDate, -5);
        }
    }
}
