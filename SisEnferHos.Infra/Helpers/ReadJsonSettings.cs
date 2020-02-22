using Microsoft.Extensions.Configuration;
using System.IO;

namespace SistEnferHos.Infra.Helpers
{
    public class ReadJsonSettings
    {
        public string ConnectionString()
        {
            return GetConnectionString();
        }

        private string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return (config.GetConnectionString("connectionString"));
        }
    }
}
