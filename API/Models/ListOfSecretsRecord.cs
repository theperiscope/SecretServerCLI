using System;
using Newtonsoft.Json;

namespace SecretServerCLI.API.Models
{
    public class ListOfSecretsRecord
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("secretTemplateId")]
        public int SecretTemplateId { get; set; }

        [JsonProperty("secretTemplateName")]
        public string SecretTemplateName { get; set; }

        [JsonProperty("folderId")]
        public int FolderId { get; set; }

        [JsonProperty("siteId")]
        public int SiteId { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("checkedOut")]
        public bool CheckedOut { get; set; }

        [JsonProperty("isRestricted")]
        public bool IsRestricted { get; set; }

        [JsonProperty("isOutOfSync")]
        public bool IsOutOfSync { get; set; }

        [JsonProperty("outOfSyncReason")]
        public string OutOfSyncReason { get; set; }

        [JsonProperty("lastHeartBeatStatus")]
        public string LastHeartBeatStatus { get; set; }

        [JsonProperty("lastPasswordChangeAttempt")]
        public DateTime LastPasswordChangeAttempt { get; set; }

        [JsonProperty("responseCodes")]
        public object ResponseCodes { get; set; }

        [JsonProperty("lastAccessed")]
        public DateTime? LastAccessed { get; set; }

        [JsonProperty("extendedFields")]
        public object ExtendedFields { get; set; }

        [JsonProperty("checkOutEnabled")]
        public bool CheckOutEnabled { get; set; }

        [JsonProperty("autoChangeEnabled")]
        public bool AutoChangeEnabled { get; set; }

        [JsonProperty("doubleLockEnabled")]
        public bool DoubleLockEnabled { get; set; }

        [JsonProperty("requiresApproval")]
        public bool RequiresApproval { get; set; }

        [JsonProperty("requiresComment")]
        public bool RequiresComment { get; set; }

        [JsonProperty("inheritsPermissions")]
        public bool InheritsPermissions { get; set; }

        [JsonProperty("hidePassword")]
        public bool HidePassword { get; set; }

        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("daysUntilExpiration")]
        public int DaysUntilExpiration { get; set; }
    }
}