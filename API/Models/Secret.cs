using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SecretServerCLI.API.Models
{
    public class Secret
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("secretTemplateId")]
        public int SecretTemplateId { get; set; }

        [JsonProperty("folderId")]
        public int FolderId { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("items")]
        public List<SecretItem> Items { get; set; }

        [JsonProperty("launcherConnectAsSecretId")]
        public int LauncherConnectAsSecretId { get; set; }

        [JsonProperty("checkOutMinutesRemaining")]
        public int CheckOutMinutesRemaining { get; set; }

        [JsonProperty("checkedOut")]
        public bool CheckedOut { get; set; }

        [JsonProperty("checkOutUserDisplayName")]
        public string CheckOutUserDisplayName { get; set; }

        [JsonProperty("checkOutUserId")]
        public int CheckOutUserId { get; set; }

        [JsonProperty("isRestricted")]
        public bool IsRestricted { get; set; }

        [JsonProperty("isOutOfSync")]
        public bool IsOutOfSync { get; set; }

        [JsonProperty("outOfSyncReason")]
        public string OutOfSyncReason { get; set; }

        [JsonProperty("autoChangeEnabled")]
        public bool AutoChangeEnabled { get; set; }

        [JsonProperty("autoChangeNextPassword")]
        public string AutoChangeNextPassword { get; set; }

        [JsonProperty("requiresApprovalForAccess")]
        public bool RequiresApprovalForAccess { get; set; }

        [JsonProperty("requiresComment")]
        public bool RequiresComment { get; set; }

        [JsonProperty("checkOutEnabled")]
        public bool CheckOutEnabled { get; set; }

        [JsonProperty("checkOutIntervalMinutes")]
        public int CheckOutIntervalMinutes { get; set; }

        [JsonProperty("checkOutChangePasswordEnabled")]
        public bool CheckOutChangePasswordEnabled { get; set; }

        [JsonProperty("accessRequestWorkflowMapId")]
        public int AccessRequestWorkflowMapId { get; set; }

        [JsonProperty("proxyEnabled")]
        public bool ProxyEnabled { get; set; }

        [JsonProperty("sessionRecordingEnabled")]
        public bool SessionRecordingEnabled { get; set; }

        [JsonProperty("restrictSshCommands")]
        public bool RestrictSshCommands { get; set; }

        [JsonProperty("allowOwnersUnrestrictedSshCommands")]
        public bool AllowOwnersUnrestrictedSshCommands { get; set; }

        [JsonProperty("isDoubleLock")]
        public bool IsDoubleLock { get; set; }

        [JsonProperty("doubleLockId")]
        public int DoubleLockId { get; set; }

        [JsonProperty("enableInheritPermissions")]
        public bool EnableInheritPermissions { get; set; }

        [JsonProperty("passwordTypeWebScriptId")]
        public int PasswordTypeWebScriptId { get; set; }

        [JsonProperty("siteId")]
        public int SiteId { get; set; }

        [JsonProperty("enableInheritSecretPolicy")]
        public bool EnableInheritSecretPolicy { get; set; }

        [JsonProperty("secretPolicyId")]
        public int SecretPolicyId { get; set; }

        [JsonProperty("lastHeartBeatStatus")]
        public string LastHeartBeatStatus { get; set; }

        [JsonProperty("lastHeartBeatCheck")]
        public DateTime LastHeartBeatCheck { get; set; }

        [JsonProperty("failedPasswordChangeAttempts")]
        public int FailedPasswordChangeAttempts { get; set; }

        [JsonProperty("lastPasswordChangeAttempt")]
        public DateTime LastPasswordChangeAttempt { get; set; }

        [JsonProperty("secretTemplateName")]
        public string SecretTemplateName { get; set; }

        [JsonProperty("responseCodes")]
        public List<object> ResponseCodes { get; set; }

        [JsonProperty("webLauncherRequiresIncognitoMode")]
        public bool WebLauncherRequiresIncognitoMode { get; set; }
    }
}