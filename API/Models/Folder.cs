using Newtonsoft.Json;

namespace SecretServerCLI.API.Models
{
    public class Folder
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("folderName")]
        public string FolderName { get; set; }

        [JsonProperty("folderPath")]
        public string FolderPath { get; set; }

        [JsonProperty("parentFolderId")]
        public int ParentFolderId { get; set; }

        [JsonProperty("folderTypeId")]
        public int FolderTypeId { get; set; }

        [JsonProperty("secretPolicyId")]
        public int SecretPolicyId { get; set; }

        [JsonProperty("inheritSecretPolicy")]
        public bool InheritSecretPolicy { get; set; }

        [JsonProperty("inheritPermissions")]
        public bool InheritPermissions { get; set; }

        [JsonProperty("childFolders")]
        public object ChildFolders { get; set; }

        [JsonProperty("secretTemplates")]
        public object SecretTemplates { get; set; }
    }
}