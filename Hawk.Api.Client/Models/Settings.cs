using System;

namespace Hawk.Api.Client.Library
{
    public class Settings
    {
        public string BaseUrl { get; set; }

        public string ApiKey { get; set; }

        public Settings(string baseUrl = null, string apiKey = null)
        {
            BaseUrl = baseUrl ?? Environment.GetEnvironmentVariable("HAWK_API_BASE_URL") ?? throw new ArgumentNullException(nameof(baseUrl));
            ApiKey = apiKey ?? Environment.GetEnvironmentVariable("HAWK_API_KEY") ?? throw new ArgumentNullException(nameof(apiKey));
        }
    }
}
