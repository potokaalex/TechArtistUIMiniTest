using System;
using ProjectCore.Scripts.Data;
using ProjectCore.Scripts.Data.Matching;

namespace ProjectCore.Scripts.Profile
{
    public class ProfileModel
    {
        public AccountData GetAccount()
        {
            return new AccountData
            {
                Name = "LooseCannon42",
                AvatarIcon = "Avatar01",
                Level = 48,
                Experience = 15432,
                ExperienceMax = 25000,

                Achievements = new[]
                {
                    new AchievementData
                    {
                        Name = "Fullmetal",
                        CompletedOn = new DateTime(2021, 07, 15),
                        Icon = "Icon58"
                    },
                    new AchievementData
                    {
                        Name = "Star Menace",
                        CompletedOn = new DateTime(2021, 08, 02),
                        Icon = "Icon24"
                    },
                    new AchievementData
                    {
                        Name = "Master of Elements",
                        CompletedOn = new DateTime(2021, 09, 25),
                        Icon = "Icon11"
                    },
                    new AchievementData
                    {
                        Name = "Cheers",
                        CompletedOn = new DateTime(2021, 10, 18),
                        Icon = "Icon58"
                    },
                    new AchievementData
                    {
                        Name = "King of the Hill",
                        CompletedOn = new DateTime(2021, 12, 12),
                        Icon = "Icon44"
                    }
                },

                Matches = new[]
                {
                    new MatchData
                    {
                        MatchType = MatchType.Unranked,
                        Icon = "IconUnranked",
                        Parameters = new[]
                        {
                            new MatchParameter
                            {
                                Header = "Accuracy",
                                SubHeader = "Counting accurate hits",
                                Score = 58
                            },
                            new MatchParameter
                            {
                                Header = "Kills",
                                SubHeader = "Counting your kills",
                                Score = 18
                            },
                            new MatchParameter
                            {
                                Header = "Deaths",
                                SubHeader = "Counting how many times you were killed",
                                Score = 6
                            }
                        },
                    },

                    new MatchData
                    {
                        MatchType = MatchType.Unranked,
                        Icon = "IconUnranked",
                        Parameters = new[]
                        {
                            new MatchParameter
                            {
                                Header = "Accuracy",
                                SubHeader = "Counting accurate hits",
                                Score = 85
                            },
                            new MatchParameter
                            {
                                Header = "Kills",
                                SubHeader = "Counting your kills",
                                Score = 27
                            },
                            new MatchParameter
                            {
                                Header = "Deaths",
                                SubHeader = "Counting how many times you were killed",
                                Score = 2
                            }
                        },
                    },

                    new MatchData
                    {
                        MatchType = MatchType.Unranked,
                        Icon = "IconUnranked",
                        Parameters = new[]
                        {
                            new MatchParameter
                            {
                                Header = "Accuracy",
                                SubHeader = "Counting accurate hits",
                                Score = 26
                            },
                            new MatchParameter
                            {
                                Header = "Kills",
                                SubHeader = "Counting your kills",
                                Score = 6
                            },
                            new MatchParameter
                            {
                                Header = "Deaths",
                                SubHeader = "Counting how many times you were killed",
                                Score = 11
                            }
                        },
                    }
                }
            };
        }
    }
}