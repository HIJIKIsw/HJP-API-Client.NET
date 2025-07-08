using System.Security.Claims;
using System.Text.Json.Serialization;
using Hjp.Shared.Constants;
using Hjp.Shared.Enums;

namespace Hjp.Api.Client.Dto
{
    public class JwtPayloadModel
    {
        [JsonPropertyName(ApiConstants.ClaimTypes.DiscordUserId)]
        public ulong DiscordUserId { get; set; }

        [JsonPropertyName(ApiConstants.ClaimTypes.UserName)]
        public string UserName { get; set; } = null!;

        [JsonPropertyName(ApiConstants.ClaimTypes.AvatarUrl)]
        public string AvatarUrl { get; set; } = null!;

        [JsonPropertyName(ClaimTypes.Role)]
        public PermissionType Role { get; set; }

        [JsonPropertyName("exp")]
        public long Expiration { get; set; }

        [JsonPropertyName("iss")]
        public string Issuer { get; set; } = null!;

        [JsonPropertyName("aud")]
        public string Audience { get; set; } = null!;
    }
}