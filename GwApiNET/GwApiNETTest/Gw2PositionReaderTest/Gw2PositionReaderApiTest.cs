using System.Threading;
using GwApiNET.Gw2PositionReader;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using System.Runtime.InteropServices;

namespace GwApiNETTest.Gw2PositionReaderTest
{
    public class Gw2PositionReaderApiTest
    {
        [TestFixtureSetUp]
        public void PositionApiTestFixture()
        {
            actual = new Player();
            actual.OpenBinary(@"..\..\..\TestData\PositionReader\data.bin");
            expected = PositionReaderTestData.ExpectedPlayerData;
        }

        Player actual;
        PlayerTest expected;

        [TestCase]
        public void PositionApiAvatarFrontTest()
        {
            Assert.AreEqual(expected.AvatarFront.X, actual.AvatarFront.X);
            Assert.AreEqual(expected.AvatarFront.Y, actual.AvatarFront.Y);
            Assert.AreEqual(expected.AvatarFront.Z, actual.AvatarFront.Z);
            actual.Dispose();
        }

        [TestCase]
        public void PositionAPIAvatarPositionTest()
        {
            Assert.AreEqual(expected.AvatarPosition.X, actual.AvatarPosition.X);
            Assert.AreEqual(expected.AvatarPosition.Y, actual.AvatarPosition.Y);
            Assert.AreEqual(expected.AvatarPosition.Z, actual.AvatarPosition.Z);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiAvatarTopTest()
        {
            Assert.AreEqual(expected.AvatarTop.X, actual.AvatarTop.X);
            Assert.AreEqual(expected.AvatarTop.Y, actual.AvatarTop.Y);
            Assert.AreEqual(expected.AvatarTop.Z, actual.AvatarTop.Z);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiBuildTest()
        {
            Assert.AreEqual(expected.Build, actual.Build);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiCameraFrontTest()
        {
            Assert.AreEqual(expected.CameraFront.X, actual.CameraFront.X);
            Assert.AreEqual(expected.CameraFront.Y, actual.CameraFront.Y);
            Assert.AreEqual(expected.CameraFront.Z, actual.CameraFront.Z);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiCameraPositionTest()
        {
            Assert.AreEqual(expected.CameraPosition.X, actual.CameraPosition.X);
            Assert.AreEqual(expected.CameraPosition.Y, actual.CameraPosition.Y);
            Assert.AreEqual(expected.CameraPosition.Z, actual.CameraPosition.Z);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiCameraTopTest()
        {
            Assert.AreEqual(expected.CameraTop.X, actual.CameraTop.X);
            Assert.AreEqual(expected.CameraTop.Y, actual.CameraTop.Y);
            Assert.AreEqual(expected.CameraTop.Z, actual.CameraTop.Z);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiCharacterNameTest()
        {
            Assert.AreEqual(expected.CharacterName, actual.CharacterName);
            //Thread.Sleep(31000);
            Assert.AreEqual(expected.CharacterName, actual.CharacterName);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiDescriptionTest()
        {
            Assert.AreEqual(expected.Description, actual.Description);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiInstanceTest()
        {
            Assert.AreEqual(expected.Instance, actual.Instance);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiIsCommanderTest()
        {
            Assert.AreEqual(expected.IsCommander, actual.IsCommander);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiLinkNameTest()
        {
            Assert.AreEqual(expected.LinkName, actual.LinkName);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiMapIdTest()
        {
            Assert.AreEqual(expected.MapId, actual.MapId);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiMapTypeTest()
        {
            Assert.AreEqual(expected.MapType, actual.MapType);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiProfessionTest()
        {
            Assert.AreEqual(expected.Profession, actual.Profession);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiServerAddressTest()
        {
            Assert.AreEqual(expected.ServerAddress, actual.ServerAddress);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiTeamColorTest()
        {
            Assert.AreEqual(expected.TeamColor, actual.TeamColor);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiTickTest()
        {
            Assert.AreEqual(expected.Tick, actual.Tick);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiVersionTest()
        {
            Assert.AreEqual(expected.Version, actual.Version);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiWorldIdTest()
        {
            Assert.AreEqual(expected.WorldId, actual.WorldId);
            actual.Dispose();
        }

        [TestCase]
        public void PositionApiIdentityCacheMaxAgeTest()
        {
            Assert.AreEqual(actual.IdentityCacheMaxAge, 3);
            actual.IdentityCacheMaxAge = 5;
            Assert.AreEqual(actual.IdentityCacheMaxAge, 5);
            actual.Dispose();
        }
    }
}
