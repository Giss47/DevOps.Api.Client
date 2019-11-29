﻿using Hawk.Api.Client.Library;
using Hawk.Api.Client.Library.Models.PullRequest.Request;
using Hawk.Api.Client.Library.Models.PullRequest.Response;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hawk.Api.Client
{
    public static class Hawk
    {
        static readonly IHttpClientFactory HttpClientFactory;
        static readonly Lazy<Settings> Settings;

        static Hawk()
        {
            var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
            HttpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            Settings = new Lazy<Settings>(() => new Settings());
        }

        private static HttpClient CreateClient(this Settings apiSettings)
        {
            if (apiSettings == null)
            {
                throw new ArgumentNullException(nameof(apiSettings));
            }
            if (string.IsNullOrWhiteSpace(apiSettings.ApiKey))
            {
                throw new ArgumentException("Apikey not correctly provided.");
            }
            var client = HttpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("x-functions-key", apiSettings.ApiKey);
            client.BaseAddress = new Uri($"{apiSettings.BaseUrl.TrimEnd('/')}/");

            return client;
        }

        public static async Task<PullRequestResponse> GetPullRequestsAsync(PullRequestRequest apiPayload, Settings settings = null)
        {        

            var apiPath = new Uri($"{Uri.EscapeDataString("getpullrequests")}", UriKind.Relative);

            var client = (settings ?? Settings.Value).CreateClient();

            using (var response = await client.PostAsJsonAsync(apiPath, apiPayload))
            {
                var pulls = await response.Content.ReadAsAsync<PullRequestResponse>();
                return pulls;
            }

        }
               
    }
}
