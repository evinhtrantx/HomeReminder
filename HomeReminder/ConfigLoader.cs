namespace Reminder
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
    public class ConfigLoader
    {
        public static IList<Config> GetConfigs() {

            List<Config> result = new() {
                new Config()
                {
                    SpecificDates = Array.Empty<DateOnly>(),
                    DayOfWeeks = new DayOfWeek[]
                    {
                        DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday
                    },
                    Messages = new MessageByTime[]
                    {
                        new MessageByTime
                        {
                            messageText = "Cook Dinner",
                            Time = "17:15"
                        },
                        new MessageByTime
                        {
                            messageText = "Internet is going down soon",
                            Time = "23:40"
                        }
                    }
                }
            };
            
            return result;
        }
    }
}
