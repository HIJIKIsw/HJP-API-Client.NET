using System.Net.Http.Json;
using System.Text.Json;
using Hjp.Api.Client.Common;
using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Utilities;
using Hjp.Shared.Dto.Users.Login;

namespace Hjp.Api.Client
{
    public class HjpApiClient
    {
        private readonly string baseUrl;
        private readonly string apiKey;

        private HttpClient httpClient;

        private UsersClient? usersClient;

        /// <summary>
        /// ユーザ関連APIのクライアント
        /// </summary>
        /// <remarks>先に <see cref="LoginWithUserAsync(string, CancellationToken)"/> を実行してください。それまでは null を返します。</remarks>
        public IUsersClient UsersClient
        {
            get
            {
                return this.usersClient ?? throw new InvalidOperationException(Messages.Erros.NotLoggedInWithUser);
            }
        }
        /// <summary>
        /// ユーザでログインしているか
        /// </summary>
        public bool IsLoggedInWithUser => this.usersClient != null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="baseUrl">APIのベースURL</param>
        /// <param name="apiKey">APIキー</param>
        public HjpApiClient(string baseUrl, string apiKey)
        {
            this.baseUrl = baseUrl;
            this.apiKey = apiKey;

            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri(this.baseUrl);
        }

        /// <summary>
        /// ユーザとしてログイン
        /// </summary>
        /// <param name="accessToken">アクセストークン</param>
        public async Task<ApiResponse<UserLoginResponse>> LoginWithUserAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            // TOOD: リクエスト処理を共通化したい
            var jsonOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var postData = new
            {
                AccessToken = accessToken
            };
            var response = await this.httpClient.PostAsJsonAsync(
                "/users/login",
                postData,
                jsonOptions,
                cancellationToken);
            if (response.IsSuccessStatusCode == false)
            {
                return ResponseUtility.CreateErrorResponse<UserLoginResponse>(
                    response.StatusCode,
                    await response.Content.ReadAsStringAsync(cancellationToken));
            }
            var result = await response.Content.ReadFromJsonAsync<UserLoginResponse>(jsonOptions, cancellationToken);
            if (result == null)
            {
                throw new InvalidOperationException(Messages.Erros.EmptyResponseBody);
            }

            this.usersClient = new(result.DiscordUserId);

            return ResponseUtility.CreateSuccessResponse<UserLoginResponse>(response.StatusCode, result);
        }
    }
}