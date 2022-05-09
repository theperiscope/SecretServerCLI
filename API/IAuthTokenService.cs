namespace SecretServerCLI.API
{
    public interface IAuthTokenService
    {
        bool IsValid(GetAuthTokenResponse token);
    }
}