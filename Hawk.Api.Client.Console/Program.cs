using Hawk.Api.Client.Library;
using Hawk.Api.Client.Library.Models.PullRequest.Request;
using Hawk.Api.Client.Models.PullRequest.Request;
using System;

namespace ClientConsoleTest
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            string orgName = Environment.GetEnvironmentVariable("HAWK_ORG_NAME");
            string accessToken = Environment.GetEnvironmentVariable("HAWK_ORG_TOKEN");



            var payload = new PullRequestRequest()
            {
                Organizations = { new Organization(orgName, accessToken) }
            };

            var response = await Hawk.Api.Client.Hawk.GetPullRequestsAsync(payload);


        }
    }
}
