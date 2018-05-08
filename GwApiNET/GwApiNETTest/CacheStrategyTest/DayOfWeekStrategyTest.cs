using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET.CacheStrategy;
using GwApiNET.ResponseObjects;
using NUnit.Framework;

namespace GwApiNETTest.CacheStrategyTest
{

    public class DayOfWeekStrategyTest
    {
        [TestCase("08/7/2013 13:30:29", "08/14/2013 9:30:29", DayOfWeek.Wednesday, Result=true)]
        [TestCase("08/7/2013 13:30:29", "08/14/2013 15:30:29", DayOfWeek.Wednesday, Result=true)]
        [TestCase("08/1/2013 15:30:29", "08/6/2013 15:30:29", DayOfWeek.Wednesday, Result=false)]
        [TestCase("08/7/2013 5:30:29", "08/8/2013 15:30:29", DayOfWeek.Wednesday, Result=false)]
        [TestCase("08/6/2013 2:30:29", "08/8/2013 15:30:29", DayOfWeek.Wednesday, Result=true)]
        [TestCase("08/3/2013 20:30:29", "08/8/2013 15:30:29", DayOfWeek.Wednesday, Result=true)]
        [TestCase("08/19/2013 10:30:29", "08/19/2013 15:30:29", DayOfWeek.Wednesday, Result=false)]
        public bool ExpiredTest(string lastUpdateStr, string currentTimeStr, DayOfWeek dayOfWeek)
        {
            var lastUpdate = DateTime.Parse(lastUpdateStr);
            var currentTime = DateTime.Parse(currentTimeStr);
            var strat = new DayOfWeekStrategy(dayOfWeek);
            var response = new ResponseObject {LastUpdated = lastUpdate};
            return strat.Expired(response, currentTime - lastUpdate, currentTime);
        }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DayOfWeekStrategyTest()
        {
        }
    }
}
