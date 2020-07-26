using DesignCrowdBusinessDayCounter.Holidays;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace DesignCrowdBusinessDayCounter
{
    public class SameDay : Holiday
    {
        private readonly int _month;
        private readonly int _day;
        private readonly bool _pushHolidayToMonday;

        public SameDay(int month, int day, bool pushHolidayToMonday)
        {
            _month = month;
            _day = day;
            _pushHolidayToMonday = pushHolidayToMonday;
        }

        public override IEnumerable<DateTime> GetDates(DateTime firstDate, DateTime secondDate)
        {
            var listOfDates = new List<DateTime>();
           
            var year = firstDate.Year;
            while (year <= secondDate.Year)
            {
                var dateCheck = DateCheck(new DateTime(year, _month, _day));
                if(dateCheck.DayOfWeek != DayOfWeek.Saturday && dateCheck.DayOfWeek != DayOfWeek.Sunday)
                    listOfDates.Add(dateCheck);
                
                year += 1;
            }

            return listOfDates;
        }

        private DateTime DateCheck(DateTime checkDate)
        {
            if (_pushHolidayToMonday)
            {
                if (checkDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    return checkDate.AddDays(2);
                }
                else if (checkDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    return checkDate.AddDays(1);
                }
            }            

            return checkDate;
        }

    }
}
