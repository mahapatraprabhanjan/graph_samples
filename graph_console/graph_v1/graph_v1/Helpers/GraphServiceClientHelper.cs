using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Net.Http;

namespace graph_v1.Helpers
{
    public class GraphServiceClientHelper
    {
        private static GraphServiceClient _graphServiceClient;
        private static HttpClient _httpClient;

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

            var cca = new ConfidentialClientApplication(clientId, redirectUri, new ClientCredential(clientSecret), null, null);
            return new MsalAuthenticationProvider(cca, scopes.ToArray());
        }

        public static GraphServiceClient GetGraphClient(IConfigurationRoot config)
        {
            var authenticationProvider = CreateAuthorizationProvider(config);
            _graphServiceClient = new GraphServiceClient(authenticationProvider);
            return _graphServiceClient;
        }

        public static HttpClient GetHttpClient(IConfigurationRoot config)
        {
            var authenticationProvider = CreateAuthorizationProvider(config);
            _httpClient = new HttpClient(new AuthenticationHandler(authenticationProvider, new HttpClientHandler()));
            return _httpClient;
        }
    }
}
