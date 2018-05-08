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

    public class BuildVersionCacheStrategyTest
    {
        [TestCase(2135, 2134, BuildVersionCacheStrategy.BuildVersionCondition.Changes, Result= true)]
        [TestCase(2135, 2136, BuildVersionCacheStrategy.BuildVersionCondition.Changes, Result = true)]
        [TestCase(2135, 2135, BuildVersionCacheStrategy.BuildVersionCondition.Changes, Result = false)]
        public bool ExpiredTest(int lastUpdateBuild, int currentBuild,
                                BuildVersionCacheStrategy.BuildVersionCondition condition)
        {
            var strat = new BuildVersionCacheStrategy(condition);
            var response = new ResponseObject {LastUpdateBuild = lastUpdateBuild};
            return strat.Expired(response, currentBuild);
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BuildVersionCacheStrategyTest()
        {
        }
    }
}
