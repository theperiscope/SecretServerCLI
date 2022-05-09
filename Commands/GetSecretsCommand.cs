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
    public class GetSecretsCommand : AsyncCommand<GetSecretsCommand.Settings>
    {
        private readonly ISecretServerSecretAPI api;

        public GetSecretsCommand(ISecretServerSecretAPI api)
        {
            this.api = api ?? throw new ArgumentNullException(nameof(api));
        }
        public class Settings : SharedSpectreCommandSettings
        {
            [CommandArgument(0, "[search text]")]
            public string SearchText { get; set; }
        }

        public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
        {
            var secrets = await api.GetSecrets(settings.SearchText);
            if (secrets == null) return 1;

            var t = new Table();
            t.Border = new DoubleEdgeTableBorder();
            t.AddColumn("Id");
            t.AddColumn("Name");
            t.AddColumn("Folder");
            t.AddColumn("Template");
            t.AddColumn("Last Heartbeat Status");
            t.Columns[4].Centered();
            t.AddColumn("Active?");
            t.Columns[5].Centered();
            t.AddColumn("Hide Password?");
            t.Columns[6].Centered();
            t.ZeroPaddingForAllColumns();

            foreach (var secret in secrets.Records)
            {
                var folder = await api.GetFolder(secret.FolderId);
                t.AddRow(new Text(secret.Id.ToString()),
                         new Text(secret.Name),
                         new Text(folder.FolderName),
                         new Text(secret.SecretTemplateName),
                         new Text(secret.LastHeartBeatStatus),
                         new Markup($"[{(secret.Active ? "green" : "red")}]{secret.Active.ToString()}[/]"),
                         new Markup($"[{(secret.HidePassword ? "green" : "red")}]{secret.HidePassword.ToString()}[/]"));
            }

            AnsiConsole.Write(t);

            return 0;
        }
    }
}