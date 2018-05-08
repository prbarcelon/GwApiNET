using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.CacheStrategy;
using GwApiNET.ResponseObjects;
using NUnit.Framework;

namespace GwApiNETTest
{

    public class ResponseCacheTest
    {
        [TestCase(-1, -1, null, true, 1300, 1000)]
        [TestCase(-1, -1, null, false, 1300, 1000)]
        [TestCase(-1, -1, null, true, 900, 1000)]
        [TestCase(-1, -1, null, false, 900, 1000)]
        public void ResponseObjectExpirationTest(int world_id, int map_id, Guid? event_id,  bool ignoreCache, int expiresAfter, int nowOffset)
        {
            EntryCollection<EventEntry> expected = GwApi.GetEvents(world_id, map_id, event_id, true);
            expected.CacheStrategy = new AgeCacheStrategy(TimeSpan.FromMilliseconds(expiresAfter));
            expected.LastUpdated = expected.LastUpdated.Subtract(TimeSpan.FromMilliseconds(nowOffset));
            ResponseCache.Cache.Add(expected);
            Assert.IsFalse(expected.FromCache);

            var actual = GwApi.GetEvents(world_id, map_id, event_id, ignoreCache);
            if (ignoreCache || nowOffset >= expiresAfter)
            {
                // forced update, or has expired
                Assert.LessOrEqual(expected.LastUpdated, actual.LastUpdated);
                Assert.Greater(expected.Age, actual.Age);
                Assert.IsFalse(actual.Expired); // If it was just updated, it shouldn't expire so soon
                Assert.IsFalse(actual.FromCache); // must always be false if cache was ignored
            }
            else
            {
                // Not expired and therefore from cache
                Assert.AreEqual(expected.LastUpdated, actual.LastUpdated);
                Assert.AreEqual(expected.Age, actual.Age);
                Assert.IsFalse(actual.Expired);
                Assert.IsTrue(actual.FromCache);
            }
        }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ResponseCacheTest()
        {
        }
    }
}
