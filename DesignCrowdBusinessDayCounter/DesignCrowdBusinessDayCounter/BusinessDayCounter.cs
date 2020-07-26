using DesignCrowdBusinessDayCounter.Holidays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignCrowdBusinessDayCounter
{
    public class BusinessDayCounter
    {
        public int WeekDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate == DateTime.MinValue || secondDate == DateTime.MinValue)
                throw new NullReferenceException(); 

            firstDate = firstDate.AddDays(1);
            secondDate = secondDate.AddDays(-1);

            if (secondDate < firstDate)
                return 0;
            //First Date
            if ((int)firstDate.DayOfWeek == 6)
            {
                firstDate = firstDate.AddDays(2);
            }
            if ((int)firstDate.DayOfWeek == 0)
            {
                firstDate = firstDate.AddDays(1);
            }

            //Second Date
            if ((int)secondDate.DayOfWeek == 6)
            {
                secondDate = secondDate.AddDays(-1);
            }
            if ((int)secondDate.DayOfWeek == 0)
            {
                secondDate = secondDate.AddDays(-2);
            }

            TimeSpan dateDiff = secondDate - firstDate;

            int totalDaysBetween = dateDiff.Days + 1;
            int weekendDays = totalDaysBetween / 7 * 2;
            int additionalWeekend = 0;
            if(totalDaysBetween % 7 != 0)
                additionalWeekend= firstDate.DayOfWeek > secondDate.DayOfWeek ? 2 : 0;

            int totalWeekdays = totalDaysBetween - weekendDays - additionalWeekend;

            return totalWeekdays;
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            int workDays = WeekDaysBetweenTwoDates(firstDate, secondDate);

            if (workDays == 0)
                return 0;

            foreach (var day in publicHolidays)
            {
                if ((day.Date > firstDate.Date && day.Date < secondDate) && (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday))
                {
                    workDays--;
                }
            }

            return workDays;
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<Holiday> publicHolidayRules)
        {
            int workDays = WeekDaysBetweenTwoDates(firstDate, secondDate);

            if (workDays == 0)
                return 0;

            var newPubHolidays = new List<DateTime>();
            foreach (var day in publicHolidayRules)
            {
                var publicHolidays = day.GetDates(firstDate, secondDate);
                newPubHolidays.AddRange(publicHolidays);
            }
            //If multiple public holidays fall on the same day - Anzac day & Easter - distinct
            foreach (var pubDay in newPubHolidays.Distinct())
            {
                if (pubDay.Date > firstDate && pubDay.Date < secondDate)
                {
                    workDays--;
                }
            }

            return workDays;
        }

    }
}
