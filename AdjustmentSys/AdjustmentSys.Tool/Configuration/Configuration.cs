using Microsoft.Extensions.Configuration;

namespace AdjustmentSys.Tool.Configuration
{
    public class Configuration : IConfiguration
    {
        private static IConfigurationRoot configurationRoot;
        static Configuration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            configurationRoot = builder.Build();
        }
        public string Read(string key)
        {
            return configurationRoot[key];
        }
    }
}
