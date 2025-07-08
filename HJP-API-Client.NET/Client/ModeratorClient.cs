using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Shared.Dto.Auth;
using Hjp.Shared.Dto.Moderator.Users.AccessToken.Reset;
using Hjp.Shared.Dto.Moderator.Users.Register;
using Hjp.Shared.Enums;

namespace Hjp.Api.Client
{
    internal class ModeratorClient : IModeratorClient
    {
        private readonly ApiClientInternal apiClientInternal;

        private string accessToken = null!;
        private string signature = null!;

        public ModeratorClient(ApiClientInternal apiClientInternal)
        {
            this.apiClientInternal = apiClientInternal;
        }

        public async Task<ApiResponse<LoginResponse>> LoginWithUserAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var request = new LoginRequest
            {
                AccessToken = accessToken,
                AsPermissionTypeId = PermissionType.Moderator
            };
            var result = await this.apiClientInternal.PostAsync<LoginResponse>("auth/login", request, null, true, cancellationToken);
            if (result.IsSuccess == true)
            {
                this.accessToken = accessToken;
                this.signature = result.Result?.Signature!;
            }
            else
            {
                this.accessToken = null!;
                this.signature = null!;
            }
            return result;
        }

        public async Task<ApiResponse<ModeratorUserRegisterResponse>> RegisterUserAsync(ModeratorUserRegisterRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<ModeratorUserRegisterResponse>(
                signature: this.signature,
                route: "moderator/users/register",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<ModeratorUserAccessTokenResetResponse>> ResetUserAccessTokenAsync(ulong discordUserId, ModeratorUserAccessTokenResetRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<ModeratorUserAccessTokenResetResponse>(
                signature: this.signature,
                route: $"moderator/users/{discordUserId}/access-token/reset",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }
    }
}