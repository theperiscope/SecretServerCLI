using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace SecretServerCLI.API
{
    internal class AuthTokenInjectorDelegatingHandler : DelegatingHandler
    {
        private readonly IAuthTokenProvider authTokenProvider;

        public AuthTokenInjectorDelegatingHandler(IAuthTokenProvider authTokenProvider)
        {
            this.authTokenProvider = authTokenProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            (GetAuthTokenResponse token, Exception ex) = await authTokenProvider.GetToken(false);
            if (ex != null) throw ex;

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}