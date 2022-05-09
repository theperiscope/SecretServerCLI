using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace SecretServerCLI.API
{
    public interface ISecretServerOAuthAPI
    {
        // Refit will expose the client via generated code so we can use it to change BaseAddress
        HttpClient Client { get; }

        [Post("/oauth2/token")]
        Task<GetAuthTokenResponse> GetAuthToken([Body(BodySerializationMethod.UrlEncoded)] GetAuthTokenRequest request, [Header("otp")] string otp);
    }
}