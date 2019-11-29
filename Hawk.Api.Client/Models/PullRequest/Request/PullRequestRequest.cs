using Hawk.Api.Client.Models.PullRequest.Request;
using System.Collections.Generic;

namespace Hawk.Api.Client.Library.Models.PullRequest.Request
{
    public class PullRequestRequest
    {
        public List<Organization> Organizations { get; set; } = new List<Organization>();
    }


}
