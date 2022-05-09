namespace SecretServerCLI.API
{
    public interface ICredentialsProvider<T>
    {
        T GetCredentials();
    }
}