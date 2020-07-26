using DesignCrowdBusinessDayCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BusinessDayCounter.UnitTests
{
    public class CertainOccurenceTests
    {
        private readonly CertainOccurence _certain;

        public CertainOccurenceTests()
        {
            _certain = new CertainOccurence(6, DayOfWeek.Monday, 2);
        }

        [Fact]
        public void GetDates_Returns_ExpectedDate()
        {
            var result = _certain.GetDates(new DateTime(2020,1,1), new DateTime(2020,12,1));

            Assert.Equal(result.ToList()[0], new DateTime(2020, 6, 8));
        }
    }
}
