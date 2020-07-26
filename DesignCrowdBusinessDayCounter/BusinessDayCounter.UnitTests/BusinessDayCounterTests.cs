using System;
using Xunit;
using DesignCrowdBusinessDayCounter;
using System.Collections.Generic;
using DesignCrowdBusinessDayCounter.Holidays;

namespace BusinessDayCounter.UnitTests
{
    public class BusinessDayCounterTests
    {
        private readonly DesignCrowdBusinessDayCounter.BusinessDayCounter _businessDayCounter;
        
        public BusinessDayCounterTests()
        {
            _businessDayCounter = new DesignCrowdBusinessDayCounter.BusinessDayCounter();
        }

        [Fact]
        public void WeekDaysBetweenTwoDates_Returns_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => _businessDayCounter.WeekDaysBetweenTwoDates(new DateTime(), new DateTime()));
        }

        [Theory]
        [MemberData(nameof(WeekDayData))]
        public void WeekDaysBetweenTwoDates_Returns_ExpectedNumDays(DateTime firstDate, DateTime endDate, int expected)
        {
            var result = _businessDayCounter.WeekDaysBetweenTwoDates(firstDate, endDate);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(WeekDayDataWithPublicHolidays))]
        public void BusinessDaysBetweenTwoDates_Returns_ExpectedNumDaysWithListDateTime(DateTime firstDate, DateTime endDate, IList<DateTime> publicHolidays, int expected)
        {
            var result = _businessDayCounter.BusinessDaysBetweenTwoDates(firstDate, endDate, publicHolidays);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(WeekDayDataWithHolidays))]
        public void BusinessDaysBetweenTwoDates_Returns_ExpectedNumDaysWithListHolidays(DateTime firstDate, DateTime endDate, IList<Holiday> publicHolidays, int expected)
        {
            var result = _businessDayCounter.BusinessDaysBetweenTwoDates(firstDate, endDate, publicHolidays);

            Assert.Equal(expected, result);
        }



        public static IEnumerable<object[]> WeekDayData =>
        new List<object[]>
        {
            new object[] { new DateTime(2013, 10, 7), new DateTime(2013, 10, 9), 1 },
            new object[] { new DateTime(2013, 10, 5), new DateTime(2013, 10, 14), 5 },
            new object[] { new DateTime(2013, 10, 7), new DateTime(2014, 1, 1), 61 },
            new object[] { new DateTime(2013, 10, 7), new DateTime(2013, 10, 5), 0 }
        };

        public static IEnumerable<object[]> WeekDayDataWithPublicHolidays =>
            new List<object[]>
            {
                new object[] { new DateTime(2013, 10, 7), new DateTime(2013, 10, 9), PublicHolidays,  1 },
                new object[] { new DateTime(2013, 12, 24), new DateTime(2013, 12, 27), PublicHolidays, 0 },
                new object[] { new DateTime(2013, 10, 7), new DateTime(2014, 1, 1), PublicHolidays, 59 }
            };

        public static List<DateTime> PublicHolidays =>
            new List<DateTime>
            {
                new DateTime(2013, 12, 25),
                new DateTime(2013, 12, 26),
                new DateTime(2014, 1, 1)
            };

        public static IEnumerable<object[]> WeekDayDataWithHolidays =>
           new List<object[]>
           {
                new object[] { new DateTime(2020, 6, 1), new DateTime(2020, 6, 30), Holidays,  18 }
           };

        public static List<Holiday> Holidays =>
            new List<Holiday>
            {
                new SameDay(6, 6, true),
                new SameDay(6, 7, false),
                new SameDay(6, 14, true),
                new CertainOccurence(6, DayOfWeek.Monday, 2)
            };


    }
}
