using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace graph_v1.Helpers
{
    public class GraphServiceClientHelper
    {
        public static IAuthenticationProvider CreateAuthorizationProvider(IConfigurationRoot config)
        {
            var clientId = config["ClientId"];
            var clientSecret = config["ClientSecret"];
            var redirectUri = config["RedirectUri"];
            var authorityUrl = config["AuthorityUrl"];

            var scopes = new List<string>();
            scopes.Add("user.read");
            scopes.Add("calendars.read");
            scopes.Add("calendars.readwrite");
            scopes.Add("tasks.read");
            scopes.Add("tasks.readwrite");
        }
    }
}
