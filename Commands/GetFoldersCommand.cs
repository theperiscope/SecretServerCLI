using System;
using System.Linq;
using System.Threading.Tasks;
using SecretServerCLI.API;
using SecretServerCLI.API.Models;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SecretServerCLI.Commands
{
    public class GetFoldersCommand : AsyncCommand<GetFoldersCommand.Settings>
    {
        private readonly ISecretServerSecretAPI api;

        public GetFoldersCommand(ISecretServerSecretAPI api)
        {
            this.api = api ?? throw new ArgumentNullException(nameof(api));
        }

        public class Settings : FoldersFilter
        {
        }

        public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
        {
            var folders = await api.GetFolders(settings);
            if (folders == null) return 1;

            var root = new Tree("Folders").Guide(TreeGuide.Line);

            if (IsValidParentChildStructure(folders, -1))
            {
                AddChildren(root, null, folders, -1);
            }
            else
            {
                foreach (var folder in folders.Records.OrderBy(x => x.FolderName))
                {
                    root.AddNode(new Markup($"{folder.Id}: {folder.FolderName}"));
                }

            }
            AnsiConsole.Write(root);

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