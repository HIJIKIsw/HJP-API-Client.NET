namespace Hjp.Api.Client
{
    public class HjpApiClient
    {
        private readonly string baseUrl;
        private readonly string apiKey;

        private HttpClient httpClient;

        private UsersClient usersClient;
        public IUsersClient UsersClient => this.usersClient;

        public HjpApiClient(string baseUrl, string apiKey)
        {
            this.baseUrl = baseUrl;
            this.apiKey = apiKey;

            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri(this.baseUrl);

            this.usersClient = new UsersClient(this.httpClient);
        }
    }
}