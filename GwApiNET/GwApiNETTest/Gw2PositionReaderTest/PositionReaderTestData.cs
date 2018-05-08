using GwApiNET;
using GwApiNET.Gw2PositionReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GwApiNETTest.Gw2PositionReaderTest
{
    public struct PlayerTest
    {
        public uint Version;
        public uint Tick;
        public Vector3 AvatarPosition;
        public Vector3 AvatarFront;
        public Vector3 AvatarTop;
        public string LinkName;
        public Vector3 CameraPosition;
        public Vector3 CameraFront;
        public Vector3 CameraTop;
        public string CharacterName;
        public Profession Profession;
        public TeamColor TeamColor;
        public bool IsCommander;
        public IPEndPoint ServerAddress;
        public uint MapId;
        public uint MapType;
        public uint WorldId;
        public uint Instance;
        public uint Build;
        public string Description;
    }

    public static class PositionReaderTestData
    {
        public static PlayerTest ExpectedPlayerData = new PlayerTest
        {
            Version = 2,
            Tick = 92586,
            AvatarPosition = new Vector3(4.9772196f, 0.5979926f, 22.493135f),
            AvatarFront = new Vector3(0.55687493f, 0f, 0.83059639f),
            AvatarTop = new Vector3(0f, 0f, 0f),
            LinkName = "Guild Wars 2",
            CameraPosition = new Vector3(-1.4365031e-002f, 4.0177932f, 14.960078f),
            CameraFront = new Vector3(0.53820795f, -0.22495101f, 0.8122372f),
            CameraTop = new Vector3(0, 0, 0),
            CharacterName = "My Name Here",
            Profession = Profession.Guardian,
            TeamColor = TeamColor.Blue,
            IsCommander = true,
            ServerAddress = Player.GetServerAddress(new byte[] { 2, 0, 0, 0, 64, 25, 33, 79, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }),
            MapId = 50,
            MapType = 5,
            WorldId = 1006,
            Instance = 0,
            Build = 22224,
            Description = "Test Description"
        };
    }
}
