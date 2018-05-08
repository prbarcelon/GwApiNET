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

    public class Temp
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Temp()
        {
        }

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
                                                                Objectives =
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
    }
}
 