using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace key_vault_console_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("KEY_VAULT_NAME", "kv-practice");
            Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", "23e73037-0a51-403a-960d-27df744a3a00");
            Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", "78d2dc18-7d33-4e8d-96d9-c5dc222fda13");
            Environment.SetEnvironmentVariable("AZURE_TENANT_ID", "d61de018-082f-46bb-80e0-bbde4455d074");
            string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
            var kvUri = "https://" + keyVaultName + ".vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            KeyVaultSecret secret = client.GetSecret("stuff");
            Console.WriteLine(secret);
            Console.WriteLine(secret.Value);
        }
    }
}
