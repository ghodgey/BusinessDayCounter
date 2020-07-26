using System;
using System.Collections.Generic;
using System.Text;

namespace DesignCrowdBusinessDayCounter.Extensions
{
    public static class Extensions
    {

        public static DateTime NthOf(this DateTime CurDate, int Occurrence, DayOfWeek Day)
        {
            var firstDay = new DateTime(CurDate.Year, CurDate.Month, 1);

            var fOc = firstDay.DayOfWeek == Day ? firstDay : firstDay.AddDays(Day - firstDay.DayOfWeek);
            if (fOc.Month < CurDate.Month)
            { 
                Occurrence += 1; 
            }
            return fOc.AddDays(7 * (Occurrence - 1));
        }
    }
}
