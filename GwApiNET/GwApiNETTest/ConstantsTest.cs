using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GwApiNET;
using GwApiNET.CacheStrategy;
using GwApiNET.ResponseObjects;
using NUnit.Framework;

namespace GwApiNETTest
{

    public class ConstantsTest
    {
        [Test]
        public void SaveConstants()
        {
            Constants.SaveConstants();
            Dictionary<string, object> values = new Dictionary<string, object>
                {
                    {"CacheFile", Constants.CacheFile},
                    {"CurrentLanguage", Constants.CurrentLanguage},
                    {"ApiBaseUrl", Constants.ApiBaseUrl},
                    {"events", Constants.events},
                    {"event_names", Constants.event_names},
                    {"map_names", Constants.map_names},
                    {"world_names", Constants.world_names},
                    {"event_details", Constants.event_details},
                };
            Constants.CacheFile = "CacheFile";
            Constants.CurrentLanguage = Language.None;
            Constants.ApiBaseUrl = "CacheFile";
            Constants.events = "CacheFile";
            Constants.event_names = "CacheFile";
            Constants.map_names = "CacheFile";
            Constants.world_names = "CacheFile";
            Constants.event_details = "CacheFile";

            Assert.AreNotEqual(values["CacheFile"], Constants.CacheFile);
            Assert.AreNotEqual(values["CurrentLanguage"], Constants.CurrentLanguage);
            Assert.AreNotEqual(values["ApiBaseUrl"], Constants.ApiBaseUrl);
            Assert.AreNotEqual(values["events"], Constants.events);
            Assert.AreNotEqual(values["event_names"], Constants.event_names);
            Assert.AreNotEqual(values["map_names"], Constants.map_names);
            Assert.AreNotEqual(values["world_names"], Constants.world_names);
            Assert.AreNotEqual(values["event_details"], Constants.event_details);

            Constants.LoadConstants();

            Assert.AreEqual(values["CacheFile"], Constants.CacheFile);
            Assert.AreEqual(values["CurrentLanguage"], Constants.CurrentLanguage);
            Assert.AreEqual(values["ApiBaseUrl"], Constants.ApiBaseUrl);
            Assert.AreEqual(values["events"], Constants.events);
            Assert.AreEqual(values["event_names"], Constants.event_names);
            Assert.AreEqual(values["map_names"], Constants.map_names);
            Assert.AreEqual(values["world_names"], Constants.world_names);
            Assert.AreEqual(values["event_details"], Constants.event_details);
        }

        [Serializable]
        public class test
        {
            [XmlElement]
            public TimeSpan ts { get; set; }
        }
    }
}
