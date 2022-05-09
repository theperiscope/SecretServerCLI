using System;
using System.Threading.Tasks;

namespace SecretServerCLI.API
{
    public class SecretServerCachedOAuthTokenProvider : IAuthTokenProvider
    {
        public ISecretServerOAuthAPI API { get; }
        public IAuthTokenStore Store { get; }
        public IAuthTokenService Service { get; }
        public ICredentialsProvider<UsernamePasswordOTPCredentials> CredentialsProvider { get; }

        public SecretServerCachedOAuthTokenProvider(ISecretServerOAuthAPI api, IAuthTokenStore store, IAuthTokenService service, ICredentialsProvider<UsernamePasswordOTPCredentials> credentialsProvider)
        {
            API = api ?? throw new ArgumentNullException(nameof(api));
            Store = store ?? throw new ArgumentNullException(nameof(store));
            Service = service ?? throw new ArgumentNullException(nameof(service));
            CredentialsProvider = credentialsProvider ?? throw new ArgumentNullException(nameof(credentialsProvider));
        }

        public async Task<Tuple<GetAuthTokenResponse, Exception>> GetToken(bool isReset)
        {
            if (!isReset)
            {
                var token = Store.Load(out var ex1);
                if (ex1 != null)
                {
                    return new (null, ex1);
                }

                if (Service.IsValid(token)) return new Tuple<GetAuthTokenResponse, Exception>(token, null);
            }

            try
            {
                var credentials = CredentialsProvider.GetCredentials();
                var newToken = await API.GetAuthToken(new GetAuthTokenRequest { Username = credentials.Username, Password = credentials.Password }, credentials.OTP);

                Store.Store(newToken, out var ex2);
                if (ex2 != null)
                {
                    return new (null, ex2);
                }

                return new (newToken, null);
            }
            catch (Exception ex3)
            {
                return new (null, ex3);
            }
        }
    }
}