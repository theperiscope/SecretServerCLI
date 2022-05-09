using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using SecretServerCLI.API.Models;

namespace SecretServerCLI.API
{
    public interface ISecretServerSecretAPI
    {
        // Refit will expose the client via generated code so we can use it to change BaseAddress
        HttpClient Client { get; }

        [Get("/api/v1/secrets/{id}")]
        Task<Secret> GetSecret([AliasAs("id")] int secretId);

        [Get("/api/v1/secrets")]
        Task<ListOfSecrets> GetSecrets(string searchText = null);

        [Get("/api/v1/folders/{id}")]
        Task<Folder> GetFolder([AliasAs("id")] int folderId);

        [Get("/api/v1/folders")]
        Task<ListOfFolders> GetFolders(FoldersFilter filter = null);

        [Get("/api/v1/version")]
        Task<GetVersionResponse> GetVersion();
    }
}