using Hjp.Api.Client.Common;
using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Shared.Dto.Auth;
using Hjp.Shared.Dto.System.Maintenance;
using Hjp.Shared.Dto.System.Version;

namespace Hjp.Api.Client
{
    public class HjpApiClient
    {
        private readonly ApiClientInternal apiClientInternal;

        private UsersClient? usersClient;
        private ModeratorClient? moderatorClient;
        private AdminClient? adminClient;

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
        /// <remarks>先に <see cref="LoginWithModeratorAsync(string, CancellationToken)"/> を実行してください。それまでは null を返します。</remarks>
        public IModeratorClient ModeratorClient => this.moderatorClient ?? throw new InvalidOperationException(Messages.Erros.NotLoggedInWithModerator);
        /// <summary>
        /// モデレータでログインしているか
        /// </summary>
        public bool IsLoggedInWithModerator => this.moderatorClient != null;
        /// <summary>
        /// 管理者関連APIのクライアント
        /// </summary>
        /// <remarks>先に <see cref="LoginWithAdminAsync(string, CancellationToken)"/> を実行してください。それまでは null を返します。</remarks>
        public IAdminClient AdminClient => this.adminClient ?? throw new InvalidOperationException(Messages.Erros.NotLoggedInWithAdmin);
        /// <summary>
        /// 管理者でログインしているか
        /// </summary>
        public bool IsLoggedInWithAdmin => this.adminClient != null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="baseUrl">APIのベースURL</param>
        /// <param name="apiKey">APIキー</param>
        public HjpApiClient(string baseUrl)
        {
            this.apiClientInternal = new(baseUrl);
        }

        /// <summary>
        /// Pingを実行
        /// </summary>
        public async Task<ApiResponse<string>> PingAsync(CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetAsync<string>("system/ping", null, false, cancellationToken);
        }

        /// <summary>
        /// APIのバージョンを取得
        /// </summary>
        public async Task<ApiResponse<VersionResponse>> GetVersionAsync(CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetAsync<VersionResponse>("system/version", null, false, cancellationToken);
        }

        /// <summary>
        /// メンテナンス状態を取得
        /// </summary>
        public async Task<ApiResponse<MaintenanceResponse>> GetMaintenanceStatusAsync(CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetAsync<MaintenanceResponse>("system/maintenance", null, false, cancellationToken);
        }

        /// <summary>
        /// ユーザとしてログイン
        /// </summary>
        /// <param name="accessToken">アクセストークン</param>
        public async Task<ApiResponse<LoginResponse>> LoginWithUserAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var usersClient = new UsersClient(this.apiClientInternal);
            var result = await usersClient.LoginAsync(accessToken, cancellationToken);
            this.usersClient = result.IsSuccess == true ? usersClient : null;
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
        public async Task<ApiResponse<LoginResponse>> LoginWithModeratorAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var moderatorClient = new ModeratorClient(this.apiClientInternal);
            var result = await moderatorClient.LoginAsync(accessToken, cancellationToken);
            this.moderatorClient = result.IsSuccess == true ? moderatorClient : null;
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

        /// <summary>
        /// 管理者としてログイン
        /// </summary>
        public async Task<ApiResponse<LoginResponse>> LoginWithAdminAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var adminClient = new AdminClient(this.apiClientInternal);
            var result = await adminClient.LoginAsync(accessToken, cancellationToken);
            this.adminClient = result.IsSuccess == true ? adminClient : null;
            return result;
        }

        /// <summary>
        /// 管理者からログアウト
        /// </summary>
        /// <returns>ログアウトに成功したか</returns>
        public bool LogoutWithAdmin()
        {
            var result = this.adminClient != null;
            this.adminClient = null;
            return result;
        }
    }
}