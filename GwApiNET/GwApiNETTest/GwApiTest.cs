using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.Logging;
using GwApiNET.ResponseObjects;
using GwApiNET.ResponseObjects.Parsers;
using NUnit.Framework;
using System.Net;

namespace GwApiNETTest
{
    #region Regions
    #region Dynamic Events API - BETA
    #endregion Dynamic Events API - BETA

    #region Item and Recipe Database API - BETA

    #endregion Item and Recipe Database API - BETA

    #region Guild API - BETA
    #endregion Guild API - BETA

    #region WvW API - BETA
    #endregion WvW API - BETA

    #region Map API - BETA

    #endregion Map API - BETA

    #region Miscellaneous APIs - BETA
    #endregion Miscellaneous APIs - BETA
    #endregion Regions

    [SetUpFixture]
    public class GwApiTestFixture
    {
        [SetUp]
        public void Setup()
        {
            GwApi.Network = new MockNetworkHandler();
            GwApi.RenderServiceNetwork = new MockRenderServiceNetworkHandler(@"..\..\..\TestData\file");
            //ResponseCache.Cache.Clear();
        }

        [TearDown]
        public void Cleanup()
        {
            ResponseCache.Cache.Save();
        }
    }

    // Sync api testing
    public partial class GwApiTest
    {
        [SetUp]
        public void Setup()
        {
        }

        #region Dynamic Events API - BETA
        [TestCase(true)]
        public void GetEventsTest(bool ignoreCache)
        {
            var actuals = GwApi.GetEvents(-1, -1, null, ignoreCache);
            var expectedCol = TestData.EventEntriesExpected;
            VerifyEvents(expectedCol, actuals);
        }
        [TestCase(true)]
        public void GetEventNamesTest(bool ignoreCache)
        {
            var actual = GwApi.GetEventNames(ignoreCache);
            var expected = TestData.EventNameEntriesExpected;
            foreach (var pair in expected)
            {
                var actualEntry = actual[pair.Key];
                var expectedEntry = pair.Value;
                Assert.NotNull(actualEntry);
                Assert.AreEqual(expectedEntry.Name, actualEntry.Name);
            }
        }

        [TestCase(true)]
        public void GetWorldNamesTest(bool ignoreCache)
        {
            var actual = GwApi.GetWorldNames(ignoreCache);
            var expected = TestData.WorldNameEntriesExpected;
            foreach (var pair in expected)
            {
                var actualEntry = actual[pair.Key];
                var expectedEntry = pair.Value;
                Assert.NotNull(actualEntry);
                Assert.AreEqual(expectedEntry.Name, actualEntry.Name);
            }
        }

        [TestCase(true)]
        public void GetMapNamesTest(bool ignoreCache)
        {
            var actual = GwApi.GetMapNames(ignoreCache);
            var expected = TestData.MapNameEntriesExpected;
            foreach (var pair in expected)
            {
                var actualEntry = actual[pair.Key];
                var expectedEntry = pair.Value;
                Assert.NotNull(actualEntry);
                Assert.AreEqual(expectedEntry.Name, actualEntry.Name);
            }
        }
        [TestCase(null, true)]
        public void GetEventDetailsTest(string event_id, bool ignoreCache)
        {
            var actual = GwApi.GetEventDetails(event_id, ignoreCache);
            var expected = TestData.EventDetailsExpected;
            foreach (var pair in expected)
            {
                var entry = pair.Value;
                Assert.IsTrue(actual.ContainsKey(pair.Key));
                var actualEntry = actual[pair.Key];
                Assert.AreEqual(entry.Name, actualEntry.Name);
                Assert.AreEqual(entry.Level, actualEntry.Level);
                Assert.AreEqual(entry.MapId, actualEntry.MapId);
                Assert.AreEqual(entry.Location.Height, actualEntry.Location.Height);
                Assert.AreEqual(entry.Location.Radius, actualEntry.Location.Radius);
                Assert.AreEqual(entry.Location.Rotation, actualEntry.Location.Rotation);
                Assert.AreEqual(entry.Location.Type, actualEntry.Location.Type);
                if ((entry.Location.Center == null && actualEntry.Location.Center == null) == false)
                    CollectionAssert.AreEquivalent(entry.Location.Center, actualEntry.Location.Center);
                if ((entry.Location.Points == null && actualEntry.Location.Points == null) == false)
                    CollectionAssert.AreEquivalent(entry.Location.Points, actualEntry.Location.Points);
                if ((entry.Location.ZRange == null && actualEntry.Location.ZRange == null) == false)
                    CollectionAssert.AreEquivalent(entry.Location.ZRange, actualEntry.Location.ZRange);
            }
        }
        #endregion Dynamic Events API - BETA

        #region Item and Recipe Database API - BETA
        [TestCase(12862, true)]
        public void GetItemDetailsTest(int item_id, bool ignoreCache)
        {
            var actual = GwApi.GetItemDetails(item_id, ignoreCache);
            var expected = TestData.ItemDetailsExpected.Single(i => i.ItemId == item_id);
            VerifyItemDetails(expected, actual);
        }

        [TestCase(1275, true)]
        public void GetRecipeDetailsTest(int recipe_id, bool ignoreCache)
        {
            var actual = GwApi.GetRecipeDetails(recipe_id, ignoreCache);
            var expected = TestData.RecipeDetailsExpected.Single(r => r.RecipeId == recipe_id);
            VerifyRecipeDetails(expected, actual);
        }
        [TestCase(true)]
        public void GetItemIdsTest(bool ignoreCache)
        {
            var actual = GwApi.GetItemIds(ignoreCache);
            var expected = TestData.ItemIdListExpected;
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestCase(true)]
        public void GetRecipeIdsTest(bool ignoreCache)
        {
            var actual = GwApi.GetRecipeIds(ignoreCache);
            var expected = TestData.RecipeIdListExpected;
            CollectionAssert.AreEquivalent(expected, actual);
        }

        #endregion Item and Recipe Database API - BETA

        #region Guild API - BETA
        [TestCase("Valour Of The Forsaken", true)]
        public void GetGuildDetailsByNameTest(string guild_name, bool ignoreCache)
        {
            var actual = GwApi.GetGuildDetailsByName(guild_name, ignoreCache);
            var expected = TestData.GuildDetailsExpected.Single(g => g.GuildName == guild_name);
            VerifyGuildDetailsEntry(expected, actual);
        }

        [TestCase("E27EB3AA-EAFA-4C1B-BA7A-5202A519E291", true)]
        public void GetGuildDetailsByIdTest(string guild_id, bool ignoreCache)
        {
            var actual = GwApi.GetGuildDetailsById(guild_id, ignoreCache);
            var expected = TestData.GuildDetailsExpected.Single(g => g.GuildId == g.GuildId);
            VerifyGuildDetailsEntry(expected, actual);
        }
        #endregion Guild API - BETA

        #region WvW API - BETA

        [TestCase(true)]
        public void GetMatchesTest(bool ignoreCache)
        {
            var actual = GwApi.GetMatches(ignoreCache);
            var expected = TestData.MatchEntriesExpected;
            VerifyMatches(expected, actual);
        }

        [TestCase("1-4", true)]
        public void GetMatchDetailsTest(string match_id, bool ignoreCache)
        {
            var actual = GwApi.GetMatchDetails(match_id, ignoreCache);
            var expected = TestData.MatchDetailsExpected.Single(g => g.Id == match_id);
            VerifyMatchDetails(expected, actual);
        }
        [TestCase(true)]
        public void GetObjectiveNamesTest(bool ignoreCache)
        {
            var actual = GwApi.GetObjectiveNames(ignoreCache);
            var expected = TestData.ObjectiveNamesExpected;
            VerifyObjectiveNames(expected, actual);
        }
        #endregion WvW API - BETA

        #region Map API - BETA
        [TestCase(true)]
        public void GetContinentsTest(bool ignoreCache)
        {
            var actual = GwApi.GetContinents(ignoreCache);
            var expected = TestData.ContinentEntriesExpected;
            VerifyContinentEntries(expected, actual);
        }

        [TestCase(true)]
        public void GetMapTest(bool ignoreCache)
        {
            var actual = GwApi.GetMap(ignoreCache);
            var expected = TestData.MapEntriesExpected;
            VerifyMaps(expected, actual);
        }

        [TestCase(2, 27, false)]
        public void GetMapFloorTest(int continent_id, int floor, bool ignoreCache)
        {
            var actual = GwApi.GetMapFloor(continent_id, floor, ignoreCache);
            var expected = TestData.MapFloorEntriesExpected;
            VerifyMapFloor(expected, actual);
        }

        #endregion Map API - BETA

        #region Miscellaneous APIs - BETA
        [TestCase(true)]
        public void GetColorsTest(bool ignoreCache)
        {
            var actual = GwApi.GetColors(ignoreCache);
            var expected = TestData.ColorEntriesExpected;
            VerifyColors(expected, actual);
        }
        [TestCase(false)]
        public void GetFilesTest(bool ignoreCache)
        {
            var actual = GwApi.GetFiles(ignoreCache);
            var expected = TestData.FileEntriesExpected;
            VerifyFiles(expected, actual);
        }

        [TestCase("943538394A94A491C8632FBEF6203C2013443555", 102478, "png", true)]
        [TestCase("5A4E663071250EC72668C09E3C082E595A380BF7", 528724, "png", true)]
        [TestCase("25B230711176AB5728E86F5FC5F0BFAE48B32F6E", 97461, "png", true)]
        [TestCase("5A4E663071250EC72668C09E3C082E595A380BF7", 528724, "jpg", true)]
        public void GetRenderServiceAssetEntryTest(string signature, int file_id, string format, bool ignoreCache)
        {
            string fpath = string.Format(@"..\..\..\TestData\file\{0}.{1}", file_id, format);

            RenderServiceAssetEntry RenderServiceAssetEntriesExpected =
            new RenderServiceAssetEntry
            {
                Url = string.Format("https://render.guildwars2.com/file/{0}/{1}.{2}",
                    signature, file_id, format),
                Asset = new Bitmap(fpath),
                File = new FileEntry
                {
                    Signature = signature,
                    FileID = file_id
                }
            };

            RenderServiceAssetEntry actual = GwApi.GetRenderServiceAssetEntry(signature, file_id, format, ignoreCache);

            VerifyRenderServiceAssetEntry(RenderServiceAssetEntriesExpected, actual);
        }
        [TestCase(Result = 21361)]
        public int GetBuildTest()
        {
            return GwApi.GetBuildNumber();
        }
        #endregion Miscellaneous APIs - BETA

        #region Helpers
        private void _verifyColorItemEntry(ColorEntry.ColorItemEntry expected, ColorEntry.ColorItemEntry actual)
        {
            Assert.AreEqual(expected.Brightness, actual.Brightness);
            Assert.AreEqual(expected.Contrast, actual.Contrast);
            Assert.AreEqual(expected.Hue, actual.Hue);
            Assert.AreEqual(expected.Saturation, actual.Saturation);
            Assert.AreEqual(expected.Lightness, actual.Lightness);
            Assert.AreEqual(expected.RGB, actual.RGB);
        }

        private bool RecipeCompare(RecipeIngredient a, RecipeIngredient b)
        {
            return (a != null && b != null &&
                    a.ItemId == b.ItemId &&
                    a.Count == b.Count);
        }

        #endregion Helpers
    }

    // Async api testing
    public partial class GwApiTest
    {
        #region Dynamic Events API - BETA
        [TestCase(-1, -1, null, true)]
        public void GetEventsAsyncTest(int world_id, int map_id, Guid? event_id, bool ignoreCache)
        {
            var actuals = GwApi.GetEventsAsync(world_id, map_id, event_id, ignoreCache);
            var expected = TestData.EventEntriesExpected;
            actuals.Wait();
            VerifyEvents(expected, actuals.Result);
        }
        [TestCase(true)]
        public void GetEventNamesAsyncTest(bool ignoreCache)
        {
            var actual = GwApi.GetEventNamesAsync(ignoreCache);
            var expected = TestData.EventNameEntriesExpected;
            actual.Wait();
            VerifyEventNamesEntries(expected, actual.Result);
        }

        [TestCase(true)]
        public void GetWorldNamesAsyncTest(bool ignoreCache)
        {
            var actual = GwApi.GetWorldNamesAsync(ignoreCache);
            var expected = TestData.WorldNameEntriesExpected;
            actual.Wait();
            VerifyWorldNamesEntries(expected, actual.Result);
        }

        [TestCase(true)]
        public void GetMapNamesAsyncTest(bool ignoreCache)
        {
            var actual = GwApi.GetMapNamesAsync(ignoreCache);
            var expected = TestData.MapNameEntriesExpected;
            actual.Wait();
            VerifyMapNamesEntries(expected, actual.Result);
        }

        [TestCase(null, true)]
        public void GetEventDetailsAsyncTest(string event_id, bool ignoreCache)
        {
            var actual = GwApi.GetEventDetailsAsync(event_id, ignoreCache);
            var expected = TestData.EventDetailsExpected;
            actual.Wait();
            VerifyEventDetails(expected, actual.Result);
        }

        #endregion Dynamic Events API - BETA

        #region Item and Recipe Database API - BETA
        [TestCase(12862, true)]
        public void GetItemDetailsAsyncTest(int item_id, bool ignoreCache)
        {
            var actualTask = GwApi.GetItemDetailsAsync(item_id, ignoreCache);
            var expected = TestData.ItemDetailsExpected.Single(i => i.ItemId == item_id);
            actualTask.Wait();
            VerifyItemDetails(expected, actualTask.Result);
        }

        [TestCase(1275, true)]
        public void GetRecipeDetailsAsyncTest(int recipe_id, bool ignoreCache)
        {
            var actual = GwApi.GetRecipeDetailsAsync(recipe_id, ignoreCache);
            var expected = TestData.RecipeDetailsExpected.Single(r => r.RecipeId == recipe_id);
            actual.Wait();
            VerifyRecipeDetails(expected, actual.Result);
        }
        [TestCase(true)]
        public void GetItemIdsAsyncTest(bool ignoreCache)
        {
            var actual = GwApi.GetItemIdsAsync(ignoreCache);
            var expected = TestData.ItemIdListExpected;
            actual.Wait();
            CollectionAssert.AreEquivalent(expected, actual.Result);
        }

        [TestCase(true)]
        public void GetRecipeIdsAsyncTest(bool ignoreCache)
        {
            var actual = GwApi.GetRecipeIdsAsync(ignoreCache);
            var expected = TestData.RecipeIdListExpected;
            actual.Wait();
            CollectionAssert.AreEquivalent(expected, actual.Result);
        }

        #endregion Item and Recipe Database API - BETA

        #region Guild API - BETA
        [TestCase("Valour Of The Forsaken", true)]
        public void GetGuildDetailsByNameAsyncTest(string guild_name, bool ignoreCache)
        {
            var actual = GwApi.GetGuildDetailsByNameAsync(guild_name, ignoreCache);
            var expected = TestData.GuildDetailsExpected.Single(g => g.GuildName == guild_name);
            actual.Wait();
            VerifyGuildDetailsEntry(expected, actual.Result);
        }

        [TestCase("E27EB3AA-EAFA-4C1B-BA7A-5202A519E291", true)]
        public void GetGuildDetailsByIdAsyncTest(string guild_id, bool ignoreCache)
        {
            var actual = GwApi.GetGuildDetailsByIdAsync(guild_id, ignoreCache);
            var expected = TestData.GuildDetailsExpected.Single(g => g.GuildId == g.GuildId);
            actual.Wait();
            VerifyGuildDetailsEntry(expected, actual.Result);
        }
        #endregion Guild API - BETA
        
        #region WvW API - BETA
        [TestCase(true)]
        public void GetMatchesAsyncTest(bool ignoreCache)
        {
            var actual = GwApi.GetMatchesAsync(ignoreCache);
            var expected = TestData.MatchEntriesExpected;
            actual.Wait();
            VerifyMatches(expected, actual.Result);
        }

        [TestCase("1-4", true)]
        public void GetMatchDetailsAsyncTest(string match_id, bool ignoreCache)
        {
            var actual = GwApi.GetMatchDetailsAsync(match_id, ignoreCache);
            var expected = TestData.MatchDetailsExpected.Single(g => g.Id == match_id);
            actual.Wait();
            VerifyMatchDetails(expected, actual.Result);

        }

        [TestCase(true)]
        public void GetObjectiveNamesAsyncTest(bool ignoreCache)
        {
            var actual = GwApi.GetObjectiveNamesAsync(ignoreCache);
            var expected = TestData.ObjectiveNamesExpected;
            actual.Wait();
            VerifyObjectiveNames(expected, actual.Result);
        }

        #endregion WvW API - BETA
        
        #region Map API - BETA

        [TestCase(true)]
        public void GetContinentsAsyncTest(bool ignoreCache)
        {
            var actual = GwApi.GetContinentsAsync(ignoreCache);
            var expected = TestData.ContinentEntriesExpected;
            actual.Wait();
            VerifyContinentEntries(expected, actual.Result);
        }
        [TestCase(true)]
        public void GetMapAsyncTest(bool ignoreCache)
        {
            var actual = GwApi.GetMapAsync(ignoreCache);
            var expected = TestData.MapEntriesExpected;
            actual.Wait();
            VerifyMaps(expected, actual.Result);
        }

        [TestCase(2, 27, false)]
        public void GetMapFloorAsyncTest(int continent_id, int floor, bool ignoreCache)
        {
            var actual = GwApi.GetMapFloorAsync(continent_id, floor, ignoreCache);
            var expected = TestData.MapFloorEntriesExpected;
            actual.Wait();
            VerifyMapFloor(expected, actual.Result);
        }
        #endregion Map API - BETA
        
        #region Miscellaneous APIs - BETA
        [TestCase(true)]
        public void GetColorsAsyncTest(bool ignoreCache)
        {
            var actual = GwApi.GetColorsAsync(ignoreCache);
            var expected = TestData.ColorEntriesExpected;
            actual.Wait();
            VerifyColors(expected, actual.Result);
        }

        [TestCase(false)]
        public void GetFilesAsyncTest(bool ignoreCache)
        {
            var actual = GwApi.GetFilesAsync(ignoreCache);
            var expected = TestData.FileEntriesExpected;
            actual.Wait();
            VerifyFiles(expected, actual.Result);
        }

        [TestCase("943538394A94A491C8632FBEF6203C2013443555", 102478, "png", true)]
        [TestCase("5A4E663071250EC72668C09E3C082E595A380BF7", 528724, "png", true)]
        [TestCase("25B230711176AB5728E86F5FC5F0BFAE48B32F6E", 97461, "png", true)]
        [TestCase("5A4E663071250EC72668C09E3C082E595A380BF7", 528724, "jpg", true)]
        public void GetRenderServiceAssetEntryAsyncTest(string signature, int file_id, string format, bool ignoreCache)
        {
            string fpath = string.Format(@"..\..\..\TestData\file\{0}.{1}", file_id, format);
            var RenderServiceAssetEntriesExpected =
                new RenderServiceAssetEntry
                    {
                        Url = string.Format("https://render.guildwars2.com/file/{0}/{1}.{2}",
                                            signature, file_id, format),
                        Asset = new Bitmap(fpath),
                        File = new FileEntry
                            {
                                Signature = signature,
                                FileID = file_id
                            }
                    };

            var actual = GwApi.GetRenderServiceAssetEntryAsync(signature, file_id, format, ignoreCache);
            actual.Wait();
            VerifyRenderServiceAssetEntry(RenderServiceAssetEntriesExpected, actual.Result);
        }

        #endregion Miscellaneous APIs - BETA
    }

    // verify functions
    public partial class GwApiTest
    {
        #region Dynamic Events API - BETA
        public void VerifyEvents(EntryCollection<EventEntry> expectedCol, EntryCollection<EventEntry> actuals)
        {
            foreach (var actual in actuals)
            {
                var expected = expectedCol.Single(e => e.EventId == actual.EventId);
                Assert.NotNull(expected);
                Assert.AreEqual(expected.WorldId, actual.WorldId);
                Assert.AreEqual(expected.MapId, actual.MapId);
                Assert.AreEqual(expected.EventId, actual.EventId);
                Assert.AreEqual(expected.State, actual.State);
            }
        }

        public void VerifyEventDetails(EntryDictionary<Guid, EventDetailsEntry> expected, EntryDictionary<Guid, EventDetailsEntry> actuals)
        {
            foreach (var pair in expected)
            {
                var entry = pair.Value;
                Assert.IsTrue(actuals.ContainsKey(pair.Key));
                var actualEntry = actuals[pair.Key];
                Assert.AreEqual(entry.Name, actualEntry.Name);
                Assert.AreEqual(entry.Level, actualEntry.Level);
                Assert.AreEqual(entry.MapId, actualEntry.MapId);
                Assert.AreEqual(entry.Location.Height, actualEntry.Location.Height);
                Assert.AreEqual(entry.Location.Radius, actualEntry.Location.Radius);
                Assert.AreEqual(entry.Location.Rotation, actualEntry.Location.Rotation);
                Assert.AreEqual(entry.Location.Type, actualEntry.Location.Type);
                if ((entry.Location.Center == null && actualEntry.Location.Center == null) == false)
                    CollectionAssert.AreEquivalent(entry.Location.Center, actualEntry.Location.Center);
                if ((entry.Location.Points == null && actualEntry.Location.Points == null) == false)
                    CollectionAssert.AreEquivalent(entry.Location.Points, actualEntry.Location.Points);
                if ((entry.Location.ZRange == null && actualEntry.Location.ZRange == null) == false)
                    CollectionAssert.AreEquivalent(entry.Location.ZRange, actualEntry.Location.ZRange);
            }
        }

        public void VerifyMapNamesEntries(EntryDictionary<int, MapNameEntry> expected,
                                      EntryDictionary<int, MapNameEntry> actual)
        {
            foreach (var pair in expected)
            {
                var actualEntry = actual[pair.Key];
                var expectedEntry = pair.Value;
                Assert.NotNull(actualEntry);
                Assert.AreEqual(expectedEntry.Name, actualEntry.Name);
            }
        }
        public void VerifyWorldNamesEntries(EntryDictionary<int, WorldNameEntry> expected,
                                      EntryDictionary<int, WorldNameEntry> actual)
        {
            foreach (var pair in expected)
            {
                var actualEntry = actual[pair.Key];
                var expectedEntry = pair.Value;
                Assert.NotNull(actualEntry);
                Assert.AreEqual(expectedEntry.Name, actualEntry.Name);
            }
        }
        public void VerifyEventNamesEntries(EntryDictionary<Guid, EventNameEntry> expected,
                                      EntryDictionary<Guid, EventNameEntry> actual)
        {
            foreach (var pair in expected)
            {
                var actualEntry = actual[pair.Key];
                var expectedEntry = pair.Value;
                Assert.NotNull(actualEntry);
                Assert.AreEqual(expectedEntry.Name, actualEntry.Name);
            }
        }
        #endregion Dynamic Events API - BETA

        #region Item and Recipe Database API - BETA
        public void VerifyRecipeDetails(RecipeDetailsEntry expected, RecipeDetailsEntry actual)
        {
            Assert.NotNull(actual,
                           "No value to compare to.  Add RecipeDetailsExpected to List<RecipeDetailsExpected> for verification");
            Assert.AreEqual(expected.RecipeType, actual.RecipeType);
            Assert.AreEqual(expected.OutputItemId, actual.OutputItemId);
            Assert.AreEqual(expected.OutputCount, actual.OutputCount);
            Assert.AreEqual(expected.MinRating, actual.MinRating);
            Assert.AreEqual(expected.TimeToCraftMsec, actual.TimeToCraftMsec);
            Assert.AreEqual(expected.Diciplines, actual.Diciplines);
            Assert.AreEqual(expected.Flags, actual.Flags);
            Assert.AreEqual(expected.Ingredients.Count, actual.Ingredients.Count);
            foreach (var ingredient in expected.Ingredients)
            {
                Assert.IsTrue(RecipeCompare(ingredient, actual.Ingredients.Single(i => i.ItemId == ingredient.ItemId)));
            }
        }
        public void VerifyItemDetails(ItemDetailsEntry expected, ItemDetailsEntry actual)
        {
            Assert.NotNull(actual,
                           "No item to compare to.  Add ItemDetailEntry to ItemDetailsExpected list for verification");
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.ItemType, actual.ItemType);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Rarity, actual.Rarity);
            Assert.AreEqual(expected.VendorValue, actual.VendorValue);
            Assert.AreEqual(expected.IconFileId, actual.IconFileId);
            Assert.AreEqual(expected.IconFileSignature, actual.IconFileSignature);
            Assert.AreEqual(expected.GameType, actual.GameType);
            Assert.AreEqual(expected.Flags, actual.Flags);
            Assert.AreEqual(expected.Restrictions, actual.Restrictions);
        }
        #endregion Item and Recipe Database API - BETA

        #region Guild API - BETA
        public void VerifyGuildDetailsEntry(GuildDetailsEntry expected, GuildDetailsEntry actual)
        {
            Assert.NotNull(actual,
                           "No value to compare to.  Add GuildDetailsExpected to List<GuildDetailsExpected> for verification");
            Assert.AreEqual(expected.GuildId, actual.GuildId);
            Assert.AreEqual(expected.GuildName, actual.GuildName);
            Assert.AreEqual(expected.Tag, actual.Tag);
            Assert.AreEqual(expected.Emblem.BackgroundId, actual.Emblem.BackgroundId);
            Assert.AreEqual(expected.Emblem.ForegroundId, actual.Emblem.ForegroundId);
            Assert.AreEqual(expected.Emblem.Flags, actual.Emblem.Flags);
            Assert.AreEqual(expected.Emblem.BackgroundColorId, actual.Emblem.BackgroundColorId);
            Assert.AreEqual(expected.Emblem.ForegroundPrimaryColorId, actual.Emblem.ForegroundPrimaryColorId);
            Assert.AreEqual(expected.Emblem.ForegroundSecondaryColorId, actual.Emblem.ForegroundSecondaryColorId);
        }
        #endregion Guild API - BETA

        #region WvW API - BETA
        public void VerifyMatches(EntryDictionary<string, MatchEntry> expected, EntryDictionary<string, MatchEntry> actual)
        {
            foreach (var pair in expected)
            {
                var actualEntry = actual[pair.Key];
                var expectedEntry = pair.Value;
                Assert.NotNull(actualEntry);
                Assert.AreEqual(expectedEntry.BlueWorldId, actualEntry.BlueWorldId);
                Assert.AreEqual(expectedEntry.EndTime, actualEntry.EndTime);
                Assert.AreEqual(expectedEntry.GreenWorldId, actualEntry.GreenWorldId);
                Assert.AreEqual(expectedEntry.Id, actualEntry.Id);
                Assert.AreEqual(expectedEntry.RedWorldId, actualEntry.RedWorldId);
                Assert.AreEqual(expectedEntry.StartTime, actualEntry.StartTime);
            }
        }
        public void VerifyMatchDetails(MatchDetailsEntry expected, MatchDetailsEntry actual)
        {
            Assert.NotNull(actual,
                           "No value to compare to.  Add MatchDetailsExpected to List<MatchDetailsExpected> for verification");
            Assert.AreEqual(expected.Id, actual.Id);
            CollectionAssert.AreEquivalent(expected.Scores, actual.Scores);
            Assert.AreEqual(expected.Maps.Count, actual.Maps.Count);
            for (int i = 0; i < expected.Maps.Count; i++)
            {
                Assert.AreEqual(expected.Maps[i].Type, expected.Maps[i].Type);
                CollectionAssert.AreEquivalent(expected.Maps[i].Scores, actual.Maps[i].Scores);
                foreach (var objective in expected.Maps[i].Objectives)
                {
                    var actualObjective = actual.Maps[i].Objectives.Single(o => o.Id == objective.Id);
                    Assert.NotNull(actual, "No object with id found {0}", objective.Id);
                    Assert.AreEqual(objective.Owner, actualObjective.Owner);
                    Assert.AreEqual(objective.OwnerGuildId, actualObjective.OwnerGuildId);
                }
            }
        }
        public void VerifyObjectiveNames(EntryDictionary<int, ObjectiveNameEntry> expected,
                                         EntryDictionary<int, ObjectiveNameEntry> actuals)
        {
            foreach (var pair in expected)
            {
                var expectedEntry = pair.Value;
                var actual = actuals[expectedEntry.Id];
                Assert.NotNull(actual);
                Assert.AreEqual(expectedEntry.Name, actual.Name);
            }
        }
        #endregion WvW API - BETA

        #region Map API - BETA
        public void VerifyContinentEntries(EntryDictionary<int, ContinentEntry> expected, EntryDictionary<int, ContinentEntry> actual)
        {
            foreach (var pair in expected)
            {
                var expectedEntry = pair.Value;
                var actualEntry = actual[pair.Key];
                Assert.AreEqual(expectedEntry.Id, actualEntry.Id, "Id");
                Assert.AreEqual(expectedEntry.Name, actualEntry.Name, "Name");
                Assert.AreEqual(expectedEntry.MinZoom, actualEntry.MinZoom, "MinZoom");
                Assert.AreEqual(expectedEntry.MaxZoom, actualEntry.MaxZoom, "MaxZoom");
                CollectionAssert.AreEquivalent(expectedEntry.Dimension, actualEntry.Dimension, "Dimensions Error");
                CollectionAssert.AreEquivalent(expectedEntry.Floors, actualEntry.Floors, "Floors Error");
            }
        }

        public void VerifyMaps(EntryDictionary<int, MapEntry> expected,
                                           EntryDictionary<int, MapEntry> actual)
        {
            foreach (var pair in expected)
            {
                var actualMap = actual[pair.Key];
                var expectedMap = pair.Value;
                Assert.AreEqual(expectedMap.MapName, actualMap.MapName);
                Assert.AreEqual(expectedMap.MinLevel, actualMap.MinLevel);
                Assert.AreEqual(expectedMap.MaxLevel, actualMap.MaxLevel);
                Assert.AreEqual(expectedMap.DefaultFloor, actualMap.DefaultFloor);
                CollectionAssert.AreEquivalent(expectedMap.Floors, actualMap.Floors);
                Assert.AreEqual(expectedMap.RegionId, actualMap.RegionId);
                Assert.AreEqual(expectedMap.RegionName, actualMap.RegionName);
                Assert.AreEqual(expectedMap.ContinentId, actualMap.ContinentId);
                Assert.AreEqual(expectedMap.ContinentName, actualMap.ContinentName);
                CollectionAssert.AreEquivalent(expectedMap.MapRectangle, actualMap.MapRectangle);
                CollectionAssert.AreEquivalent(expectedMap.ContinentRectangle, actualMap.ContinentRectangle);

            }
        }

        public void VerifyMapFloor(MapFloorEntry expected, MapFloorEntry actual)
        {
            Assert.AreEqual(expected.TextureDimensions, actual.TextureDimensions, "Texture Dimensions");
            foreach (var regionPair in expected.Regions)
            {
                var expectedRegion = regionPair.Value;
                var actualRegion = actual.Regions[regionPair.Key];
                Assert.AreEqual(expectedRegion.Id, actualRegion.Id);
                Assert.AreEqual(expectedRegion.Name, actualRegion.Name);
                Assert.AreEqual(expectedRegion.LabelCoord, actualRegion.LabelCoord);
                foreach (var mapsPair in expectedRegion.Maps)
                {
                    var expectedMap = mapsPair.Value;
                    var actualMap = actualRegion.Maps[mapsPair.Key];
                    Assert.AreEqual(expectedMap.Id, actualMap.Id);
                    Assert.AreEqual(expectedMap.Name, actualMap.Name);
                    Assert.AreEqual(expectedMap.MinLevel, actualMap.MinLevel);
                    Assert.AreEqual(expectedMap.MaxLevel, actualMap.MaxLevel);
                    Assert.AreEqual(expectedMap.MapRectangle, actualMap.MapRectangle);
                    Assert.AreEqual(expectedMap.ContinentRectangle, actualMap.ContinentRectangle);
                    foreach (var expectedPoi in expectedMap.PointsOfInterest)
                    {
                        var actualPoi = actualMap.PointsOfInterest.Single(p => p.Id == expectedPoi.Id);
                        Assert.AreEqual(expectedPoi.Id, actualPoi.Id);
                        Assert.AreEqual(expectedPoi.Name, actualPoi.Name);
                        Assert.AreEqual(expectedPoi.Type, actualPoi.Type);
                        Assert.AreEqual(expectedPoi.Floor, actualPoi.Floor);
                        Assert.AreEqual(expectedPoi.Coordinates, actualPoi.Coordinates);
                    }
                    foreach (var expectedTasks in expectedMap.Tasks)
                    {
                        var actualTasks = actualMap.Tasks.Single(p => p.Id == expectedTasks.Id);
                        Assert.AreEqual(expectedTasks.Id, actualTasks.Id);
                        Assert.AreEqual(expectedTasks.Objective, actualTasks.Objective);
                        Assert.AreEqual(expectedTasks.Level, actualTasks.Level);
                        Assert.AreEqual(expectedTasks.Coordinates, actualTasks.Coordinates);
                    }
                    Assert.AreEqual(expectedMap.SkillChallenges, actualMap.SkillChallenges);
                    foreach (var expectedSectors in expectedMap.Sectors)
                    {
                        var actualSectors = actualMap.Sectors.Single(p => p.Id == expectedSectors.Id);
                        Assert.AreEqual(expectedSectors.Id, actualSectors.Id);
                        Assert.AreEqual(expectedSectors.Name, actualSectors.Name);
                        Assert.AreEqual(expectedSectors.Level, actualSectors.Level);
                        Assert.AreEqual(expectedSectors.Coordinates, actualSectors.Coordinates);
                    }
                }
            }
        }

        #endregion Map API - BETA

        #region Miscellaneous APIs - BETA
        public void VerifyColors(EntryDictionary<int, ColorEntry> expected,
                                EntryDictionary<int, ColorEntry> actual)
        {
            foreach (var pair in expected)
            {
                var actualEntry = actual[pair.Key];
                var entry = pair.Value;
                Assert.NotNull(actualEntry);
                Assert.AreEqual(entry.Id, actualEntry.Id);
                Assert.AreEqual(entry.Name, actualEntry.Name);
                Assert.AreEqual(entry.BaseRGB, actualEntry.BaseRGB);
                _verifyColorItemEntry(entry.Cloth, actualEntry.Cloth);
                _verifyColorItemEntry(entry.Leather, actualEntry.Leather);
                _verifyColorItemEntry(entry.Metal, actualEntry.Metal);
            }
        }

        public void VerifyFiles(EntryDictionary<string, FileEntry> expected,
                                 EntryDictionary<string, FileEntry> actual)
        {
            foreach (var pair in expected)
            {
                var expectedEntry = pair.Value;
                var actualEntry = actual[pair.Key];
                Assert.AreEqual(expectedEntry.FileID, actualEntry.FileID);
                Assert.AreEqual(expectedEntry.Signature, actualEntry.Signature);
            }
        }
        public void VerifyRenderServiceAssetEntry(RenderServiceAssetEntry expected, RenderServiceAssetEntry actual)
        {
            Assert.AreEqual(expected.Url, actual.Url);
            Assert.AreEqual(expected.File.FileID, actual.File.FileID);
            Assert.AreEqual(expected.File.Signature, actual.File.Signature);

            ImageConverter converter = new ImageConverter();
            byte[] expectedImageBytes = (byte[])converter.ConvertTo(expected.Asset, typeof(byte[]));
            byte[] actualImageBytes = (byte[])converter.ConvertTo(actual.Asset, typeof(byte[]));

            Assert.AreEqual(expectedImageBytes, actualImageBytes);
        }


        #endregion Miscellaneous APIs - BETA
    }
}
