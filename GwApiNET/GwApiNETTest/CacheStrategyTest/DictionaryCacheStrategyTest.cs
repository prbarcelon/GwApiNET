using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.CacheStrategy;
using GwApiNET.ResponseObjects;
using NUnit.Framework;

namespace GwApiNETTest.CacheStrategyTest
{

    public class DictionaryCacheStrategyTest
    {
        public const int CurrentBuild = 21361;
        public static int LastUpdateBuild = CurrentBuild - 1;
        [TestCase("00:00:00:00.123", "00:00:00:00.000", Result = false)]
        [TestCase("00:00:00:00.123", "-00:00:00:00.125", Result = true)]
        public bool DictionaryAgeCacheStrategyExpiredTest(string maxAgeStr, string offsetStr)
        {
            var items = GwApi.GetEventNames(true);
            var maxAge = TimeSpan.Parse(maxAgeStr);
            var offset = TimeSpan.Parse(offsetStr);
            items.LastUpdated = DateTime.Now.Add(offset);
            var strat1 = new AgeCacheStrategy(maxAge);
            var strat2 = new DictionaryCacheStrategy<EntryDictionary<Guid,EventNameEntry>, Guid, EventNameEntry>();
            return strat2.Expired(items, strat1);
        }

        [TestCase(-1, Result = true)]
        [TestCase(1, Result = true)]
        [TestCase(0, Result = false)]
        public bool DictionaryBuildCacheStrategyExpiredTest(int buildOffset)
        {
            var strat = new DictionaryCacheStrategy<EntryDictionary<int, ResponseObject>, int, ResponseObject>();
            var buildStrat = new BuildVersionCacheStrategy();
            ResponseObject ro = new ResponseObject();
            ro.CacheStrategy = buildStrat;
            EntryDictionary<int, ResponseObject> responses = new EntryDictionary<int, ResponseObject>();
            responses.Add(1, ro);
            responses.LastUpdateBuild = GwApi.Build - buildOffset;
            return strat.Expired(responses);
        }
    }
}
