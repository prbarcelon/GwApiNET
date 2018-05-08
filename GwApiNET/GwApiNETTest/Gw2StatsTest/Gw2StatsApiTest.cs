using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.Gw2Stats;
using GwApiNET.Gw2Stats.ResponseObjects;
using NUnit.Framework;

namespace GwApiNETTest.Gw2StatsTest
{
/*
    [TestFixture]
    public class Gw2StatsApiTestFixture
    {
        [TestFixtureSetUp]
        public void Setup()
        {
        }
    }
*/

    public class Gw2StatsApiTest
    {
        private INetworkHandler Network = new MockNetworkHandler(@"..\..\..\TestData\Gw2Stats");

        [SetUp]
        public void Setup()
        {
            Gw2StatsApi.Network = Network;
        }


        [TestCase(false)]
        public void GetGw2StatsStatusTest(bool ignoreCache)
        {
            var actual = Gw2StatsApi.GetGw2StatsStatus(ignoreCache);
            var expected = TestData.StatusEntriesExpected;
            foreach (var pair in expected)
            {
                var actualEntry = actual[pair.Key];
                var expectedEntry = pair.Value;
                TestHelper.CompareObjects(expectedEntry, actualEntry);
            }
        }

        [TestCase(true)]
        public void GetGw2StatsStatusCodesTest(bool ignoreCache)
        {
            var actual = Gw2StatsApi.GetGw2StatsStatusCodes(ignoreCache);
            var expected = TestData.StatusCodesExpected;
            foreach (var expectedPair in expected)
            {
                Assert.AreEqual(expectedPair.Value, actual[expectedPair.Key]);
            }
        }

        [TestCase(true, true, true)]
        public void GetGw2StatsMatchEntryTest(bool objectives, bool ratings, bool ignoreCache)
        {
            var actual = Gw2StatsApi.GetGw2StatsMatchEntry(objectives, ratings, ignoreCache);
            var expected = TestData.MatchEntryExpected;
            Assert.AreEqual(expected.RetriveTime, actual.RetriveTime);
            foreach (var pair in expected.Region)
            {
                var actualRegions = actual.Region[pair.Key];
                var expectedRegions = pair.Value;
                Assert.AreEqual(expectedRegions.Count, actualRegions.Count);
                for (int i = 0; i < expectedRegions.Count; i++)
                {
                    var actualRegion = actualRegions[i];
                    var expectedRegion = expectedRegions[i];
                    //Assert.AreEqual(expectedRegion.StartTime, actualRegion.StartTime);
                    Assert.AreEqual(expectedRegion.EndDate, actualRegion.EndDate);
                    Assert.AreEqual(expectedRegion.LastUpdate, actualRegion.LastUpdate);
                    Assert.AreEqual(expectedRegion.MatchId, actualRegion.MatchId);
                    Assert.AreEqual(expectedRegion.UniqueId, actualRegion.UniqueId);

                    foreach (var pair2 in expectedRegion.Worlds)
                    {
                        var actualWorld = actualRegion.Worlds[pair2.Key];
                        var expectedWorld = pair2.Value;
                        Assert.AreEqual(expectedWorld.Id, actualWorld.Id);
                        Assert.AreEqual(expectedWorld.Name, actualWorld.Name);
                        Assert.AreEqual(expectedWorld.Color, actualWorld.Color);
                        Assert.AreEqual(expectedWorld.Score, actualWorld.Score);
                        Assert.AreEqual(expectedWorld.PPT, actualWorld.PPT);

                        var actualObjectives = actualWorld.Objectives;
                        var expectedObjectives = expectedWorld.Objectives;
                        Assert.AreEqual(expectedObjectives.Camps, actualObjectives.Camps);
                        Assert.AreEqual(expectedObjectives.Towers, actualObjectives.Towers);
                        Assert.AreEqual(expectedObjectives.Keeps, actualObjectives.Keeps);
                        Assert.AreEqual(expectedObjectives.Castles, actualObjectives.Castles);
                    }

                }
            }

        }

        [TestCase(Gw2StatsObjectives.ObjectiveType.All, "", true)]
        [TestCase(Gw2StatsObjectives.ObjectiveType.Match, "1-1", true)]
        [TestCase(Gw2StatsObjectives.ObjectiveType.World, "1019", true)]
        public void GetGw2StatsObjectivesTest(Gw2StatsObjectives.ObjectiveType type, string id, bool ignoreCache = true)
        {
            var actual = Gw2StatsApi.GetGw2StatsObjectives(type, id, ignoreCache);
            var expected = TestData.ObjectivesExpected[type];
            Assert.AreEqual(expected.RetriveTime, actual.RetriveTime);
            Assert.AreEqual(expected.Type, actual.Type);
            foreach(var expectedMatch in expected.Matches.Values)
            {
                var actualMatch = actual.Matches[expectedMatch.MatchId];
                Assert.AreEqual(expectedMatch.MatchId, actualMatch.MatchId);
                foreach (var expectedMap in expectedMatch.Maps.Values)
                {
                    var actualMap = actualMatch.Maps[expectedMap.MapId];
                    Assert.AreEqual(expectedMap.Name, actualMap.Name);
                    Assert.AreEqual(expectedMap.MapId, actualMap.MapId);
                    Assert.AreEqual(expectedMap.MapOwnerId, actualMap.MapOwnerId);
                    Assert.AreEqual(expectedMap.MapOwnerName, actualMap.MapOwnerName);
                    foreach (var expectedObjective in expectedMap.Objectives.Values)
                    {
                        var actualObjective = actualMap.Objectives[expectedObjective.Id];
                        Assert.AreEqual(expectedObjective.Id, actualObjective.Id);
                        Assert.AreEqual(expectedObjective.Name, actualObjective.Name);
                        Assert.AreEqual(expectedObjective.Cardinal, actualObjective.Cardinal);
                        Assert.AreEqual(expectedObjective.Points, actualObjective.Points);
                        Assert.AreEqual(expectedObjective.CaptureTime, actualObjective.CaptureTime);
                        Assert.AreEqual(expectedObjective.TimeHeld, actualObjective.TimeHeld);
                        Assert.AreEqual(expectedObjective.CurrentOwner.WorldId, actualObjective.CurrentOwner.WorldId);
                        Assert.AreEqual(expectedObjective.CurrentOwner.Name, actualObjective.CurrentOwner.Name);
                        Assert.AreEqual(expectedObjective.CurrentOwner.Color, actualObjective.CurrentOwner.Color);
                        Assert.AreEqual(expectedObjective.PreviousOwner.WorldId, actualObjective.PreviousOwner.WorldId);
                        Assert.AreEqual(expectedObjective.PreviousOwner.Name, actualObjective.PreviousOwner.Name);
                        Assert.AreEqual(expectedObjective.PreviousOwner.Color, actualObjective.PreviousOwner.Color);
                        Assert.AreEqual(expectedObjective.CurrentGuild.Id, actualObjective.CurrentGuild.Id);
                        Assert.AreEqual(expectedObjective.CurrentGuild.ImageUrl, actualObjective.CurrentGuild.ImageUrl);
                        Assert.AreEqual(expectedObjective.CurrentGuild.Name, actualObjective.CurrentGuild.Name);
                    }
                }
            }
        }

        [TestCase(true)]
        public void Gw2StatsRatingsObjectTest(bool ignoreCache)
        {
            var actual = Gw2StatsApi.Gw2StatsRatingsObject(ignoreCache);
            var expected = TestData.RatingsObjectExpected;
            Assert.AreEqual(expected.RetrieveTime, actual.RetrieveTime);
            Assert.AreEqual(expected.Results, actual.Results);
            foreach (var expectedpair in expected.Ratings)
            {

                var expectedRegion = expectedpair.Value;
                var actualRegion = actual.Ratings[expectedpair.Key];
                foreach (var expectedpair2 in expectedRegion)
                {
                    var expectedRatingsEntry = expectedpair2.Value;
                    var actualRatingsEntry = actualRegion[expectedpair2.Key];
                    Assert.AreEqual(expectedRatingsEntry.WorldId, actualRatingsEntry.WorldId);
                    Assert.AreEqual(expectedRatingsEntry.WorldName, actualRatingsEntry.WorldName);
                    var expectedData = expectedRatingsEntry.Data;
                    var actualData = actualRatingsEntry.Data;
                    Assert.AreEqual(expectedData.StartRank, actualData.StartRank);
                    Assert.AreEqual(expectedData.CurrentRank, actualData.CurrentRank);
                    Assert.AreEqual(expectedData.StartRating, actualData.StartRating);
                    Assert.AreEqual(expectedData.StartDeviation, actualData.StartDeviation);
                    Assert.AreEqual(expectedData.CurrentDeviation, actualData.CurrentDeviation);
                    Assert.AreEqual(expectedData.Volatility, actualData.Volatility);
                    Assert.AreEqual(expectedData.CurrentRating, actualData.CurrentRating);
                    Assert.AreEqual(expectedData.Evolution, actualData.Evolution);
                }
            }
        }


    }
}
