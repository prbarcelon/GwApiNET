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

    public class AgeCacheStrategyTest
    {
        [TestCase("00:00:00:00.123", "08/7/2013 13:30:29", "08/7/2013 13:30:29.122", Result = false)]
        [TestCase("00:00:00:00.123", "08/7/2013 13:30:29", "08/7/2013 13:30:29.500", Result = true)]
        [TestCase("00:00:00:00.123", "08/7/2013 13:30:29", "08/7/2013 13:30:29", Result = false)]
        [TestCase("10:05:00:01", "08/7/2013 13:30:29", "08/14/2013 9:30:29", Result = false)]
        [TestCase("1:00:01", "08/7/2013 13:30:29", "08/14/2013 9:30:29", Result = true)]
        public bool ExpiredTest(string maxAgeStr, string lastUpdateStr, string currentTimeStr)
        {
            var lastUpdate = DateTime.Parse(lastUpdateStr);
            var currentTime = DateTime.Parse(currentTimeStr);
            var maxAge = TimeSpan.Parse(maxAgeStr);
            var strat = new AgeCacheStrategy(maxAge);
            return strat.Expired(currentTime - lastUpdate);
        }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AgeCacheStrategyTest()
        {
        }
    }
}
