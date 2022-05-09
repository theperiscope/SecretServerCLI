using System;
using System.Threading.Tasks;
using SecretServerCLI.API;
using SecretServerCLI.Framework;
using SecretServerCLI.Spectre;
using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Rendering;

namespace SecretServerCLI.Commands
{
    public class GetSecretCommand : AsyncCommand<GetSecretCommand.Settings>
    {
        private readonly ISecretServerSecretAPI api;

        public GetSecretCommand(ISecretServerSecretAPI api)
        {
            this.api = api ?? throw new ArgumentNullException(nameof(api));
        }
        public class Settings : SharedSpectreCommandSettings
        {
            [CommandArgument(0, "<secret Id>")]
            public int SecretId { get; set; }
        }

        public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
        {
            var secret = await api.GetSecret(settings.SecretId);
            if (secret == null) return 1;

            var folder = await api.GetFolder(secret.FolderId);
            if (folder == null) return 1;

            var tItems = new Table { Border = TableBorder.None };
            tItems.HideHeaders();
            tItems.AddColumn("Field");
            tItems.AddColumn("Value");
            tItems.Columns[0].PadLeft(0).PadRight(1);
            tItems.Columns[1].PadLeft(0).PadRight(0);

            foreach (var item in secret.Items)
            {
                tItems.AddRow(item.FieldName, $": {item.ItemValue}");
            }

            var t = new Table { Border = new DoubleEdgeTableBorder() };
            t.AddColumn("Id");
            t.AddColumn("Name");
            t.AddColumn("Folder");
            t.AddColumn("Template");
            t.AddColumn("Heartbeat");
            t.Columns[4].Centered();
            t.AddColumn("Active?");
            t.Columns[5].Centered();
            t.AddColumn("Items");
            t.ZeroPaddingForAllColumns();

            t.AddRow(new Text(secret.Id.ToString()), new Text(secret.Name), new Text(folder.FolderName), new Text(secret.SecretTemplateName), new Text($"{secret.LastHeartBeatStatus}\n{secret.LastHeartBeatCheck.TimeAgo()}"), new Markup($"[{(secret.Active ? "green" : "red")}]{secret.Active.ToString()}[/]"), tItems);

            AnsiConsole.Write(t);

            return 0;
        }
    }
}