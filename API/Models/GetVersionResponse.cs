using System.Collections.Generic;
using Newtonsoft.Json;

namespace SecretServerCLI.API.Models
{
    public class GetVersionResponseModel
    {
        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class GetVersionResponse
    {
        [JsonProperty("model")]
        public GetVersionResponseModel Model { get; set; }

        [JsonProperty("exceptions")]
        public List<string> Exceptions { get; set; }

        [JsonProperty("messageText")]
        public string MessageText { get; set; }

        [JsonProperty("friendlyMessageText")]
        public string FriendlyMessageText { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("severity")]
        public string Severity { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }
    }
}
