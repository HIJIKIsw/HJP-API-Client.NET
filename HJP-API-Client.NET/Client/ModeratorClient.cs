using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Shared.Dto.Moderator.Users;
using Hjp.Shared.Dto.Moderator.Users.AccessToken.Reset;
using Hjp.Shared.Dto.Moderator.Users.Lottery;
using Hjp.Shared.Dto.Moderator.Users.Register;
using Hjp.Shared.Dto.Moderator.Users.ServerActivityReward;
using Hjp.Shared.Dto.Moderator.Users.Transfer;

namespace Hjp.Api.Client
{
    internal class ModeratorClient : BaseChildClient, IModeratorClient
    {
        public ModeratorClient(ApiClientInternal apiClientInternal, string signature)
        : base(apiClientInternal, signature)
        {
            // Nothind to do.
        }

        public async Task<ApiResponse<ModeratorUserBalanceResponse>> GetUserBalanceAsync(ulong discordUserId, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<ModeratorUserBalanceResponse>(
                signature: this.signature,
                route: $"moderator/users/{discordUserId}/balance",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<ModeratorUserLotteryResponse>> DrawUserLotteryAsync(ulong discordUserId, ModeratorUserLotteryRequest request, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.PostWithSignatureAsync<ModeratorUserLotteryResponse>(
                signature: this.signature,
                route: $"moderator/users/{discordUserId}/lottery/draw",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<ModeratorUserRegisterResponse>> RegisterUserAsync(ModeratorUserRegisterRequest request, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

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
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.PostWithSignatureAsync<ModeratorUserAccessTokenResetResponse>(
                signature: this.signature,
                route: $"moderator/users/{discordUserId}/access-token/reset",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<ModeratorServerActivityRewardResponse>> DepositServerActivityRewardAsync(ulong discordUserId, ModeratorServerActivityRewardRequest request, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.PostWithSignatureAsync<ModeratorServerActivityRewardResponse>(
                signature: this.signature,
                route: $"moderator/users/{discordUserId}/server-activity-reward",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<ModeratorUserTransferResponse>> UserTransferAsync(ulong discordUserId, ModeratorUserTransferRequest request, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.PostWithSignatureAsync<ModeratorUserTransferResponse>(
                signature: this.signature,
                route: $"moderator/users/{discordUserId}/transfer",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }
    }
}