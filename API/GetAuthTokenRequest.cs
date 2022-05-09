using Refit;

namespace SecretServerCLI.API
{
    public class GetAuthTokenRequest
    {
        [AliasAs("username")]
        public string Username { get; set; }

        [AliasAs("password")]
        public string Password { get; set; }

        [AliasAs("grant_type")]
        public string GrantType => "password";
    }
}