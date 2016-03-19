using System.Configuration;

namespace Hambasafe.Server.Services.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        public string GetStorageConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString;
        }

     
    }
}