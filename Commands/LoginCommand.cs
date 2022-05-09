using System;
using SecretServerCLI.API;
using SecretServerCLI.Framework;
using SecretServerCLI.Spectre;
using Spectre.Console.Cli;

namespace SecretServerCLI.Commands
{
    public class LoginCommand : Command<LoginCommand.Settings>
    {
        private readonly IAuthTokenProvider authTokenProvider;

        public LoginCommand(IAuthTokenProvider authTokenProvider)
        {
            this.authTokenProvider = authTokenProvider ?? throw new ArgumentNullException(nameof(authTokenProvider));
        }
        public class Settings : SharedSpectreCommandSettings
        {
            [CommandOption("-r|--reset")]
            public bool IsReset { get; set; }
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            var tokenResult = authTokenProvider.GetToken(settings.IsReset).GetAwaiter().GetResult();
            if (tokenResult.Item2 != null) throw tokenResult.Item2;

            tokenResult.Item1.Print();
            return 0;
        }
    }
}