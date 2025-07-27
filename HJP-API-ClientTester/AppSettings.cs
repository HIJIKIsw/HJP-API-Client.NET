using Microsoft.Extensions.Configuration;

namespace Hjp.Api.Client.Tester
{
    public static class AppSettings
    {
        private static ConfigurationManager configurationManager = null!;

        public static void Initialize(ConfigurationManager configurationManager)
        {
            AppSettings.configurationManager = configurationManager;
        }

        public static string ApiBaseUrl
        {
            get
            {
                return configurationManager["BaseUrl"]!;
            }
        }

        public static string ApiKey
        {
            get
            {
                return configurationManager["ApiKey"]!;
            }
        }

        public static string AccessToken
        {
            get
            {
                return configurationManager["AccessToken"]!;
            }
        }

        public static int ApplicationId
        {
            get
            {
                return int.Parse(configurationManager["ApplicationId"]!);
            }
        }
    }
}