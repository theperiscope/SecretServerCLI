using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SecretServerCLI.API
{
    internal class AuthTokenFileSystemStore : IAuthTokenStore
    {
        private readonly string fileName;

        public AuthTokenFileSystemStore(string storagePath)
        {
            fileName = Path.GetFullPath(Path.Join(string.IsNullOrWhiteSpace(storagePath) ? "." : storagePath, "token.json"));
        }

        public bool Store(GetAuthTokenResponse token, out Exception ex)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                }

                File.WriteAllText(fileName, JsonConvert.SerializeObject(token, Formatting.Indented), Encoding.UTF8);

                ex = null;
                return true;
            }
            catch (Exception e)
            {
                ex = e;
                return false;
            }
        }

        public GetAuthTokenResponse Load(out Exception ex)
        {
            try
            {
                ex = null;
                return JsonConvert.DeserializeObject<GetAuthTokenResponse>(File.ReadAllText(fileName, Encoding.UTF8));
            }
            catch (Exception e)
            {
                ex = e;
                return null;
            }
        }
    }
}