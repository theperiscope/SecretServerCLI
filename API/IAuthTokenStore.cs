using System;

namespace SecretServerCLI.API
{
    public interface IAuthTokenStore
    {
        bool Store(GetAuthTokenResponse token, out Exception ex);
        GetAuthTokenResponse Load(out Exception ex);
    }
}