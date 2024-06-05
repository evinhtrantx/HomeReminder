using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Reminder
{
    public class AwsConfigLoader : IConfigLoader
    {
        readonly HttpClient _httpClient;
        private IList<Config>? _configs;
        IList<Config> IConfigLoader.GetConfigs()
        {
            return _configs ?? new List<Config>();
        }

        void IConfigLoader.LoadConfig()
        {
            Task<HttpResponseMessage> thttpResponseMessage = _httpClient.GetAsync("https://4wkutquvec.execute-api.ap-southeast-2.amazonaws.com/Prod");
            thttpResponseMessage.Wait();
            HttpResponseMessage result = thttpResponseMessage.Result;
            Task<IList<Config>?> tConfig = result.Content.ReadFromJsonAsync<IList<Config>>();
            tConfig.Wait();
            _configs = tConfig.Result;
        }
        public AwsConfigLoader(in HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
    }
}
