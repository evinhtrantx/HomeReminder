namespace Reminder
{
    public class Utilities
    {
        public static string ConvertConfigToJson(IList<Config> configs)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(configs);
        }
    }
}
