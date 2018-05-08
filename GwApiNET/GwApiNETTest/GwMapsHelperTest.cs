using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.ResponseObjects;
using NUnit.Framework;

namespace GwApiNETTest
{
    public class GwMapsHelperTest
    {

        public void Setup()
        {
            
        }

        public const int TileSize = 256;

        [TestCase(1, 1, 35, 7, 7168 + 24576 / 24, 17152 + 39936 / 24, 0, 0, Description = "Center world coordinate of Map")]
        [TestCase(1, 1, 35, 7, (9344 - 7168) / 2 + 7168, (20480 - 17152) / 2 + 17152, (27648 + 24576) / 2 - 24576, 0,Description = "Center pixel of Map")]
        [TestCase(1, 1, 35, 7, 7168, 17152, -24576, 39936, Description = "Top Left pixel of Map")]
        [TestCase(1, 1, 35, 0, 56, 134, -24576, 39936, Description = "Top Left pixel of Map")]
        [TestCase(1, 1, 35, 7, 9344, 20480, 27648, -39936, Description = "Bottom right pixel of Map")]
        [TestCase(1, 1, 35, 7, 8877.05, 17747.6, 16441.199999999983d, 25641.600000000035d,Description = "Upper right quadrant of map")]
        [TestCase(1, 1, 35, 7, 8068.11, 17585.7, -2973.3600000000079d, 29527.199999999983d,Description = "Upper right quadrant of map")]
        [TestCase(1, 1, 35, 7, 7815.45, 19958.7, -9037.2000000000044d, -27424.800000000017d,Description = "Bottom Left quadrant of map")]
        [TestCase(1, 1, 35, 7, 9212.08, 19796.3, 24481.92d, -23527.199999999983d,Description = "Bottom right quadrant of map")]
        [TestCase(1, 1, 35, 7, 9212.08, 19796.3, 24481.92d, -23527.199999999983d,Description = "Bottom right quadrant of map")]
        [TestCase(1, 1, 35, 6, 9212.08/2, 19796.3/2, 24481.92d, -23527.199999999983d,Description = "Bottom right quadrant of map")]
        public void PixelToWorldPosTest(int continent, int floor, int mapid, int zoom, double pixelX, double pixelY,
                                        double expWorldX, double expWorldY)
        {
            var mapEntry = GwApi.GetMapFloor(continent, floor);
            var region = mapEntry.Regions.Values.Single(r => r.Maps.Values.Count(m => m.Id == mapid) == 1);
            var map = region.Maps.Values.Single(m => m.Id == mapid);
            var worldPos = GwMapsHelper.PixelToWorldPos(map, new Gw2Point {X = pixelX, Y = pixelY}, zoom);
            Console.WriteLine(worldPos);
            var expectedPoint = new Gw2Point {X = expWorldX, Y = expWorldY};
            Assert.AreEqual(expectedPoint, worldPos);
        }

        [TestCase(1, 1, 35, 7, 0, 0, 7168 + 24576/24, 39936/24 + 17152, Description = "Center World Coordinate of Map")]
        [TestCase(1, 1, 35, 7, (27648 + 24576) / 2 - 24576, 0, (9344 - 7168) / 2 + 7168, (20480 - 17152) / 2 + 17152,Description = "Center pixel of Map")]
        [TestCase(1, 1, 35, 7, -24576, 39936, 7168, 17152, Description = "Top Left pixel of Map")]
        [TestCase(1, 1, 35, 0, -24576, 39936, 56, 134, Description = "Top Left pixel of Map")]
        [TestCase(1, 1, 35, 7, 27648, -39936, 9344, 20480, Description = "Bottom right pixel of Map")]
        [TestCase(1, 1, 35, 7, 16441.199999999983d, 25641.600000000035d, 8877.05, 17747.6,Description = "Upper right quadrant of map")]
        [TestCase(1, 1, 35, 7, -2973.3600000000079d, 29527.199999999983d, 8068.11, 17585.7,Description = "Upper right quadrant of map")]
        [TestCase(1, 1, 35, 7, -9037.2000000000044d, -27424.800000000017d, 7815.45, 19958.7,Description = "Bottom Left quadrant of map")]
        [TestCase(1, 1, 35, 7, 24481.92d, -23527.199999999983d, 9212.08, 19796.3,Description = "Bottom right quadrant of map")]
        [TestCase(1, 1, 35, 5, 24481.92d, -23527.199999999983d, 9212.08/4, 19796.3/4,Description = "Bottom right quadrant of map")]
        public void WorldPosToPixelTest(int continent, int floor, int mapid, int zoom, double worldX, double worldY,
                                        double expPixelX, double expPixelY)
        {
            var mapEntry = GwApi.GetMapFloor(continent, floor);
            var region = mapEntry.Regions.Values.Single(r => r.Maps.Values.Count(m => m.Id == mapid) == 1);
            var map = region.Maps.Values.Single(m => m.Id == mapid);
            var pixelPoint = GwMapsHelper.WorldPosToPixel(map, new Gw2Point {X = worldX, Y = worldY}, zoom);
            Console.WriteLine(pixelPoint);
            var expectedPoint = new Gw2Point {X = expPixelX, Y = expPixelY};
            Assert.AreEqual(expectedPoint, pixelPoint);
        }

        [TestCase(1, 1, 35, 7, 0, 0, (7168 + 24576 / 24) / TileSize, (39936 / 24 + 17152) / TileSize)]
        [TestCase(1, 1, 35, 7, (27648 + 24576) / 2 - 24576, 0, ((9344 - 7168) / 2 + 7168) / TileSize,((20480 - 17152)/2 + 17152)/TileSize, Description = "Center tile of Map")]
        [TestCase(1, 1, 35, 7, -24576, 39936, 7168 / TileSize, 17152 / TileSize, Description = "Top Left tile of Map")]
        [TestCase(1, 1, 35, 7, 27648, -39936, 9344 / TileSize, 20480 / TileSize, Description = "Bottom right tile of Map")]
        [TestCase(1, 1, 35, 7, 16441.199999999983d, 25641.600000000035d, (int)8877.05 / TileSize, (int)17747.6 / TileSize,Description = "Upper right quadrant of map")]
        [TestCase(1, 1, 35, 4, -2973.3600000000079d, 29527.199999999983d, 3, 8 ,Description = "Upper right quadrant of map")]
        [TestCase(1, 1, 35, 7, -9037.2000000000044d, -27424.800000000017d, (int)7815.45 / TileSize, (int)19958.7 / TileSize,Description = "Bottom Left quadrant of map")]
        [TestCase(1, 1, 35, 1, -9037.2000000000044d, -27424.800000000017d, 0, 1,Description = "Bottom Left quadrant of map")]
        [TestCase(1, 1, 35, 7, 24481.92d, -23527.199999999983d, (int)9212.08 / TileSize, (int)19796.3 / TileSize,Description = "Bottom right quadrant of map")]
        [TestCase(1, 1, 35, 0, 24481.92d, -23527.199999999983d, 0, 0,Description = "Bottom right quadrant of map")]
        public void WorldPosToTileTest(int continent, int floor, int mapid, int zoom, double worldX, double worldY, int expTileX,
                                   int expTileY)
        {
            var mapEntry = GwApi.GetMapFloor(continent, floor);
            var region = mapEntry.Regions.Values.Single(r => r.Maps.Values.Count(m => m.Id == mapid) == 1);
            var map = region.Maps.Values.Single(m => m.Id == mapid);
            var tilePoint = GwMapsHelper.WorldPosToTile(map, new Gw2Point {X = worldX, Y = worldY}, zoom);
            Console.WriteLine(tilePoint);
            var expectedPoint = new Gw2Point {X = expTileX, Y = expTileY};
            Assert.AreEqual(expectedPoint, tilePoint);
        }

        [TestCase(1, 1, 35, 3, -24576, 39936, 192, 48, Description = "Top Left pixel of Map")]
        [TestCase(1, 1, 35, 2, -24576, 39936, 224, 24, Description = "Top Left pixel of Map")]
        [TestCase(1, 1, 35, 1, -24576, 39936, 112, 12, Description = "Top Left pixel of Map")]
        [TestCase(1, 1, 35, 0, -24576, 39936, 56, 134, Description = "Top Left pixel of Map")]
        [TestCase(1, 1, 35, 6, 16441.199999999983d, 25641.600000000035d, 86.5249999999996d, 169.799999999999d, Description = "Upper right quadrant of map")]
        public void WorldPosToTilePixelTest(int continent, int floor, int mapid, int zoom, double worldX, double worldY,
                                        double expTilePixX,
                                        double expTilePixY)
        {
            var mapEntry = GwApi.GetMapFloor(continent, floor);
            var region = mapEntry.Regions.Values.Single(r => r.Maps.Values.Count(m => m.Id == mapid) == 1);
            var map = region.Maps.Values.Single(m => m.Id == mapid);
            var tilePixel = GwMapsHelper.WorldPosToTilePixel(map, new Gw2Point { X = worldX, Y = worldY }, zoom);
            Console.WriteLine(tilePixel);
            var expectedPoint = new Gw2Point { X = expTilePixX, Y = expTilePixY };
            Assert.AreEqual(expectedPoint, tilePixel);
        }

        [TestCase("Metrica Province", 1, 7, 16441.199999999983d, 25641.600000000035d, Result = "https://tiles.guildwars2.com/1/1/7/34/69.jpg")]
        public string GetTileUrlFromWorldPosTest1(string mapName, int floor, int zoomLevel, double worldX, double worldY)
        {
            var temp = GwApi.Network;
            GwApi.Network = new NetworkHandler();
            ResponseCache.Cache.Load("DynamicResponseCache.bin");
            var result = GwMapsHelper.GetTileUrlFromWorldPos(mapName, floor, zoomLevel, new Gw2Point { X = worldX, Y = worldY });
            ResponseCache.Cache.Save("DynamicResponseCache.bin");
            GwApi.Network = temp;
            return result;
        }

        [TestCase(35, 1, 7, 16441.199999999983d, 25641.600000000035d, Result = "https://tiles.guildwars2.com/1/1/7/34/69.jpg")]
        public string GetTileUrlFromWorldPosTest2(int mapId, int floor, int zoomLevel, double worldX, double worldY)
        {
            var temp = GwApi.Network;
            GwApi.Network = new NetworkHandler();
            ResponseCache.Cache.Load("DynamicResponseCache.bin");
            var result = GwMapsHelper.GetTileUrlFromWorldPos(mapId, floor, zoomLevel, new Gw2Point { X = worldX, Y = worldY });
            ResponseCache.Cache.Save("DynamicResponseCache.bin");
            GwApi.Network = temp;
            return result;
        }

    }

}

