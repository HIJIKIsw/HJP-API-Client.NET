using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Shared.Dto.Moderator.Users.AccessToken.Reset;
using Hjp.Shared.Dto.Moderator.Users.Register;

namespace Hjp.Api.Client
{
    internal class ModeratorClient : IModeratorClient
    {
        private readonly string signature;

        private readonly ApiClientInternal apiClientInternal;

        public ModeratorClient(ApiClientInternal apiClientInternal, string signature)
        {
            this.apiClientInternal = apiClientInternal;
            this.signature = signature;
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