using System;
using System.Collections.Generic;
using System.Text;

namespace DesignCrowdBusinessDayCounter.Holidays
{
    public abstract class Holiday
    {
        public abstract IEnumerable<DateTime> GetDates(DateTime firstDate, DateTime secondDate);
    }
}
