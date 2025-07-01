using Hjp.Api.Client.Dto;
using Hjp.Shared.Dto.Users.Login;

namespace Hjp.Api.Client
{
    public interface IUsersClient
    {
        /// <summary>
        /// ログイン
        /// </summary>
        /// <param name="accessToken">アクセストーク</param>
        /// <param name="cancellationToken">キャンセルトークン</param>
        Task<ApiResponse<UserLoginResponse>> LoginAsync(string accessToken, CancellationToken cancellationToken = default);
    }
}