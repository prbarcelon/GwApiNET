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

    public class CollectionCacheStrategyTest
    {
        public const int CurrentBuild = 21361;
        public static int LastUpdateBuild = CurrentBuild - 1;
        [TestCase("00:00:00:00.123", "00:00:00:00.000", Result = false)]
        [TestCase("00:00:00:00.123", "-00:00:00:00.125", Result = true)]
        public bool EntryCollectionAgeCacheStrategyExpiredTest(string maxAgeStr, string offsetStr)
        {
            var items = GwApi.GetEvents(-1, -1, null, true);
            var maxAge = TimeSpan.Parse(maxAgeStr);
            var offset = TimeSpan.Parse(offsetStr);
            items.LastUpdated = DateTime.Now.Add(offset);
            var strat1 = new AgeCacheStrategy(maxAge);
            var strat2 = new CollectionCacheStrategy<EntryCollection<EventEntry>, EventEntry>();
            return strat2.Expired(items, strat1);
        }
    }
}
