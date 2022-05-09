using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SecretServerCLI.API
{
    public class GetAuthTokenResponse
    {
        public GetAuthTokenResponse()
        {
            Timestamp = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Timestamp to track when token was returned so we can calculate expiration time
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("access_token")]
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
        
        [JsonProperty("token_type")]
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
        
        [JsonProperty("expires_in")]
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}