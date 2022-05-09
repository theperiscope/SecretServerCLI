using System;

namespace SecretServerCLI.API
{
    internal class AuthTokenService : IAuthTokenService
    {

        public bool IsValid(GetAuthTokenResponse token)
        {
            if (token == null) return false;
            if (token.ExpiresIn <= 0) return false;
            if (string.IsNullOrWhiteSpace(token.AccessToken)) return false;
            if (string.IsNullOrWhiteSpace(token.RefreshToken)) return false;
            if (token.Timestamp == DateTimeOffset.MinValue) return false;
            if (token.Timestamp.Add(TimeSpan.FromSeconds(token.ExpiresIn)) <= DateTimeOffset.UtcNow) return false;

            return true;
        }
    }
}