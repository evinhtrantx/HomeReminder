﻿namespace Reminder
{
    public struct MessageByTime
    {
        public string messageText;
        public string Time;
    }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Config
    {
        public DateOnly[] SpecificDates { set; get; }
        public DayOfWeek[] DayOfWeeks { set; get; }
        public MessageByTime[] Messages { set; get; }

    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class PredefinedConfigLoader : IConfigLoader
    {
        public IList<Config> GetConfigs() {

            List<Config> result = new() {
                new Config()
                {
                    SpecificDates = Array.Empty<DateOnly>(),
                    DayOfWeeks = new DayOfWeek[]
                    {
                        DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday
                    },
                    Messages = new MessageByTime[]
                    {
                        new MessageByTime
                        {
                            messageText = "Cook Dinner",
                            Time = "17:20"
                        },
                        new MessageByTime
                        {
                            messageText = "Internet is going down soon",
                            Time = "22:20"
                        },
                        new MessageByTime
                        {
                            messageText = "Internet is going down soon",
                            Time = "22:40"
                        }
                    }
                },
                new Config()
                {
                    SpecificDates = Array.Empty<DateOnly>(),
                    DayOfWeeks = new DayOfWeek[]
                    {
                        DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday
                    },
                    Messages = new MessageByTime[]
                    {
                        new MessageByTime
                        {
                            messageText = "Fruit and Lunch box",
                            Time = "21:00"
                        }
                    }
                },
                new Config()
                {
                    SpecificDates = Array.Empty<DateOnly>(),
                    DayOfWeeks = new DayOfWeek[]
                    {
                        DayOfWeek.Sunday
                    },
                    Messages = new MessageByTime[]
                    {
                        new MessageByTime
                        {
                            messageText = "Lesson Done. Dinner Or Fruit",
                            Time = "21:05"
                        }
                    }
                }
            };
            
            return result;
        }

        public void LoadConfig()
        {
            throw new NotImplementedException();
        }
    }
}
