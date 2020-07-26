using DesignCrowdBusinessDayCounter.Holidays;
using System;
using System.Collections.Generic;

namespace DesignCrowdBusinessDayCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstDate = new DateTime(2019,7,1);
            var secondDate = new DateTime(2020,7,31);

            BusinessDayCounter bdc = new BusinessDayCounter();
            var a = bdc.WeekDaysBetweenTwoDates(firstDate, secondDate);
            Console.WriteLine(a);

            var list = new List<DateTime>()
            {
                new DateTime(2013, 12, 25),
                new DateTime(2013, 12, 26),
                new DateTime(2014, 1, 1)
            };
            var b = bdc.BusinessDaysBetweenTwoDates(firstDate, secondDate, list);
            Console.WriteLine(b);

            var holidays = new List<Holiday>
            {
                new SameDay(7, 5, true),
                new SameDay(7, 19, false),
                new CertainOccurence(6, DayOfWeek.Monday, 2)
            };

            var c = bdc.BusinessDaysBetweenTwoDates(firstDate, secondDate, holidays);
            Console.WriteLine(c);
            Console.ReadLine();


        }
    }
}
