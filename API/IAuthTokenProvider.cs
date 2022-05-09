using System;
using System.Threading.Tasks;

namespace SecretServerCLI.API
{
    public interface IAuthTokenProvider
    {
        ISecretServerOAuthAPI API { get; }

        Task<Tuple<GetAuthTokenResponse, Exception>> GetToken(bool isReset);
    }
}