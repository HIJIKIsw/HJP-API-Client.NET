using Hjp.Api.Client.Common;
using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Shared.Dto.Moderator.Login;
using Hjp.Shared.Dto.Users.Login;

namespace Hjp.Api.Client
{
    public class HjpApiClient
    {
        private readonly ApiClientInternal apiClientInternal;

        private UsersClient? usersClient;
        private ModeratorClient? moderatorClient;

        /// <summary>
        /// ユーザ関連APIのクライアント
        /// </summary>
        /// <remarks>先に <see cref="LoginWithUserAsync(string, CancellationToken)"/> を実行してください。それまでは null を返します。</remarks>
        public IUsersClient UsersClient => this.usersClient ?? throw new InvalidOperationException(Messages.Erros.NotLoggedInWithUser);
        /// <summary>
        /// ユーザでログインしているか
        /// </summary>
        public bool IsLoggedInWithUser => this.usersClient != null;
        /// <summary>
        /// モデレータ関連APIのクライアント
        /// </summary>
        public IModeratorClient ModeratorClient => this.moderatorClient ?? throw new InvalidOperationException(Messages.Erros.NotLoggedInWithModerator);
        /// <summary>
        /// モデレータでログインしているか
        /// </summary>
        public bool IsLoggedInWithModerator => this.moderatorClient != null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="baseUrl">APIのベースURL</param>
        /// <param name="apiKey">APIキー</param>
        public HjpApiClient(string baseUrl, string apiKey)
        {
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
            if (result.IsSuccess == true && result.Result != null)
            {
                this.usersClient = new(this.apiClientInternal, result.Result.DiscordUserId);
            }

            return result;
        }

        /// <summary>
        /// ユーザからログアウト
        /// </summary>
        /// <returns>ログアウトに成功したか</returns>
        public bool LogoutWithUser()
        {
            var result = this.usersClient != null;
            this.usersClient = null;
            return result;
        }

        /// <summary>
        /// モデレータとしてログイン
        /// </summary>
        public async Task<ApiResponse<ModeratorLoginResponse>> LoginWithModeratorAsync(ModeratorLoginRequest request, CancellationToken cancellationToken = default)
        {
            var result = await this.apiClientInternal.PostAsync<ModeratorLoginResponse>("moderator/login", request, null, cancellationToken);
            if (result.IsSuccess == true && result.Result != null)
            {
                this.moderatorClient = new(this.apiClientInternal, result.Result.DiscordUserId);
            }

            return result;
        }

        /// <summary>
        /// モデレータからログアウト
        /// </summary>
        /// <returns>ログアウトに成功したか</returns>
        public bool LogoutWithModerator()
        {
            var result = this.moderatorClient != null;
            this.moderatorClient = null;
            return result;
        }
    }
}