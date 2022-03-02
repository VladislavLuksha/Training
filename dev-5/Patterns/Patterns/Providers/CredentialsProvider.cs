using Patterns.Utils;
using System.IO;
using System.Text.Json;

namespace Patterns.Providers
{
    public class CredentialsProvider
    {
        private const string NAME_JSON_FILE = "CredentialsData.json";

        public void Provide(out CredentialsConstants credentialsConstantsObject)
        {
            var objectJsonFile = File.ReadAllText(NAME_JSON_FILE);
            credentialsConstantsObject =  JsonSerializer.Deserialize<CredentialsConstants>(objectJsonFile);
        }
    }
}
