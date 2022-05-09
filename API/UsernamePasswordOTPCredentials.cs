namespace SecretServerCLI.API
{
    public class UsernamePasswordOTPCredentials
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public string OTP { get; set; }
    }
}