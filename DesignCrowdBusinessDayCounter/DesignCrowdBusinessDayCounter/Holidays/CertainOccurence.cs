using DesignCrowdBusinessDayCounter.Extensions;
using DesignCrowdBusinessDayCounter.Holidays;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignCrowdBusinessDayCounter
{
    public class CertainOccurence : Holiday
    {
        private readonly int _month;
        private readonly DayOfWeek _dayOfWeek;
        private readonly int _weekOfMonth;
        public CertainOccurence(int month, DayOfWeek dayOfWeek, int weekOfMonth)
        {
            _month = month;
            _dayOfWeek = dayOfWeek;
            _weekOfMonth = weekOfMonth;
        }

        public override IEnumerable<DateTime> GetDates(DateTime firstDate, DateTime secondDate)
        {
            var listOfDates = new List<DateTime>();
            var year = firstDate.Year;

            while (year <= secondDate.Year)
            {
                var dateToAdd = new DateTime(year, _month, 1).NthOf(_weekOfMonth, _dayOfWeek);
                listOfDates.Add(dateToAdd);
                year += 1;
            }

            return listOfDates;
        }
    }
}
