using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.Gw2Stats.ResponseObjects;
using GwApiNET.ResponseObjects;

namespace GwApiNETTest.Gw2StatsTest
{

    public static class TestData
    {
        #region Expected Values
        public static Gw2StatsMatchEntry MatchEntryExpected = new Gw2StatsMatchEntry
        {
            RetriveTime = DateTime.Parse("2013-07-27 19:53:53"),
            Region = new EntryDictionary<string, IList<MatchRegion>>
                    {
                        {
                            "na", new List<MatchRegion>
                                {
                                    new MatchRegion
                                        {

                                            StartDate = DateTime.Parse("2013-07-27 01:00:00"),
                                            EndDate = DateTime.Parse("2013-08-03 01:00:00"),
                                            LastUpdate = DateTime.Parse("2013-07-27 19:53:18"),
                                            MatchId = "1-8",
                                            UniqueId = new Guid("cb6a06d46962b5f05b059126bd178e78"),
                                            Worlds = new Dictionary<int, MatchWorld>
                                                {
                                                    {
                                                        1024,
                                                        new MatchWorld
                                                            {
                                                                Id = 1024,
                                                                Name = "Eredon Terrace",
                                                                Color =  OwnerColor.Red,
                                                                Score = 17709,
                                                                PPT = 215,
                                                                Objectives = new MatchObjectives
                                                                    {
                                                                        Camps = 9,
                                                                        Towers = 7,
                                                                        Keeps = 4,
                                                                        Castles = 0
                                                                    },
                                                                Rating = new Gw2StatsRatingsData
                                                                    {
                                                                        StartRank = 24,
                                                                        CurrentRank = 23,
                                                                        StartRating = 972.9781,
                                                                        StartDeviation = 172.66,
                                                                        CurrentDeviation = 173.53140625056,
                                                                        Volatility = 0.7139,
                                                                        CurrentRating = 997.37440857386,
                                                                        Evolution = 24.39630857386
                                                                    }
                                                            }
                                                    },
                                                },
                                        }
                                }
                        },
                        {
                            "eu", new List<MatchRegion>
                                {
                                    new MatchRegion
                                        {
                                            StartDate = DateTime.Parse("2013-07-26 18:00:00"),
                                            EndDate = DateTime.Parse("2013-08-02 18:00:00"),
                                            LastUpdate = DateTime.Parse("2013-07-27 19:53:46"),
                                            MatchId = "2-1",
                                            UniqueId = new Guid("69bb8feec3ccc63da2849aac4b670eb7"),
                                            Worlds = new Dictionary<int, MatchWorld>
                                                {
                                                    {
                                                        2104,
                                                        new MatchWorld
                                                            {
                                                                Id = 2104,
                                                                Name = "Vizunah Square [FR]",
                                                                Color =  OwnerColor.Red,
                                                                Score = 41959,
                                                                PPT = 225,
                                                                Objectives = new MatchObjectives
                                                                    {
                                                                        Camps = 9,
                                                                        Towers = 8,
                                                                        Keeps = 4,
                                                                        Castles = 0
                                                                    },
                                                                Rating = new Gw2StatsRatingsData
                                                                    {
                                                                        StartRank = 1,
                                                                        CurrentRank = 1,
                                                                        StartRating = 1981.7072,
                                                                        StartDeviation = 177.0751,
                                                                        CurrentDeviation = 170.62313431175,
                                                                        Volatility = 0.7243,
                                                                        CurrentRating = 1995.7396155154,
                                                                        Evolution = 14.0324155154
                                                                    }
                                                            }
                                                    }
                                                }
                                        }
                                }
                        }
                    }
        };
        public static Gw2StatsRatingsObject RatingsObjectExpected = new Gw2StatsRatingsObject
            {

                RetrieveTime = DateTime.Parse("2013-07-27 19:53:53"),
                Results = 4,
                Ratings = new Dictionary<string, IDictionary<int, Gw2StatsRatingsEntry>>
                    {
                        {
                            "na", new Dictionary<int, Gw2StatsRatingsEntry>
                                {
                                    {
                                        1019, new Gw2StatsRatingsEntry
                                            {
                                                WorldId = 1019,
                                                WorldName = "Blackgate",
                                                Data = new Gw2StatsRatingsData
                                                    {
                                                        StartRank = 1,
                                                        CurrentRank = 1,
                                                        StartRating = 2208.5315,
                                                        StartDeviation = 171.2073,
                                                        CurrentDeviation = 168.85605139766,
                                                        Volatility = 0.6975,
                                                        CurrentRating = 2158.3811412503,
                                                        Evolution = -50.1503587497
                                                    }
                                            }
                                    },
                                    {
                                        1001, new Gw2StatsRatingsEntry
                                            {
                                                WorldId = 1001,
                                                WorldName = "Anvil Rock",
                                                Data = new Gw2StatsRatingsData
                                                    {
                                                        StartRank = 23,
                                                        CurrentRank = 24,
                                                        StartRating = 1022.4628,
                                                        StartDeviation = 171.1844,
                                                        CurrentDeviation = 168.01317878663,
                                                        Volatility = 0.7129,
                                                        CurrentRating = 975.10682355753,
                                                        Evolution = -47.35597644247
                                                    }
                                            }
                                    }
                                }
                        },
                        {
                            "eu", new Dictionary<int, Gw2StatsRatingsEntry>
                                {
                                    {
                                        2104, new Gw2StatsRatingsEntry
                                            {
                                                WorldId = 2104,
                                                WorldName = "Vizunah Square [FR]",
                                                Data = new Gw2StatsRatingsData
                                                    {
                                                        StartRank = 1,
                                                        CurrentRank = 1,
                                                        StartRating = 1981.7072,
                                                        StartDeviation = 177.0751,
                                                        CurrentDeviation = 170.62313431175,
                                                        Volatility = 0.7243,
                                                        CurrentRating = 1995.7396155154,
                                                        Evolution = 14.0324155154
                                                    }
                                            }
                                    },
                                    {
                                        2011, new Gw2StatsRatingsEntry
                                            {
                                                WorldId = 2011,
                                                WorldName = "Vabbi",
                                                Data = new Gw2StatsRatingsData
                                                    {
                                                        StartRank = 27,
                                                        CurrentRank = 27,
                                                        StartRating = 544.2875,
                                                        StartDeviation = 217.5728,
                                                        CurrentDeviation = 213.39244244944,
                                                        Volatility = 0.7939,
                                                        CurrentRating = 587.1146264132,
                                                        Evolution = 42.8271264132
                                                    }
                                            }
                                    }
                                }
                        },
                    },
            };

        public static EntryDictionary<Gw2StatsObjectives.ObjectiveType, Gw2StatsObjectives> ObjectivesExpected = new EntryDictionary
            <Gw2StatsObjectives.ObjectiveType, Gw2StatsObjectives>
            {
                {
                    Gw2StatsObjectives.ObjectiveType.Match, new Gw2StatsObjectives
                        {
                            RetriveTime = DateTime.Parse("2013-08-01 09:11:12"),
                            Type = Gw2StatsObjectives.ObjectiveType.Match,
                            Matches = new Dictionary<string, Gw2StatsMatch>
                                {
                                    {
                                        "1-1", new Gw2StatsMatch
                                            {
                                                MatchId = "1-1",
                                                Maps = new Dictionary<int, Gw2StatsMap>
                                                    {
                                                        {
                                                            0, new Gw2StatsMap
                                                                {
                                                                    MapId = 0,
                                                                    MapOwnerId = 1017,
                                                                    MapOwnerName = "Tarnished Coast",
                                                                    Name = "Red Borderlands",
                                                                    Objectives =
                                                                        new EntryDictionary<int, Gw2StatsMapObjective>
                                                                            {
                                                                                {
                                                                                    32, new Gw2StatsMapObjective
                                                                                        {
                                                                                            Id = 32,
                                                                                            Name = "Etheron Hills",
                                                                                            Cardinal = "Hills",
                                                                                            Points = 25,
                                                                                            CaptureTime =
                                                                                                DateTime.Parse(
                                                                                                    "2013-07-31 13:18:06"),
                                                                                            TimeHeld =
                                                                                                TimeSpan.Parse(
                                                                                                    @"0:19:53:06"),
                                                                                            CurrentOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 1013,
                                                                                                        Name =
                                                                                                            "Sanctum of Rall",
                                                                                                        Color =
                                                                                                            OwnerColor
                                                                                                                .Blue,
                                                                                                    },
                                                                                            PreviousOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 1019,
                                                                                                        Name =
                                                                                                            "Blackgate"
                                                                                                    },
                                                                                            CurrentGuild =
                                                                                                new Gw2StatsCurrentGuild
                                                                                                    {
                                                                                                        Id = new Guid(),
                                                                                                    },
                                                                                        }
                                                                                } //
                                                                            }
                                                                } //
                                                        }
                                                    }
                                            }
                                    }
                                }
                        }
                },
                {
                    Gw2StatsObjectives.ObjectiveType.World, new Gw2StatsObjectives
                        {
                            RetriveTime = DateTime.Parse("2013-08-01 09:24:55"),
                            Type = Gw2StatsObjectives.ObjectiveType.World,
                            Matches = new Dictionary<string, Gw2StatsMatch>
                                {
                                    {
                                        "1-1", new Gw2StatsMatch
                                            {
                                                MatchId = "1-1",
                                                Maps = new Dictionary<int, Gw2StatsMap>
                                                    {
                                                        {
                                                            0, new Gw2StatsMap
                                                                {
                                                                    MapId = 2,
                                                                    MapOwnerId = 1019,
                                                                    MapOwnerName = "Blackgate",
                                                                    Name = "Green Borderlands",
                                                                    Objectives =
                                                                        new EntryDictionary<int, Gw2StatsMapObjective>
                                                                            {
                                                                                {
                                                                                    41, new Gw2StatsMapObjective
                                                                                        {
                                                                                            Id = 41,
                                                                                            Name = "Shadaran Hills",
                                                                                            Points = 25,
                                                                                            CaptureTime =
                                                                                                DateTime.Parse(
                                                                                                    "2013-08-01 07:19:26"),
                                                                                            TimeHeld =
                                                                                                TimeSpan.Parse(
                                                                                                    @"0:02:05:29"),
                                                                                            CurrentOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 1019,
                                                                                                        Name =
                                                                                                            "Blackgate",
                                                                                                    },
                                                                                            PreviousOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 1013,
                                                                                                        Name =
                                                                                                            "Sanctum of Rall"
                                                                                                    },
                                                                                            CurrentGuild =
                                                                                                new Gw2StatsCurrentGuild
                                                                                                    {
                                                                                                        Id = new Guid(),
                                                                                                    },
                                                                                        }
                                                                                } //
                                                                            }
                                                                } //
                                                        }
                                                    }
                                            }
                                    }
                                }
                        }
                },
                {
                    Gw2StatsObjectives.ObjectiveType.All, new Gw2StatsObjectives
                        {
                            Type = Gw2StatsObjectives.ObjectiveType.All,
                            RetriveTime = DateTime.Parse("2013-08-03 06:46:15"),
                            Matches = new Dictionary<string, Gw2StatsMatch>
                                {
                                    {
                                        "1-1", new Gw2StatsMatch
                                            {
                                                MatchId = "1-1",
                                                Maps = new Dictionary<int, Gw2StatsMap>
                                                    {
                                                        {
                                                            0, new Gw2StatsMap
                                                                {
                                                                    Name = "Red Borderlands",
                                                                    MapId = 0,
                                                                    Objectives =
                                                                        new EntryDictionary<int, Gw2StatsMapObjective>
                                                                            {
                                                                                {
                                                                                    32, new Gw2StatsMapObjective
                                                                                        {
                                                                                            Id = 32,
                                                                                            Name = "Etheron Hills",
                                                                                            Points = 25,
                                                                                            CaptureTime =
                                                                                                DateTime.Parse(
                                                                                                    "2013-08-03 06:34:24"),
                                                                                            TimeHeld =
                                                                                                TimeSpan.Parse(
                                                                                                    "0:00:11:51"),
                                                                                            CurrentGuild =
                                                                                                new Gw2StatsCurrentGuild
                                                                                                    {
                                                                                                        Id =
                                                                                                            new Guid(
                                                                                                                "5830D2B2-3886-46EA-A516-861A5C9382D0"),
                                                                                                        Name =
                                                                                                            "Nocturnal [NOC]",
                                                                                                        ImageUrl =
                                                                                                            "http://gw2stats.net/emb/img/cache/5830D2B2-3886-46EA-A516-861A5C9382D0_256.png",
                                                                                                    },
                                                                                            CurrentOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 1019,
                                                                                                        Name =
                                                                                                            "Blackgate",
                                                                                                    },
                                                                                            PreviousOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 1017,
                                                                                                        Name =
                                                                                                            "Tarnished Coast",
                                                                                                    }
                                                                                        }
                                                                                },
                                                                                {
                                                                                    53, new Gw2StatsMapObjective
                                                                                        {
                                                                                            Id = 53,
                                                                                            Name = "Greenvale Refuge",
                                                                                            Points = 5,
                                                                                            CaptureTime =
                                                                                                DateTime.Parse(
                                                                                                    "2013-08-03 06:08:00"),
                                                                                            TimeHeld =
                                                                                                TimeSpan.Parse(
                                                                                                    "0:00:38:15"),
                                                                                            CurrentGuild =
                                                                                                new Gw2StatsCurrentGuild
                                                                                                    {
                                                                                                        Id =
                                                                                                            new Guid(
                                                                                                                "B8BBD9A1-CB34-4BAF-8AB4-FD5B56282BAC"),
                                                                                                        Name = " []",
                                                                                                        ImageUrl =
                                                                                                            "http://gw2stats.net/emb/img/cache/B8BBD9A1-CB34-4BAF-8AB4-FD5B56282BAC_256.png",
                                                                                                    },
                                                                                            CurrentOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 1013,
                                                                                                        Name =
                                                                                                            "Sanctum of Rall",
                                                                                                    },
                                                                                            PreviousOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 1017,
                                                                                                        Name =
                                                                                                            "Tarnished Coast",
                                                                                                    }
                                                                                        }
                                                                                }
                                                                            }
                                                                }
                                                        }
                                                    }
                                            }
                                    },
                                    {
                                        "2-9", new Gw2StatsMatch
                                            {

                                                MatchId = "2-9",
                                                Maps = new Dictionary<int, Gw2StatsMap>
                                                    {
                                                        {
                                                            0, new Gw2StatsMap
                                                                {
                                                                    Name = "Red Borderlands",
                                                                    MapId = 0,
                                                                    Objectives =
                                                                        new EntryDictionary<int, Gw2StatsMapObjective>
                                                                            {
                                                                                {
                                                                                    52, new Gw2StatsMapObjective()
                                                                                        {
                                                                                            Id = 52,
                                                                                            Name = "Arah's Hope",
                                                                                            Points = 5,
                                                                                            CaptureTime =
                                                                                                DateTime.Parse(
                                                                                                    "2013-08-03 06:10:39"),
                                                                                            TimeHeld =
                                                                                                TimeSpan.Parse(
                                                                                                    "0:00:35:37"),
                                                                                            CurrentOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 2001,
                                                                                                        Name =
                                                                                                            "Fissure of Woe",
                                                                                                    },
                                                                                            PreviousOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 2011,
                                                                                                        Name = "Vabbi",
                                                                                                    }
                                                                                        }
                                                                                },
                                                                                {
                                                                                    53, new Gw2StatsMapObjective()
                                                                                        {
                                                                                            Id = 53,
                                                                                            Name = "Greenvale Refuge",
                                                                                            Points = 5,

                                                                                            CaptureTime =
                                                                                                DateTime.Parse(
                                                                                                    "2013-08-03 05:59:52"),
                                                                                            TimeHeld =
                                                                                                TimeSpan.Parse(
                                                                                                    "0:00:46:24"),

                                                                                            CurrentOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 2001,
                                                                                                        Name =
                                                                                                            "Fissure of Woe",
                                                                                                    },
                                                                                            PreviousOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 2011,
                                                                                                        Name = "Vabbi",
                                                                                                    }
                                                                                        }
                                                                                }
                                                                            },
                                                                }
                                                        },
                                                        {
                                                            3, new Gw2StatsMap
                                                                {
                                                                    Name = "Eternal Battlegrounds",
                                                                    MapId = 3,
                                                                    Objectives =
                                                                        new EntryDictionary<int, Gw2StatsMapObjective>
                                                                            {
                                                                                {
                                                                                    1, new Gw2StatsMapObjective()
                                                                                        {
                                                                                            Id = 1,
                                                                                            Name = "Overlook",
                                                                                            Points = 25,
                                                                                            CaptureTime =
                                                                                                DateTime.Parse(
                                                                                                    "2013-08-02 23:21:16"),
                                                                                            TimeHeld =
                                                                                                TimeSpan.Parse(
                                                                                                    "0:07:25:00"),
                                                                                            CurrentOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 2001,
                                                                                                        Name =
                                                                                                            "Fissure of Woe",
                                                                                                    },
                                                                                            PreviousOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 2008,
                                                                                                        Name =
                                                                                                            "Whiteside Ridge",
                                                                                                    }
                                                                                        }
                                                                                },
                                                                                {
                                                                                    22, new Gw2StatsMapObjective()
                                                                                        {
                                                                                            Id = 22,
                                                                                            Name = "Bravost Escarpment",
                                                                                            Points = 10,
                                                                                            CaptureTime =
                                                                                                DateTime.Parse(
                                                                                                    "2013-08-02 23:11:08"),
                                                                                            TimeHeld =
                                                                                                TimeSpan.Parse(
                                                                                                    "0:07:35:08"),
                                                                                            CurrentOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 2001,
                                                                                                        Name =
                                                                                                            "Fissure of Woe",
                                                                                                    },
                                                                                            PreviousOwner =
                                                                                                new Gw2StatsMapObjective
                                                                                                    .Gw2StatsOwner
                                                                                                    {
                                                                                                        WorldId = 2008,
                                                                                                        Name =
                                                                                                            "Whiteside Ridge",
                                                                                                    }
                                                                                        }
                                                                                }
                                                                            }
                                                                }
                                                        }
                                                    }
                                            }
                                    }
                                }
                        }
                },
            };

        public static EntryDictionary<string, Gw2StatsStatusEntry> StatusEntriesExpected = new EntryDictionary
            <string, Gw2StatsStatusEntry>
            {
                {
                    @"http://gw2stats.net/api/matches.json",
                    new Gw2StatsStatusEntry
                        {
                            Id = @"http://gw2stats.net/api/matches.json",
                            Url = "http://gw2stats.net/api/matches.json",
                            Status = ApiStatus.OK,
                            Ping = 1,
                            Retrieve = 169,
                            Records = 888,
                            Time = DateTime.Parse("2013-07-26 18:38:38"),
                        }
                },
                {
                    @"http://gw2stats.net/api/objectives.json",
                    new Gw2StatsStatusEntry
                        {
                            Id = @"http://gw2stats.net/api/objectives.json",
                            Url = "http://gw2stats.net/api/objectives.json",
                            Status = ApiStatus.OK,
                            Ping = 0,
                            Retrieve = 85,
                            Records = 879,
                            Time = DateTime.Parse("2013-07-26 18:38:38"),
                        }
                }
            };

        public static EntryDictionary<string, string> StatusCodesExpected = new EntryDictionary<string, string>
            {
                {"OK", "No error was received : Completed successfully"},
                {"UNREACHABLE", "The host was unreachable : host may be down"},
                {"DOWN", "Host was reachable but API returned error : API may be down"},
                {"PARTIAL", "Only partial data was received"},
                {"INCREASING PING", "Ping to the API host has increased 100ms from last update"},
                {"HIGH PING", "Ping to the API host has reached a minimum of 750ms"},
                {"SLOW RETRIEVE", "API host and API are up : Data retrieval is over 3 seconds"}
            };

        #endregion Expected Values
    }
}
