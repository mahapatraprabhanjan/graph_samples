using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace graph_v1.Helpers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly IAuthenticationProvider _authenticationProvider;

        protected AuthenticationHandler(IAuthenticationProvider authenticationProvider, HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            _authenticationProvider = authenticationProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await _authenticationProvider.AuthenticateRequestAsync(request);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
