using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using NUnit.Framework;
using RestSharp;

namespace GwApiNETTest
{

    public class MockNetworkHandlerTest
    {
        private string baseDir = @"..\..\..\TestData";
        
        [TestCase("continents.json")]
        [TestCase("events.json")]
        [TestCase("events.json?world_id=1001")]
        [TestCase("event_details.json")]
        [TestCase("event_details.json?event_id=EED8A79F-B374-4AE6-BA6F-B7B98D9D7142")]
        [TestCase("event_names.json")]
        [TestCase("guild_details.json?guild_name=Valour of the Forsaken")]
        [TestCase("items.json")]
        [TestCase("item_details.json?item_id=12862")]
        [TestCase("maps.json")]
        [TestCase("map_floor.json?continent_id=1&floor=0")]
        [TestCase("map_names.json")]
        [TestCase("recipes.json")]
        [TestCase("recipe_details.json?recipe_id=1275")]
        [TestCase("world_names.json")]
        [TestCase("wvw/matches.json")]
        [TestCase("wvw/match_details.json?match_id=1-4")]
        [TestCase("colors.json")]
        [TestCase("build.json")]
        [TestCase("wvw/objective_names.json")]
        public void GetResponse(string url)
        {
            MockNetworkHandler network = new MockNetworkHandler(baseDir);
            ApiRequest request = new ApiRequest();
            request.Resource = url;
            IRestResponse response = network.GetResponse<IRestResponse>(request);
            Console.WriteLine(response.Content);
        }

    }
}
