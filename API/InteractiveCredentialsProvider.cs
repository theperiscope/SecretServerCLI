using Spectre.Console;

namespace SecretServerCLI.API
{
    public class InteractiveCredentialsProvider : ICredentialsProvider<UsernamePasswordOTPCredentials>
    {
        public UsernamePasswordOTPCredentials GetCredentials()
        {
            AnsiConsole.Write(new Rule("[yellow]Login to Secret Server[/]") { Alignment = Justify.Left });

            var username = AnsiConsole.Prompt(new TextPrompt<string>("Username:").Secret());
            if (username == null) return null;
            var password = AnsiConsole.Prompt(new TextPrompt<string>("Password:").Secret());
            if (password == null) return null;
            var otp = AnsiConsole.Prompt(new TextPrompt<string>("OTP     :").Secret());
            if (otp == null) return null;

            return new UsernamePasswordOTPCredentials { Username = username, Password = password, OTP = otp };
        }
    }
}