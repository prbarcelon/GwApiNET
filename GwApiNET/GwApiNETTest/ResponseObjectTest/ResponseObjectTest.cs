using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.ResponseObjects;
using NUnit.Framework;

namespace GwApiNETTest.ResponseObjectTest
{

    public class ResponseObjectTest
    {
        [SetUp]
        public void Setup()
        {
            ResponseCache.Cache.Save("TestCache");
            ResponseCache.Cache.Clear();
        }

        [TearDown]
        public void Cleanup()
        {
            ResponseCache.Cache.Load("TestCache");
        }
        [Test]
        public void ResponseObjectUpdateValuesTest1()
        {
            ResponseObject o = new ResponseObject();
            o.Url = "TestUrl";
            Assert.AreEqual(o.LastUpdateBuild , GwApi.Build);
            Assert.LessOrEqual(o.Age, TimeSpan.FromMilliseconds(100));
        }

        [Test]
        public void ResponseObjectUpdateValuesTest2()
        {
            ResponseObject toCache = new ResponseObject();
            toCache.Url = "TestUrl"; 
            toCache.LastUpdated = toCache.LastUpdated.AddDays(-1);
            toCache.LastUpdateBuild = GwApi.Build - 1;
            ResponseCache.Cache.Add(toCache);
            var notCached = new ResponseObject();
            var fromCache = ResponseCache.Cache.Get("TestUrl");

            Assert.IsTrue(fromCache.FromCache);
            Assert.AreEqual(toCache.LastUpdateBuild, fromCache.LastUpdateBuild);
            Assert.AreEqual(toCache.LastUpdated, fromCache.LastUpdated);
            Assert.AreNotEqual(fromCache.LastUpdateBuild, notCached.LastUpdateBuild);
            Assert.Less(fromCache.LastUpdated, notCached.LastUpdated);
        }
    }
}
