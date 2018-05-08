using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.ResponseObjects;
using NUnit.Framework;

namespace GwApiNETTest
{

    public class ExampleCodeSnippets
    {
        #region Api Calls

        #region Dynamic Events API – BETA

        public void EventsExample()
        {
            GwApi.Network = new NetworkHandler();
            // First lets find out what my world ID is
            var worldNames = GwApi.GetWorldNames();
            int world_id = worldNames.Values.Single(w => w.Name == "Sorrow's Furnace").Id;

            // now lets get the event names and map names
            // These are lookups keyed on ID value
            var eventNames = GwApi.GetEventNames();
            var maps = GwApi.GetMapNames();

            // Now lets get a list of events on my world
            // We can use include whatever information we want to query with
            // In this case we want all events where the world id = world_id
            // we could also reduce our search further by providing a map id or event an event id
            var events = GwApi.GetEvents(world_id, -1, null);

            // Lets print all of the active events
            // We can show the map the event is on and it's name
            var activeEvents = events.Where(e => e.State == EventState.Active);

            // Lets get the event details for all events
            // we could request a single event detail by providing the event id as well
            var eventDetails = GwApi.GetEventDetails();
            
            // we'll use a StringBuilder to compose our print list
            var sb = new StringBuilder("--- Active Event List ---\n");
            foreach (var e in activeEvents)
            {
                // event detail for current e
                var eventDetail = eventDetails[e.EventId];
                sb.AppendFormat("Name: {0}\n", eventDetail.Name);
                sb.AppendFormat("Map: {0}\n", maps[eventDetail.MapId].Name);
                sb.AppendFormat("Level: {0}\n", eventDetail.Level);
                sb.AppendLine("--------");
            }
            // Print the contents
            Console.WriteLine(sb.ToString());

            // We've just downloaded a bunch of data which takes a bit of time
            // Sepcifically the complete event details list
            // If we save this, the next time we need the list it will take very little time
            ResponseCache.Cache.Save();
        }
        #endregion Dynamic Events API – BETA

        #region Item and Recipe Database API – BETA

        public void ItemDetailsExample()
        {
            GwApi.Network = new NetworkHandler();
            
            // Lets get the details of my awesome item.
            var item = GwApi.GetItemDetails(39276);
            StringBuilder sb = new StringBuilder(string.Format("{0} - Item Detail\n", item.ItemId));
            sb.AppendFormat("Name: {0}\n", item.Name);
            sb.AppendFormat("{0}\n", item.Description);
            sb.AppendFormat("Level: {0}\n", item.Level);
            sb.AppendFormat("Rarity: {0}\n", item.Rarity);
            sb.AppendFormat("Type: {0}\n", item.ItemType);
            sb.AppendFormat("Value: {0}\n", item.VendorValue);
            sb.AppendFormat("Buffs:\n");
            sb.AppendFormat("{0}\n", item.TrinketDetails.InfixUpgrade.Buff.Description);
            sb.AppendFormat("Attributes:\n");
            foreach (var attr in item.TrinketDetails.InfixUpgrade.Attributes)
                sb.AppendFormat("\t{0}:{1}\n", attr.Attribute, attr.Modifier);
            sb.AppendFormat("Infusion Slots ({0}):\n", item.TrinketDetails.InfusionSlots.Count);
            for(int i = 0; i < item.TrinketDetails.InfusionSlots.Count; i++)
                sb.AppendFormat("\tType: {1} - {0}\n", item.TrinketDetails.InfusionSlots[i].Item ?? "Unused", string.Join(",", item.TrinketDetails.InfusionSlots[i].Flags));

            Console.WriteLine(sb.ToString());
        }

        public void DownloadAllItemDetails()
        {
            // Warning this will take quite a long time.
            // It is highly recommended that you save this information as it is not expected to change often if at all
            // Luckily we can use the ResponseCache to do this for us.
            // Here is an example to download the data/save it, and allow for updates later

            {
                // lets obtain all the currently known item ids
                var itemIds = GwApi.GetItemIds();
                var itemDetailsDictionary = new EntryDictionary<int, ItemDetailsEntry>(itemIds.Count);
                // This could take 20-30 minutes
                // keep in mind there are currently 27,000+ items at the time of writting this
                foreach (var id in itemIds)
                {
                    var item = GwApi.GetItemDetails(id);
                    itemDetailsDictionary.Add(id, item);
                }

                // This is important, We should save this for nice and fast retrival
                // While our individual items are already stored in the ResponseCache
                // The dictionary is not, and it is much more convenient to just grab the entire dictionary
                // This will allow us easy access to search for items
                // We are going to store it using ItemDetailsDictionary
                ResponseCache.Cache.Add("ItemDetailsDictionary", itemDetailsDictionary);
            }

            {
                // lets update our complete dictionary of items we've already downloaded earlier
                // first lets obtain the complete list of item ids
                // notice how we passed (true) this time.  This will skip our response cache and for an update.
                // We want to make sure we have a complete list as of right now, not yesterday
                var itemIds = GwApi.GetItemIds(true);
                // Lets get the item dictionary we already have (Remember we stored it in cache)
                var itemDetailsDictionary =
                    ResponseCache.Cache.Get("ItemDetailsDictionary") as EntryDictionary<int, ItemDetailsEntry> ?? new EntryDictionary<int, ItemDetailsEntry>();
                // This could take 20-30 minutes
                // keep in mind there are currently 27,000+ items at the time of writting this
                foreach (var id in itemIds)
                {
                    if (itemDetailsDictionary.ContainsKey(id) == false)
                    {
                        var item = GwApi.GetItemDetails(id);
                        itemDetailsDictionary.Add(id, item);
                    }
                }

                // Lets update our ResponseCache with our updated item dictionary
                ResponseCache.Cache.Add("ItemDetailsDictionary", itemDetailsDictionary);
            }

            {
                // We have this big dictionary that took a really long time to download
                // What can we do with it?
                // Store it in a DataBase? sure that's not a bad idea.  Could make searching through it easy and quick.
                // We can also use LINQ - this is a great idea for those non-repeated retrival instances
                // First lets get our item dictionary
                var itemDetailsDictionary =
                    ResponseCache.Cache.Get("ItemDetailsDictionary") as EntryDictionary<int, ItemDetailsEntry> ?? new EntryDictionary<int, ItemDetailsEntry>();
                
                // Search for an item by name
                var item = itemDetailsDictionary.Values.SingleOrDefault(i => i.Name == "Godrock Amulet");
                // Get all lvl 80 items
                var itemsByLevel = itemDetailsDictionary.Values.Where(i => i.Level == 80);
                // What about all lvl 80 weapons
                itemsByLevel = itemDetailsDictionary.Values.Where(i => i.Level == 80 && i.ItemType == ItemType.Weapon);
                // Lets reduce the previous query to all swords; then we'll have all lvl 80 swords
                var swords =
                    itemsByLevel.Where(i => i.WeaponDetails.Type == ItemDetailsEntry.WeaponInfo.WeaponType.Sword);

                // Lets get all swords within 2 levels of 40
                itemsByLevel = itemDetailsDictionary.Values.Where(i => i.ItemType == ItemType.Weapon && i.WeaponDetails.Type == ItemDetailsEntry.WeaponInfo.WeaponType.Sword && i.Level >= 38 && i.Level <= 42);
            }
        }

        public void ExampleRecipeDetails()
        {
            var recipe = GwApi.GetRecipeDetails(1482);
            StringBuilder sb = new StringBuilder(string.Format("{0} - Recipe\n", recipe.RecipeId));
            sb.AppendFormat("Diciplines: {0}\n",string.Join(",", recipe.Diciplines));
            sb.AppendFormat("{0} x{1}\n", GwApi.GetItemDetails(recipe.OutputItemId).Name, recipe.OutputCount);
            sb.AppendFormat("Min Skill Needed: {0}\n", recipe.MinRating);
            sb.AppendFormat("Type: {0}\n", recipe.RecipeType);
            sb.AppendFormat("Crafting Time: {0:#.###}s\n", recipe.TimeToCraftMsec / 1000.0);
            sb.AppendFormat("Ingredients:\n");
            foreach (var ing in recipe.Ingredients)
                sb.AppendFormat("\t{0} x{1}\n", GwApi.GetItemDetails(ing.ItemId).Name, ing.Count);

            Console.WriteLine(sb.ToString());
        }


        #endregion Item and Recipe Database API – BETA

        #region Guild API – BETA

        public void GuildExample()
        {
            var guild = GwApi.GetGuildDetailsByName("Valour Of The Forsaken");
            StringBuilder sb = new StringBuilder("Guild Info\n");
            sb.AppendFormat("Name: {0}\n", guild.GuildName);
            sb.AppendFormat("Tag: {0}\n", guild.Tag);
            sb.AppendFormat("ID: {0}\n", guild.GuildId);
            sb.AppendFormat("We have emblem information too. " +
                            "But we can't display that in console.  " +
                            "I'll leave that up to you to implement for now.\n");

            Console.WriteLine(sb.ToString());
        }

        #endregion Guild API – BETA

        #region WvW API – BETA

        public void MatchesExample()
        {
            GwApi.Network = new NetworkHandler();
            // Well need this so lets get it now
            var worlds = GwApi.GetWorldNames();
            var objectives = GwApi.GetObjectiveNames();

            // Lets get a list of matches
            var matches = GwApi.GetMatches();
            var match = matches.Values.FirstOrDefault();
            // ok lets check out the details of one of these matches
            var details = GwApi.GetMatchDetails(match.Id);
            StringBuilder sb = new StringBuilder("Match Info\n");
            sb.AppendFormat("Worlds:\n");
            sb.AppendFormat("{0} vs. {1} vs. {2}\n", worlds[match.RedWorldId].Name, worlds[match.BlueWorldId].Name, worlds[match.GreenWorldId].Name);
            sb.AppendFormat("Scores: Red - {0}; Blue - {1}; Green - {2}\n", details.Scores[0], details.Scores[1], details.Scores[2]);
            sb.AppendFormat("Start Time: {0}\n", match.StartTime);
            sb.AppendFormat("End Time: {0}\n", match.EndTime);
            sb.AppendFormat("Maps:\n");
            foreach (var map in details.Maps)
            {
                sb.AppendFormat("  {0}\n", map.Type);
                sb.AppendFormat("  Scores: Red - {0}; Blue - {1}; Green - {2}\n", map.Scores[0], map.Scores[1], map.Scores[2]);
                foreach (var objective in map.Objectives)
                {
                    sb.AppendFormat("  {0} - {1}\n", objectives[objective.Id].Name, objective.Owner);
                    if (objective.OwnerGuildId != Guid.Empty)
                        sb.AppendFormat("    Guild: {0}\n", GwApi.GetGuildDetailsById(objective.OwnerGuildId).GuildName);
                }
            }

            Console.WriteLine(sb.ToString());
        }

        public void test()
        {
            GwApi.Network = new NetworkHandler();
            // Well need this so lets get it now
            var worlds = GwApi.GetWorldNames();
            var objectives = GwApi.GetObjectiveNames();

            // Lets get a list of matches
            var matches = GwApi.GetMatches();
            int id = worlds.Values.Single(w => w.Name == "Sorrow's Furnace").Id;
            Console.WriteLine("ID: " + id);
            var mymatch = matches.Values.Where(m => m.BlueWorldId == id || m.RedWorldId == id || m.GreenWorldId == id);
            foreach (var match in mymatch)
            {
                Console.WriteLine("M ID: " + match.Id);
            }
        }
        #endregion WvW API – BETA

        #region Map API – BETA

        #endregion Map API – BETA

        #region Miscellaneous APIs – BETA
        public void FilesExample()
        {
            var files = GwApi.GetFiles();
            StringBuilder sb = new StringBuilder("File Info\n");
            foreach (var file in files.Values)
            {
                sb.AppendFormat("ID: {0}", file.FileID);
                sb.AppendFormat("Signature: {0}", file.Signature);
                sb.AppendLine("Well that wasn't very interesting.\n Now what?");
                sb.AppendLine("Check out the Render Services example on what to do with this boring file information");
            }
        }
        public void RenderServiceExample()
        {
            // Lets get a list of available images
            var files = GwApi.GetFiles();
            foreach (var file in files)
            {   // Lets save them to disk
                var image = GwApi.GetRenderServiceAssetEntry(file.Value, "jpg");
                image.Asset.Save(file.Key + ".jpg");
            }
            // Lets open one of the images in a default image viewer
            Process.Start(files.Keys.First() + ".jpg");
        }

        public void RenderServiceExample2()
        {
            // Lets get an item
            var item = GwApi.GetItemDetails(39276);
            // Now lets download it's icon image
            var image = GwApi.GetRenderServiceAssetEntry(item.IconFileSignature, item.IconFileId, "jpg");
            image.Asset.Save(item.ItemId + ".jpg");

            // Lets open the image in a default image viewer
            Process.Start(item.ItemId + ".jpg");
        }
        #endregion Miscellaneous APIs – BETA


        #endregion Api Calls

    }
}
