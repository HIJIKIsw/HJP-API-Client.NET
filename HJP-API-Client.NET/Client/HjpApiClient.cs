using Hjp.Api.Client.Common;
using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Internal;
using Hjp.Shared.Dto.Users.Login;

namespace Hjp.Api.Client
{
    public class HjpApiClient
    {
        private readonly string baseUrl;
        private readonly string apiKey;

        private readonly ApiClientInternal apiClientInternal;

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

            this.apiClientInternal = new(baseUrl, apiKey);
        }

        /// <summary>
        /// ユーザとしてログイン
        /// </summary>
        /// <param name="accessToken">アクセストークン</param>
        public async Task<ApiResponse<UserLoginResponse>> LoginWithUserAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var body = new UserLoginRequest()
            {
                AccessToken = accessToken
            };
            var result = await this.apiClientInternal.PostAsync<UserLoginResponse>("users/login", body, null, cancellationToken);
            if (result.IsSuccess == true)
            {
                this.usersClient = new(this.apiClientInternal, this.baseUrl, this.apiKey, result.Result!.DiscordUserId);
            }

            return result;
        }
    }
}