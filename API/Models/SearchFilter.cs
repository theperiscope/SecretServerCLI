using Newtonsoft.Json;

namespace SecretServerCLI.API.Models
{
    public class SearchFilter
    {
        [JsonProperty("searchText")]
        public string SearchText { get; set; }

        [JsonProperty("searchField")]
        public object SearchField { get; set; }

        [JsonProperty("searchFieldSlug")]
        public object SearchFieldSlug { get; set; }

        [JsonProperty("includeInactive")]
        public bool IncludeInactive { get; set; }

        [JsonProperty("includeActive")]
        public object IncludeActive { get; set; }

        [JsonProperty("includeRestricted")]
        public bool IncludeRestricted { get; set; }

        [JsonProperty("secretTemplateId")]
        public int? SecretTemplateId { get; set; }

        [JsonProperty("folderId")]
        public int? FolderId { get; set; }

        [JsonProperty("includeSubFolders")]
        public bool IncludeSubFolders { get; set; }

        [JsonProperty("heartbeatStatus")]
        public object HeartbeatStatus { get; set; }

        [JsonProperty("siteId")]
        public int? SiteId { get; set; }

        [JsonProperty("scope")]
        public object Scope { get; set; }

        [JsonProperty("recentMinDateTime")]
        public object RecentMinDateTime { get; set; }

        [JsonProperty("recentMaxDateTime")]
        public object RecentMaxDateTime { get; set; }

        [JsonProperty("onlySharedWithMe")]
        public object OnlySharedWithMe { get; set; }

        [JsonProperty("extendedFields")]
        public object ExtendedFields { get; set; }

        [JsonProperty("permissionRequired")]
        public object PermissionRequired { get; set; }

        [JsonProperty("extendedTypeId")]
        public object ExtendedTypeId { get; set; }

        [JsonProperty("passwordTypeIds")]
        public object PasswordTypeIds { get; set; }

        [JsonProperty("onlyRPCEnabled")]
        public object OnlyRPCEnabled { get; set; }

        [JsonProperty("doubleLockId")]
        public object DoubleLockId { get; set; }

        [JsonProperty("isExactMatch")]
        public object IsExactMatch { get; set; }

        [JsonProperty("allowDoubleLocks")]
        public object AllowDoubleLocks { get; set; }

        [JsonProperty("doNotCalculateTotal")]
        public object DoNotCalculateTotal { get; set; }
    }
}