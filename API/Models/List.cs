using System.Collections.Generic;
using Newtonsoft.Json;

namespace SecretServerCLI.API.Models
{
    public class List<TFilter, TRecord>
    {
        [JsonProperty("filter")]
        public TFilter Filter { get; set; }

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("take")]
        public int Take { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("batchCount")]
        public int BatchCount { get; set; }

        [JsonProperty("prevSkip")]
        public int PrevSkip { get; set; }

        [JsonProperty("nextSkip")]
        public int NextSkip { get; set; }

        [JsonProperty("hasPrev")]
        public bool HasPrev { get; set; }

        [JsonProperty("hasNext")]
        public bool HasNext { get; set; }

        [JsonProperty("records")]
        public List<TRecord> Records { get; set; }

        [JsonProperty("sortBy")]
        public List<object> SortBy { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("severity")]
        public string Severity { get; set; }

    }
}