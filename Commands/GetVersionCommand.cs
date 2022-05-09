using System;
using System.Linq;
using System.Threading.Tasks;
using SecretServerCLI.API;
using SecretServerCLI.API.Models;
using SecretServerCLI.Spectre;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SecretServerCLI.Commands
{
    public class GetVersionCommand : AsyncCommand<SharedSpectreCommandSettings>
    {
        private readonly ISecretServerSecretAPI api;

        public GetVersionCommand(ISecretServerSecretAPI api)
        {
            this.api = api ?? throw new ArgumentNullException(nameof(api));
        }

        public override async Task<int> ExecuteAsync(CommandContext context, SharedSpectreCommandSettings settings)
        {
            var versionResponse = await api.GetVersion();
            if (versionResponse == null) return 1;

            AnsiConsole.Write(versionResponse.Model.Version);

            return 0;
        }

        public bool IsValidParentChildStructure(ListOfFolders folders, int parentFolderId)
        {
            var result = true;
            if (folders.Records.All(x => x.Id != parentFolderId)) return false;

            foreach (var folder in folders.Records.Where(x => x.ParentFolderId == parentFolderId))
            {
                result = result && !IsValidParentChildStructure(folders, folder.Id);
            }

            return result;
        }

        public void AddChildren(Tree tree, TreeNode node, ListOfFolders folders, int parentFolderId)
        {
            foreach (var folder in folders.Records.Where(x => x.ParentFolderId == parentFolderId).OrderBy(x => x.FolderName))
            {
                if (node == null)
                {
                    var x = tree.AddNode(new Markup($"{folder.Id}: {folder.FolderName}"));
                    AddChildren(tree, x, folders, folder.Id);
                }
                else
                {
                    var x = node.AddNode(new Markup($"{folder.Id}: {folder.FolderName}"));
                    AddChildren(tree, x, folders, folder.Id);
                }
            }
        }
    }
}