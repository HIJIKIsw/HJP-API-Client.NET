using Hjp.Api.Client.Common;
using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Api.Client.Utilities;
using Hjp.Shared.Dto.Auth;
using Hjp.Shared.Dto.System.Maintenance;
using Hjp.Shared.Dto.System.Version;

namespace Hjp.Api.Client
{
    public class HjpApiClient
    {
        private readonly ApiClientInternal apiClientInternal;

        internal delegate Task<ApiResponse<T>> ReLoginDelegate<T>(string accessToken, CancellationToken cancellationToken);

        private string? accessToken;
        private string? signature;

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
        public HjpApiClient(string baseUrl, bool isAutomaticDecompression = true)
        {
            this.apiClientInternal = new(baseUrl, isAutomaticDecompression);
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
        /// ログイン
        /// </summary>
        /// <param name="accessToken">アクセストークン</param>
        public async Task<ApiResponse<LoginResponse>> LoginAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var response = await this.LoginInternalAsync(accessToken, cancellationToken);
            if (response.IsSuccess == true)
            {
                this.usersClient = new UsersClient(this.apiClientInternal, this.signature!);
                this.usersClient.OnBeforeMethodAsync += this.AutoReloginWhenTokenExpiredAsync;

                if (response.Result?.PermissionTypeId >= Shared.Enums.PermissionType.Moderator)
                {
                    this.moderatorClient = new ModeratorClient(this.apiClientInternal, this.signature!);
                    this.moderatorClient.OnBeforeMethodAsync += this.AutoReloginWhenTokenExpiredAsync;
                }
                else
                {
                    this.moderatorClient = null;
                }

                if (response.Result?.PermissionTypeId >= Shared.Enums.PermissionType.Admin)
                {
                    this.adminClient = new AdminClient(this.apiClientInternal, this.signature!);
                    this.adminClient.OnBeforeMethodAsync += this.AutoReloginWhenTokenExpiredAsync;
                }
                else
                {
                    this.adminClient = null;
                }
            }
            else
            {
                this.Logout();
            }
            return response;
        }

        /// <summary>
        /// ログアウト
        /// </summary>
        public void Logout()
        {
            this.accessToken = null;
            this.signature = null;
            this.usersClient = null;
            this.moderatorClient = null;
            this.adminClient = null;
        }

        // 以下ヘルパーメソッド

        private async Task<ApiResponse<LoginResponse>> LoginInternalAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var request = new LoginRequest
            {
                AccessToken = accessToken,
            };
            var response = await this.apiClientInternal.PostAsync<LoginResponse>("auth/login", request, null, true, cancellationToken);
            if (response.IsSuccess == true)
            {
                this.accessToken = accessToken;
                this.signature = response.Result?.Signature!;
            }
            else
            {
                this.accessToken = null;
                this.signature = null;
            }
            return response;
        }

        private async Task AutoReloginWhenTokenExpiredAsync(CancellationToken cancellationToken = default)
        {
            var jwtPayload = JwtDecoder.DecodePayload(this.signature!);
            if (jwtPayload.IsExpired() == false)
            {
                return;
            }
            var response = await this.LoginInternalAsync(this.accessToken!, cancellationToken);
            if (response.IsSuccess == false)
            {
                throw new Exception(response.Message!);
            }
            if (this.usersClient != null)
            {
                this.usersClient.Signature = this.signature!;
            }
            if (this.moderatorClient != null)
            {
                this.moderatorClient.Signature = this.signature!;
            }
            if (this.adminClient != null)
            {
                this.adminClient.Signature = this.signature!;
            }
        }
    }
}