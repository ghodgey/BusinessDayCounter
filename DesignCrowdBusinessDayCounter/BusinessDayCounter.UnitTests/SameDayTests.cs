using DesignCrowdBusinessDayCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BusinessDayCounter.UnitTests
{
    public class SameDayTests
    {

        [Fact]
        public void GetDates_Returns_ExpectedDateWithPushToMondayTrue()
        {
            var sameDay = new SameDay(7, 26, true);

            var result = sameDay.GetDates(new DateTime(2020, 1, 1), new DateTime(2021, 12, 1));

            Assert.Equal(result.ToList()[0], new DateTime(2020, 7, 27));
            Assert.Equal(result.ToList()[1], new DateTime(2021, 7, 26));

        }

        [Fact]
        public void GetDates_Returns_ExpectedDateWithPushToMondayFalse()
        {
            var sameDay = new SameDay(7, 26, false);

            var result = sameDay.GetDates(new DateTime(2020, 1, 1), new DateTime(2021, 12, 1));

            Assert.Equal(result.ToList()[0], new DateTime(2021, 7, 26));

        }
    }
}
