using Newtonsoft.Json;
using Refit;
using SecretServerCLI.Spectre;
using Spectre.Console.Cli;

namespace SecretServerCLI.API.Models
{
    public class FoldersFilter : SharedSpectreCommandSettings
    {
        [JsonProperty("searchText")]
        [AliasAs("filter.searchtext")]
        [CommandOption("--searchText")]
        public string SearchText { get; set; }

        [JsonProperty("folderTypeId")]
        [AliasAs("filter.folderTypeId")]
        [CommandOption("--folderTypeId")]
        public int? FolderTypeId { get; set; }

        [JsonProperty("parentFolderId")]
        [AliasAs("filter.parentFolderId")]
        [CommandOption("--parentFolderId")]
        public int? ParentFolderId { get; set; }

        [JsonProperty("permissionRequired")]
        [AliasAs("filter.permissionRequired")]
        [CommandOption("--permissionRequired")]
        public bool? PermissionRequired { get; set; }
    }
}